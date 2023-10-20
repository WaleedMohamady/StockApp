using Stock.DBAL.Models;
using Stock.DBAL.Repositories.Generic_Repo;

namespace Stock.DBAL.Repositories.Items_Repo;

public interface IItemsRepo : IGenericRepo<Item> 
{
    Task<List<StoreItem>> GetItemStores(Guid Id);
}
