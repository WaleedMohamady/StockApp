using Microsoft.AspNetCore.Mvc;
using Stock.BL.Stores.DTOs;
using Stock.BL.Stores.Manager;

namespace StockApp.Controllers
{
    public class StoresController : Controller
    {
        private readonly IStoresManager _storesManager;
        public StoresController(IStoresManager storesManager)
        {
            _storesManager = storesManager;
        }
        public async Task<IActionResult> Index()
        {
            var stores = await _storesManager.GetAll();
            return View(stores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<StoreReadDTO>> Create(StoreAddDTO storeAddDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var storeReadDTO = await _storesManager.Add(storeAddDto);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);

                }
                return RedirectToAction(nameof(Index));
            }
            return View(storeAddDto);
        }

        public async Task<IActionResult> ShowItems(Guid id)
        {
            var store = await _storesManager.GetById(id);
            ViewBag.Store = store;

            var itemsInStore = await _storesManager.GetStoreItems(id);
            return View(itemsInStore);
        }


        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var store = await _storesManager.GetById(id);

                if (store is null)
                {
                    return NotFound();
                }

                return View(new StoreUpdateDTO
                {
                    Id = store.Id,
                    Name = store.Name,
                    Address = store.Address,
                    MobileNumber = store.MobileNumber,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StoreUpdateDTO storeUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _storesManager.Update(storeUpdateDTO);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(storeUpdateDTO);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _storesManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest( ex.Message);
            }

        }
    }
}
