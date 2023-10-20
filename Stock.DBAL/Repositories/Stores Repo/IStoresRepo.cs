using Stock.DBAL.Models;
using Stock.DBAL.Repositories.Generic_Repo;

namespace Stock.DBAL.Repositories.Stores_Repo;

public interface IStoresRepo : IGenericRepo<Store> 
{
    Task<List<StoreItem>> GetStoreItems(Guid Id);
}
