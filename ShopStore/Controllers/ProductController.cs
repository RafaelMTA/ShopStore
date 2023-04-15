using BAL.Abstraction;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopStore.ViewModel;
using System.Linq.Expressions;

namespace ShopStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly IUserProductService _userProductService;
        private readonly ICategoryService _categoryService;
        private readonly IProductPromotionService _productPromotionService;
        private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProductController(IProductService service, IUserProductService userProductService, ICategoryService categoryService, IProductPromotionService productPromotionService, ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userProductService = userProductService;
            _categoryService = categoryService;
            _productPromotionService = productPromotionService;
            _cartService = cartService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            Expression<Func<ProductPromotion, object>>[] includes =
            {
                o => o.Product,
                o => o.Promotion
            };

            var productPromotions = await _productPromotionService.GetAll(includes);

            var model = new ProductViewModel
            {
                ProductPromotions = productPromotions,
                Products = await GetAllProducts()
            };

            return _service != null ?
            View(model) :
            Problem("Entity set 'ApplicationDbContext.Products'  is null.");
        }
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }

            var entity = await _service.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewData["Category"] = new SelectList(await _categoryService.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Name, Description, Price, ImageURL, CategoryId")] Product entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Create(entity);
                    return RedirectToAction(nameof(Index));
                }

                ViewData["Category"] = new SelectList(await _categoryService.GetAll(), "Id", "Name", entity.Id);
                return View(entity);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }

            var entity = await _service.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            ViewData["Category"] = new SelectList(await _categoryService.GetAll(), "Id", "Name", entity.Id);

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, Name, Description, Price, ImageURL, CategoryId")] Product entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Update(id, entity);
                    return RedirectToAction(nameof(Index));
                }

                ViewData["Category"] = new SelectList(await _categoryService.GetAll(), "Id", "Name", entity.Id);
                return View(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                var exists = await EntityExists(entity.Id);
                if (!exists)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }

            Expression<Func<Product, object>>[] includes =
            {
                o => o.Promotions,
                o => o.Category
            };

            var entity = await _service.GetById(id, includes);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }

            await _service.Remove(id);

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddItemToCart(Product product)
        {
            var cartItem = new Cart
            {
                ProductId = product.Id,
                UserId = GetUserId(),
                Quantity = 2
            };

            await _cartService.Create(cartItem);

            return RedirectToAction("Index", "Cart");
        }
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Cart()
        {
            Expression<Func<Cart, object>>[] includes =
            {
                o => o.Product,
                o => o.User
            };

            var cartItems = await _cartService.GetAll(x => x.UserId == GetUserId(), includes);

            return cartItems == null ? View() : View(cartItems);
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            Expression<Func<Cart, object>>[] includes =
            {
                o => o.Product,
                o => o.User
            };

            var cartItems = await _cartService.GetAll(x => x.UserId == GetUserId(), includes);

            foreach (var item in cartItems)
            {
                UserProduct userProduct = new UserProduct
                {
                    ProductId = item.ProductId,
                    UserId = GetUserId(),
                };

                await _userProductService.Create(userProduct);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EntityExists(Guid id)
        {
            var exist = await _service.GetById(id);

            if (exist == null) return false;

            return true;
        }

        private async Task<IEnumerable<Product>> GetAllProducts()
        {
            Expression<Func<Product, object>>[] includes =
            {
                o => o.Promotions,
                o => o.Category
            };

            return _service != null ? await _service.GetAll(includes) : null;
        }
        private string GetUserId()
        {
            return _userManager.GetUserId(User)!;
        }
    }
}
