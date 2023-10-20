using Microsoft.EntityFrameworkCore;
using Stock.BL;
using Stock.BL.Invoices.Manager;
using Stock.BL.Items.Manager;
using Stock.BL.Stores.Manager;
using Stock.DBAL.Context;
using Stock.DBAL.Repositories.Invoices_Repo;
using Stock.DBAL.Repositories.Items_Repo;
using Stock.DBAL.Repositories.StoreItems_Repo;
using Stock.DBAL.Repositories.Stores_Repo;

namespace StockApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Services

            #region Controllers
            builder.Services.AddControllersWithViews();
            #endregion

            #region Context
            var connectionString = builder.Configuration.GetConnectionString("StockDb");
            builder.Services.AddDbContext<StockDbContext>(options => options.UseSqlServer(connectionString));
            #endregion

            #region DPI
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            #region Store
            builder.Services.AddScoped<IStoresRepo, StoresRepo>();
            builder.Services.AddScoped<IStoresManager, StoresManager>();
            #endregion

            #region Item
            builder.Services.AddScoped<IItemsRepo, ItemsRepo>();
            builder.Services.AddScoped<IItemsManager, ItemsManager>();
            #endregion

            #region Invoice
            builder.Services.AddScoped<IInvoicesRepo, InvoicesRepo>();
            builder.Services.AddScoped<IInvoicesManager, InvoicesManager>();
            #endregion

            #region StoreItem
            builder.Services.AddScoped<IStoreItemsRepo, StoreItemsRepo>();
            #endregion

            #endregion

            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}