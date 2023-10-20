using AutoMapper;
using Stock.BL.Invoices.DTOs;
using Stock.BL.Items.DTOs;
using Stock.BL.Stores.DTOs;
using Stock.DBAL.Models;

namespace Stock.BL;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
        #region Store
        CreateMap<Store, StoreReadDTO>();
        CreateMap<StoreAddDTO, Store>();
        CreateMap<StoreUpdateDTO, Store>();
        CreateMap<StoreItem, ItemsInStoreDTO>()
            .ForMember(s => s.Name, opt => opt.MapFrom(s => s.Item.Name));
        #endregion

        #region Item
        CreateMap<Item, ItemReadDTO>();
        CreateMap<ItemAddDTO, Item>();
        CreateMap<ItemUpdateDTO, Item>();
        CreateMap<StoreItem, ItemStoresDTO>()
            .ForMember(s => s.Name, opt => opt.MapFrom(s => s.Store.Name));

        #endregion

        #region Invoice
        CreateMap<Invoice, InvoiceReadDTO>();
        CreateMap<InvoiceAddDTO, Invoice>();
        #endregion
    }
}
