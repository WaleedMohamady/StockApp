using Stock.DBAL.Models;
using Stock.DBAL.Repositories.Generic_Repo;

namespace Stock.DBAL.Repositories.StoreItems_Repo
{
    public interface IStoreItemsRepo : IGenericRepo<StoreItem>
    {
        Task<StoreItem> GetByStoreIdAndItemId (Guid storeId, Guid itemId);
    }
}
