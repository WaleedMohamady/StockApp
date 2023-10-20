using AutoMapper;
using Stock.BL.Invoices.DTOs;
using Stock.DBAL.Models;
using Stock.DBAL.Repositories.Invoices_Repo;
using Stock.DBAL.Repositories.Items_Repo;
using Stock.DBAL.Repositories.StoreItems_Repo;

namespace Stock.BL.Invoices.Manager;

public class InvoicesManager : IInvoicesManager
{
    #region Fields
    private readonly IInvoicesRepo _invoicesRepo;
    private readonly IMapper _mapper;
    private readonly IStoreItemsRepo _storeItemsRepo;
    private readonly IItemsRepo _itemsRepo;
    #endregion

    #region Ctor
    public InvoicesManager(IInvoicesRepo invoicesRepo, IMapper mapper, IStoreItemsRepo storeItemsRepo, IItemsRepo itemsRepo)
    {
        _invoicesRepo = invoicesRepo;
        _mapper = mapper;
        _storeItemsRepo = storeItemsRepo;
        _itemsRepo = itemsRepo;
    }
    #endregion

    #region Methods
    public async Task<InvoiceReadDTO> Add(InvoiceAddDTO invoice)
    {
        var addedInvoice = _mapper.Map<Invoice>(invoice);
        addedInvoice.Id = Guid.NewGuid();
        await _invoicesRepo.Add(addedInvoice);

        var storeItem = await _storeItemsRepo.GetByStoreId(addedInvoice.StoreId);
        if (storeItem is null)
        {
            var newStoreItem = new StoreItem
            {
                StoreId = addedInvoice.StoreId,
                ItemId = addedInvoice.ItemId,
                AvailableBalance = addedInvoice.Quantity
            };
            await _storeItemsRepo.Add(newStoreItem);
        }
        else
        {
            storeItem.AvailableBalance += addedInvoice.Quantity;
        }

        var item = await _itemsRepo.GetById(addedInvoice.ItemId);
        item.TotalBalance -= addedInvoice.Quantity;

        await _invoicesRepo.SaveChanges();
        return _mapper.Map<InvoiceReadDTO>(addedInvoice);
    }
    #endregion
}
