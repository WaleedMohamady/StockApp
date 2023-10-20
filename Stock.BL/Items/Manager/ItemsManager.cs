using AutoMapper;
using Stock.BL.Items.DTOs;
using Stock.BL.Stores.DTOs;
using Stock.DBAL.Models;
using Stock.DBAL.Repositories.Items_Repo;

namespace Stock.BL.Items.Manager;

public class ItemsManager : IItemsManager
{
    #region Fields
    private readonly IItemsRepo _itemsRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public ItemsManager(IItemsRepo itemsRepo, IMapper mapper)
    {
        _itemsRepo = itemsRepo;
        _mapper = mapper;
    }
    #endregion

    #region Methods
    public async Task<List<ItemReadDTO>> GetAll()
    {
        var items = await _itemsRepo.GetAll();
        return _mapper.Map<List<ItemReadDTO>>(items);
    }

    public async Task<ItemReadDTO> GetById(Guid id)
    {
        var item = await _itemsRepo.GetById(id);
        if (item is null) { return null; }
        return _mapper.Map<ItemReadDTO>(item);
    }

    public async Task<ItemReadDTO> Add(ItemAddDTO item)
    {
        var addedItem = _mapper.Map<Item>(item);
        addedItem.Id = Guid.NewGuid();
        await _itemsRepo.Add(addedItem);
        await _itemsRepo.SaveChanges();
        return _mapper.Map<ItemReadDTO>(addedItem);
    }

    public async Task<bool> Update(ItemUpdateDTO item)
    {
        var updatedItem = await _itemsRepo.GetById(item.Id);
        if (updatedItem is null)
            return false;
        _mapper.Map(item, updatedItem);
        _itemsRepo.Update(updatedItem);
        await _itemsRepo.SaveChanges();
        return true;
    }
    public async Task Delete(Guid id)
    {
        await _itemsRepo.DeleteById(id);
        await _itemsRepo.SaveChanges();
    }

    public async Task<List<ItemStoresDTO>> GetItemStores(Guid id)
    {
        var itemStoresdto = new List<ItemStoresDTO>();
        var itemStores = await _itemsRepo.GetItemStores(id);
        foreach (var store in itemStores)
        {
            var storeDto = _mapper.Map<ItemStoresDTO>(store);
            itemStoresdto.Add(storeDto);
        }
        return itemStoresdto;
    }
    #endregion
}
