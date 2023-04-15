using BAL.Abstraction;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using ShopStore.ViewModel;
using ShopStore.ViewModels;
using System.Diagnostics;
using System.Linq.Expressions;

namespace ShopStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IProductPromotionService _productPromotionService;
        private readonly IUserProductService _userProductService;
        public HomeController(ILogger<HomeController> logger, IProductService productService , IProductPromotionService productPromotionService, IUserProductService userProductService)
        {
            _logger = logger;
            _productService = productService;
            _productPromotionService = productPromotionService;
            _userProductService = userProductService;
        }

        public async Task<IActionResult> Index()
        {
            Expression<Func<ProductPromotion, object>>[] productPromotionIncludes =
            {
                o => o.Product,
                o => o.Promotion
            };

            Expression<Func<UserProduct, object>>[] userProductIncludes =
            {
                o => o.Product,
                o => o.User
            };

            var productPromotions = await _productPromotionService.GetAll(productPromotionIncludes);
            var userProducts = await _userProductService.GetAll(userProductIncludes);

            ProductViewModel product = new ProductViewModel
            {
                ProductPromotions = productPromotions,
                UserProducts = userProducts,
                Products = await GetTopProducts()
            };

            return _productPromotionService != null ? View(product) : Problem("Entity set 'ApplicationDbContext.ProductPromotion'  is null.");
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public async Task<List<Product>> GetTopProducts()
        {
            List<Product> products = new List<Product>();
            var topProducts = _userProductService.GetTopProducts();
            foreach (var product in topProducts)
            {
                products.AddRange(await _productService.GetAll(x => x.Name == product.GetType().GetProperty("Name").GetValue(product)));
            }

            return products;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}