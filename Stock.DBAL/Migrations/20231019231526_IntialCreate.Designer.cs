﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stock.DBAL.Context;

#nullable disable

namespace Stock.DBAL.Migrations
{
    [DbContext(typeof(StockDbContext))]
    [Migration("20231019231526_IntialCreate")]
    partial class IntialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Stock.DBAL.Models.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("ItemId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("StoreId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("StoreId");

                    b.ToTable("Invoices", (string)null);
                });

            modelBuilder.Entity("Stock.DBAL.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("TotalBalance")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items", (string)null);
                });

            modelBuilder.Entity("Stock.DBAL.Models.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("Stores", (string)null);
                });

            modelBuilder.Entity("Stock.DBAL.Models.StoreItem", b =>
                {
                    b.Property<Guid>("StoreId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableBalance")
                        .HasColumnType("int");

                    b.HasKey("StoreId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("StoreItems", (string)null);
                });

            modelBuilder.Entity("Stock.DBAL.Models.Invoice", b =>
                {
                    b.HasOne("Stock.DBAL.Models.Item", "Item")
                        .WithMany("Invoices")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stock.DBAL.Models.Store", "Store")
                        .WithMany("Invoices")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Stock.DBAL.Models.StoreItem", b =>
                {
                    b.HasOne("Stock.DBAL.Models.Item", "Item")
                        .WithMany("StoreItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stock.DBAL.Models.Store", "Store")
                        .WithMany("StoreItems")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Stock.DBAL.Models.Item", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("StoreItems");
                });

            modelBuilder.Entity("Stock.DBAL.Models.Store", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("StoreItems");
                });
#pragma warning restore 612, 618
        }
    }
}
