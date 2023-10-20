using AutoMapper;
using Stock.BL.Stores.DTOs;
using Stock.DBAL.Models;
using Stock.DBAL.Repositories.Stores_Repo;

namespace Stock.BL.Stores.Manager;

public class StoresManager : IStoresManager
{
    #region Fields
    private readonly IStoresRepo _storesRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public StoresManager(IStoresRepo storesRepo, IMapper mapper)
    {
        _storesRepo = storesRepo;
        _mapper = mapper;
    }
    #endregion

    #region Methods
    public async Task<List<StoreReadDTO>> GetAll()
    {
        var stores = await _storesRepo.GetAll();
        return _mapper.Map<List<StoreReadDTO>>(stores);
    }

    public async Task<StoreReadDTO> GetById(Guid id)
    {
        var store = await _storesRepo.GetById(id);
        if (store is null) { return null; }
        return _mapper.Map<StoreReadDTO>(store);
    }

    public async Task<StoreReadDTO> Add(StoreAddDTO store)
    {
        var addedStore = _mapper.Map<Store>(store);
        addedStore.Id = Guid.NewGuid();
        await _storesRepo.Add(addedStore);
        await _storesRepo.SaveChanges();
        return _mapper.Map<StoreReadDTO>(addedStore);
    }

    public async Task<bool> Update(StoreUpdateDTO store)
    {
        var updatedStore = await _storesRepo.GetById(store.Id);
        if (updatedStore is null)
            return false;
        _mapper.Map(store, updatedStore);
        _storesRepo.Update(updatedStore);
        await _storesRepo.SaveChanges();
        return true;
    }
    public async Task Delete(Guid id)
    {
        await _storesRepo.DeleteById(id);
        await _storesRepo.SaveChanges();
    }
    public async Task<List<ItemsInStoreDTO>> GetStoreItems(Guid id)
    {
        var itemsInStore = new List<ItemsInStoreDTO>();
        var storeItems = await _storesRepo.GetStoreItems(id);
        foreach (var item in storeItems)
        {
            var itemDto = _mapper.Map<ItemsInStoreDTO>(item);
            itemsInStore.Add(itemDto);
        }
        return itemsInStore;
    }
    #endregion
}
