using Stock.BL.Stores.DTOs;
using Stock.DBAL.Models;

namespace Stock.BL.Stores.Manager;

public interface IStoresManager
{
    Task<List<StoreReadDTO>> GetAll();
    Task<StoreReadDTO> GetById(Guid id);
    Task<StoreReadDTO> Add(StoreAddDTO storeAddDto);
    Task<bool> Update(StoreUpdateDTO storeUpdateDto);
    Task Delete(Guid id);
    Task<List<ItemsInStoreDTO>> GetStoreItems(Guid Id);
}
