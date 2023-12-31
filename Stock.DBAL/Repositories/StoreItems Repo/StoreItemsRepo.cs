﻿using Microsoft.EntityFrameworkCore;
using Stock.DBAL.Context;
using Stock.DBAL.Models;

namespace Stock.DBAL.Repositories.StoreItems_Repo
{
    public class StoreItemsRepo : GenericRepo<StoreItem>, IStoreItemsRepo
    {
        #region Fields
        private readonly StockDbContext _context;
        #endregion

        #region Ctor
        public StoreItemsRepo(StockDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<StoreItem> GetByStoreIdAndItemId(Guid storeId, Guid itemId)
        {
            var storeItem = await _context.StoreItems
                .Where(s => s.StoreId == storeId && s.ItemId == itemId)
                .FirstOrDefaultAsync();

            return storeItem;
        }
        #endregion
    }
}
