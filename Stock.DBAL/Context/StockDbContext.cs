using Microsoft.EntityFrameworkCore;
using Stock.DBAL.Models;

namespace Stock.DBAL.Context
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>(a =>
            {
                #region Properties Configuration 
                a.ToTable("Stores");

                a.Property(x => x.Id)
                    .HasMaxLength(50)
                    .IsRequired();

                a.Property(x => x.Name)
                    .HasMaxLength(120)
                    .IsRequired();

                a.Property(x => x.Address)
                    .HasMaxLength(1000)
                    .HasDefaultValue(null);

                a.Property(x => x.MobileNumber)
                    .HasMaxLength(15)
                    .HasDefaultValue(null);
                #endregion
            });

            modelBuilder.Entity<Item>(a =>
            {
                #region Properties Configuration 
                a.ToTable("Items");

                a.Property(x => x.Id)
                    .HasMaxLength(50)
                    .IsRequired();

                a.Property(x => x.Name)
                    .HasMaxLength(120)
                    .IsRequired();

                a.Property(x => x.TotalBalance)
                    .IsRequired();
                #endregion
            });

            modelBuilder.Entity<Invoice>(a =>
            {
                #region Properties Configuration 
                a.ToTable("Invoices");

                a.Property(x => x.Id)
                    .HasMaxLength(50)
                    .IsRequired();

                a.Property(x => x.InvoiceNumber)
                    .HasMaxLength(50)
                    .IsRequired();

                a.Property(x => x.Date)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("GETDATE()")
                    .IsRequired();

                a.Property(x => x.StoreId)
                    .HasMaxLength(50)
                    .IsRequired();

                a.Property(x => x.ItemId)
                    .HasMaxLength(50)
                    .IsRequired();

                a.Property(x => x.Quantity)
                    .IsRequired();
                #endregion

                #region Relations Configuration
                a
                .HasOne(c => c.Store)
                .WithMany(u => u.Invoices)
                .HasForeignKey(c => c.StoreId);

                a
                .HasOne(c => c.Item)
                .WithMany(u => u.Invoices)
                .HasForeignKey(c => c.ItemId);
                #endregion
            });

            modelBuilder.Entity<StoreItem>(a =>
            {
                #region Properties Configuration 
                a.ToTable("StoreItems");

                a.Property(x => x.StoreId)
                    .HasMaxLength(50)
                    .IsRequired();

                a.Property(x => x.ItemId)
                    .HasMaxLength(50)
                    .IsRequired();

                a.Property(x => x.AvailableBalance)
                    .IsRequired();
                #endregion

                #region Primary Key Configuration
                a.HasKey(x => new { x.StoreId, x.ItemId });
                #endregion

                #region Relations Configuration
                a
                .HasOne(c => c.Store)
                .WithMany(u => u.StoreItems)
                .HasForeignKey(c => c.StoreId);

                a
                .HasOne(c => c.Item)
                .WithMany(u => u.StoreItems)
                .HasForeignKey(c => c.ItemId);
                #endregion
            });
        }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<StoreItem> StoreItems { get; set; }
    }
}
