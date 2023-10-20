
using Microsoft.EntityFrameworkCore;
using Stock.DBAL.Context;
using Stock.DBAL.Models;

namespace Stock.DBAL.Repositories.Items_Repo;

public class ItemsRepo : GenericRepo<Item> , IItemsRepo
{
    #region Fields
    private readonly StockDbContext _context;
    #endregion

    #region Ctor
    public ItemsRepo(StockDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    #region Methods
    public async Task<List<StoreItem>> GetItemStores(Guid id)
    {
        var itemStores = await _context.StoreItems
            .Include(s => s.Store)
            .Where(s => s.ItemId == id)
            .ToListAsync();

        return itemStores;
    }
    #endregion
}
