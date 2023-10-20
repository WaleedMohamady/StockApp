using Microsoft.AspNetCore.Mvc;
using Stock.BL.Items.DTOs;
using Stock.BL.Items.Manager;

namespace StockApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemsManager _itemsManager;

        public ItemsController(IItemsManager itemsManager)
        {
            _itemsManager = itemsManager;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _itemsManager.GetAll();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ItemReadDTO>> Create(ItemAddDTO itemAddDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var itemReadDTO = await _itemsManager.Add(itemAddDTO);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);

                }
                return RedirectToAction(nameof(Index));
            }
            return View(itemAddDTO);
        }

        public async Task<IActionResult> ShowStores(Guid id)
        {
            var item = await _itemsManager.GetById(id);
            ViewBag.Item = item;

            var itemStores = await _itemsManager.GetItemStores(id);
            return View(itemStores);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var item = await _itemsManager.GetById(id);

                if (item is null)
                {
                    return NotFound();
                }

                return View(new ItemUpdateDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    TotalBalance = item.TotalBalance,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ItemUpdateDTO itemUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _itemsManager.Update(itemUpdateDTO);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(itemUpdateDTO);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _itemsManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
