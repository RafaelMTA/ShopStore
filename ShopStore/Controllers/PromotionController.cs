using BAL.Abstraction;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShopStore.Controllers
{
    [Authorize]
    public class PromotionController : Controller
    {
        private readonly IPromotionService _service;
        public PromotionController(IPromotionService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return _service != null ?
                View(await _service.GetAll()) :
                NotFound();
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Discount, Start, End")] Promotion entity)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

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
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Discount, Start, End")] Promotion entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(id, entity);

                }
                catch (Exception ex)
                {
                    var exist = await EntityExists(entity.Id);

                    if (!exist)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        public async Task<IActionResult> Delete(Guid id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_service == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Promotions'  is null.");
            }
            var entity = await _service.GetById(id);
            if (entity != null)
            {
                await _service.Remove(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EntityExists(Guid id)
        {
            return await _service.GetById(id) != null ? true : false;
        }
    }
}
