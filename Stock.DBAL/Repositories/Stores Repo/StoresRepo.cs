using Microsoft.EntityFrameworkCore;
using Stock.DBAL.Context;
using Stock.DBAL.Models;

namespace Stock.DBAL.Repositories.Stores_Repo;

public class StoresRepo : GenericRepo<Store> , IStoresRepo
{
    #region Fields
    private readonly StockDbContext _context;
    #endregion

    #region Ctor
    public StoresRepo(StockDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    #region Methods
    public async Task<List<StoreItem>> GetStoreItems(Guid id)
    {
        var storeItems = await _context.StoreItems
            .Include(s => s.Item)
            .Where(s => s.StoreId == id)
            .ToListAsync();

        return storeItems;
    }
    #endregion
}
