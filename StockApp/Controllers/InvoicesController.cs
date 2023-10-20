using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stock.BL.Invoices.DTOs;
using Stock.BL.Invoices.Manager;
using Stock.BL.Items.Manager;
using Stock.BL.Stores.Manager;

namespace StockApp.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly IInvoicesManager _invoicesManager;
        private readonly IStoresManager _storesManager;
        private readonly IItemsManager _itemsManager;

        public InvoicesController(IInvoicesManager invoicesManager, IStoresManager storesManager, IItemsManager itemsManager)
        {
            _invoicesManager = invoicesManager;
            _storesManager = storesManager;
            _itemsManager = itemsManager;
        }
        public async Task<IActionResult> Index()
        {
            var stores = await _storesManager.GetAll();
            ViewBag.Stores = new SelectList(stores, "Id", "Name");

            var items = await _itemsManager.GetAll();
            ViewBag.Items = new SelectList(items, "Id", "Name");

            return View();
        }

        public async Task<ActionResult<int>> GetItemTotalBalance(Guid itemId)
        {
            var item = await _itemsManager.GetById(itemId);
            return item.TotalBalance;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<InvoiceReadDTO>> Create(InvoiceAddDTO invoiceAddDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var invoiceReadDTO = await _invoicesManager.Add(invoiceAddDTO);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);

                }
                return RedirectToAction(nameof(Index));
            }
            return View(invoiceAddDTO);
        }


    }
}
