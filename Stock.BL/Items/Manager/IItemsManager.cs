using Stock.BL.Items.DTOs;
using Stock.BL.Stores.DTOs;

namespace Stock.BL.Items.Manager;

public interface IItemsManager
{
    Task<List<ItemReadDTO>> GetAll();
    Task<ItemReadDTO> GetById(Guid id);
    Task<ItemReadDTO> Add(ItemAddDTO itemAddDto);
    Task<bool> Update(ItemUpdateDTO itemUpdateDto);
    Task Delete(Guid id);
    Task<List<ItemStoresDTO>> GetItemStores(Guid Id);

}
