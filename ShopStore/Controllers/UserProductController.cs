using BAL.Abstraction;
using BAL.Services;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ShopStore.Controllers
{
    [Authorize]
    public class UserProductController : Controller
    {
        private readonly IUserProductService _service;
        private readonly IProductService _productService;

        private readonly UserManager<ApplicationUser> _userManager;

        public UserProductController(IUserProductService service, UserManager<ApplicationUser> userManager, IProductService productService)
        {
            _service = service;
            _userManager = userManager;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            Expression<Func<UserProduct, object>>[] includes =
    {
                        o => o.Product,
                        o => o.User
                    };
            if (User.IsInRole("Admin"))
            {
                return _service != null ? View(await _service.GetAll(includes)) : NotFound();
            }
            else
            {
                return _service != null ? View(await _service.GetAll(x => x.UserId == _userManager.GetUserId(User), includes)) : NotFound();
            }
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
            var entities = await _service.GetAll();
            ViewBag["ProductId"] = new SelectList(await _productService.GetAll(), "Id", "Name");
            return View(entities);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([Bind("ProductId, UserId")] UserProduct entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Create(entity);
                    return RedirectToAction(nameof(Index));
                }

                var usersId = await GetAllUserIdsAsync();

                ViewBag["ProductId"] = new SelectList(await _productService.GetAll(), "Id", "Name", entity.Id);
                ViewBag["UserId"] = new SelectList(usersId, "Id", "FullName");

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
        public async Task<IActionResult> Edit(Guid id)
        {
            if (_service == null) return NotFound();

            var entity = await _service.GetById(id);
            if (id == null || entity == null) return NotFound();

            var usersId = await GetAllUserIdsAsync();

            ViewBag["ProductId"] = new SelectList(await _productService.GetAll(), "Id", "Name", entity.Id);
            ViewBag["UserId"] = new SelectList(usersId, "Id", "FullName", entity.Id);

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductId, UserId")] UserProduct entity)
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

                ViewBag["ProductId"] = new SelectList(await _productService.GetAll(), "Id", "Name", entity.Id);               

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

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }

            Expression<Func<UserProduct, object>>[] includes =
            {
                o => o.Product,
                o => o.User
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
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }

            await _service.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EntityExists(Guid id)
        {
            var exist = await _service.GetById(id);

            if (exist == null) return false;

            return true;
        }
        private async Task<List<string>> GetAllUserIdsAsync()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");
            var userIds = users.Select(u => u.Id).ToList();
            return userIds;
        }
    }
}
