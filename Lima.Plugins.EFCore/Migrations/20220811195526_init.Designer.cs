﻿// <auto-generated />
using System;
using Lima.Plugins.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lima.Plugins.EFCore.Migrations
{
    [DbContext(typeof(LimaContext))]
    [Migration("20220811195526_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Lima.Businuess.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventoryId"), 1L, 1);

                    b.Property<string>("InventoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventoryType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventories");

                    b.HasData(
                        new
                        {
                            InventoryId = 1,
                            InventoryDescription = "50Kg Bag",
                            InventoryName = "Broiler Starter",
                            InventoryType = "Food",
                            Price = 400.0,
                            Quantity = 1
                        },
                        new
                        {
                            InventoryId = 2,
                            InventoryDescription = " First Vaccination",
                            InventoryName = "New Caastle",
                            InventoryType = "Medicine",
                            Price = 100.0,
                            Quantity = 1
                        },
                        new
                        {
                            InventoryId = 3,
                            InventoryDescription = "Point of Sale",
                            InventoryName = "Malad Duck",
                            InventoryType = "Poultry",
                            Price = 250.0,
                            Quantity = 1
                        },
                        new
                        {
                            InventoryId = 4,
                            InventoryDescription = "Point of Lay",
                            InventoryName = "Bantam Chicken",
                            InventoryType = "Poultry",
                            Price = 250.0,
                            Quantity = 2
                        },
                        new
                        {
                            InventoryId = 5,
                            InventoryDescription = "Tomato Seed",
                            InventoryName = "C48 Tomato",
                            InventoryType = "Input",
                            Price = 1000.0,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("Lima.Businuess.InventoryTransaction", b =>
                {
                    b.Property<int>("InventoryTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventoryTransactionId"), 1L, 1);

                    b.Property<int>("ActivityType")
                        .HasColumnType("int");

                    b.Property<string>("DoneBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<string>("PONumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityAfter")
                        .HasColumnType("int");

                    b.Property<int>("QuantityBefore")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("InventoryTransactionId");

                    b.HasIndex("InventoryId");

                    b.ToTable("InventoryTransactions");
                });

            modelBuilder.Entity("Lima.Businuess.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            IsActive = true,
                            Price = 350.0,
                            ProductDescription = "Bulk Supply",
                            ProductName = "Tomato",
                            ProductType = "Veggie",
                            Quantity = 1
                        },
                        new
                        {
                            ProductId = 2,
                            IsActive = true,
                            Price = 150.0,
                            ProductDescription = "Dressed",
                            ProductName = "Chicken",
                            ProductType = "Poultry",
                            Quantity = 2
                        },
                        new
                        {
                            ProductId = 3,
                            IsActive = true,
                            Price = 300.0,
                            ProductDescription = "Live",
                            ProductName = "Malad Duck",
                            ProductType = "Poultry",
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("Lima.Businuess.ProductInventory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int>("InventoryQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "InventoryId");

                    b.HasIndex("InventoryId");

                    b.ToTable("ProductInventory");

                    b.HasData(
                        new
                        {
                            ProductId = 2,
                            InventoryId = 4,
                            InventoryQuantity = 1
                        });
                });

            modelBuilder.Entity("Lima.Businuess.ProductTransaction", b =>
                {
                    b.Property<int>("ProductTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductTransactionId"), 1L, 1);

                    b.Property<int>("ActivityType")
                        .HasColumnType("int");

                    b.Property<string>("DoneBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityAfter")
                        .HasColumnType("int");

                    b.Property<int>("QuantityBefore")
                        .HasColumnType("int");

                    b.Property<string>("SalesOrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("ProductTransactionId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductTransactions");
                });

            modelBuilder.Entity("Lima.Businuess.InventoryTransaction", b =>
                {
                    b.HasOne("Lima.Businuess.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("Lima.Businuess.ProductInventory", b =>
                {
                    b.HasOne("Lima.Businuess.Inventory", "Inventory")
                        .WithMany("productInventories")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lima.Businuess.Product", "Product")
                        .WithMany("productInventories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Lima.Businuess.ProductTransaction", b =>
                {
                    b.HasOne("Lima.Businuess.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Lima.Businuess.Inventory", b =>
                {
                    b.Navigation("productInventories");
                });

            modelBuilder.Entity("Lima.Businuess.Product", b =>
                {
                    b.Navigation("productInventories");
                });
#pragma warning restore 612, 618
        }
    }
}