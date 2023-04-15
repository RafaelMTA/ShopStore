using BAL.Abstraction;
using BAL.Services;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq.Expressions;

namespace ShopStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _service;
        private readonly IUserProductService _userProductService;
        private readonly UserManager<ApplicationUser> _userManager;
        public CartController(ICartService service, IUserProductService userProductService, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userProductService = userProductService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            Expression<Func<Cart, object>>[] includes =
           {
                o => o.Product,
                o => o.User
            };

            var cartItems = await _service.GetAll(x => x.UserId == GetUserId(), includes);

            return cartItems == null ? View() : View(cartItems);
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> CheckOut()
        {
            Expression<Func<Cart, object>>[] includes =
            {
                o => o.Product,
                o => o.User
            };

            var cartItems = await _service.GetAll(x => x.UserId == GetUserId(), includes);

            foreach (var item in cartItems)
            {
                UserProduct userProduct = new UserProduct
                {
                    ProductId = item.ProductId,
                    UserId = GetUserId(),
                };

                await _userProductService.Create(userProduct);
                await _service.Remove(item.Id);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(Guid id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }

            await _service.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        private string GetUserId()
        {
            return _userManager.GetUserId(User)!;
        }
    }
}
