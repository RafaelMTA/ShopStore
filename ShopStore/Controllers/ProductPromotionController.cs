using BAL.Abstraction;
using BAL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ShopStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductPromotionController : Controller
    {
        private readonly IProductPromotionService _service;
        private readonly IProductService _productService;
        private readonly IPromotionService _promotionService;

        public ProductPromotionController(IProductPromotionService service, IProductService productService, IPromotionService promotionService)
        {
            _service = service;
            _productService = productService;
            _promotionService = promotionService;
        }
        public async Task<IActionResult> Index()
        {
            Expression<Func<ProductPromotion, object>>[] includes =
            {
                o => o.Product,
                o => o.Promotion
            };

            try
            {
              return _service != null ?
              View(await _service.GetAll(includes)) : NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> Details(Guid id)
        {
            Expression<Func<ProductPromotion, object>>[] includes =
            {
                o => o.Product,
                o => o.Promotion
            };

            if (id == null || _service == null)
            {
                return NotFound();
            }

            var entity = await _service.GetById(id, includes);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewData["Product"] = new SelectList(await _productService.GetAll(), "Id", "Name");
            ViewData["Promotion"] = new SelectList(await _promotionService.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([Bind("ProductId, PromotionId")] ProductPromotion entity)
        {
            try
            {
                Expression<Func<ProductPromotion, object>>[] includes =
                {
                    o => o.Product,
                    o => o.Promotion
                };

                var productPromotions = await _service.GetById(entity.Id, includes);

                if (productPromotions != null)
                {
                    if (CheckIfDatesOverlaps(productPromotions.Promotion.Start, productPromotions.Promotion.End, entity.Promotion.Start, entity.Promotion.End))
                    {
                        return View(entity);
                    }
                }

                ModelState.Remove("FinalPrice");

                if (ModelState.IsValid)
                {
                    await _service.Create(entity);
                    return RedirectToAction(nameof(Index));
                }

                ViewData["Product"] = new SelectList(await _productService.GetAll(), "Id", "Name", entity.ProductId);
                ViewData["Promotion"] = new SelectList(await _promotionService.GetAll(), "Id", "Name", entity.PromotionId);

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
            Expression<Func<ProductPromotion, object>>[] includes =
                {
                    o => o.Product,
                    o => o.Promotion
                };

            if (_service == null) return NotFound();

            var entity = await _service.GetById(id, includes);

            if (id == null || entity == null) return NotFound();

            ViewData["Product"] = new SelectList(await _productService.GetAll(), "Id", "Name", entity.ProductId);
            ViewData["Promotion"] = new SelectList(await _promotionService.GetAll(), "Id", "Name", entity.PromotionId);

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, ProductId, PromotionId")] ProductPromotion entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            try
            {
                ModelState.Remove("FinalPrice");

                if (ModelState.IsValid)
                {
                    await _service.Update(id, entity);
                    return RedirectToAction(nameof(Index));
                }

                ViewData["Product"] = new SelectList(await _productService.GetAll(), "Id", "Name", entity.ProductId);
                ViewData["Promotion"] = new SelectList(await _promotionService.GetAll(), "Id", "Name", entity.PromotionId);

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

            Expression<Func<ProductPromotion, object>>[] includes =
            {
                o => o.Product,
                o => o.Promotion
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
        private bool CheckIfDatesOverlaps(DateTime initial, DateTime final, DateTime start, DateTime end)
        {
            return initial <= final && start <= end;
        }
        private async Task<bool> EntityExists(Guid id)
        {
            var exist = await _service.GetById(id);

            if (exist == null) return false;

            return true;
        }
    }
}
