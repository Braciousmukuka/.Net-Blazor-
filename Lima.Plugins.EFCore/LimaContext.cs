using Lima.Businuess;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lima.Plugins.EFCore
{
    public class LimaContext : IdentityDbContext
    {
        public LimaContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }    
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<ProductTransaction> ProductTransactions { get; set; }   
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Building Relationships to Products and Inventory 
            modelBuilder.Entity<ProductInventory>().HasKey(pi => new { pi.ProductId, pi.InventoryId });

            modelBuilder.Entity<ProductInventory>().HasOne(pi => pi.Product)
                .WithMany(p => p.productInventories)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductInventory>().HasOne(pi => pi.Inventory)
                .WithMany(i => i.productInventories)
                .HasForeignKey(pi => pi.InventoryId);

            //Seeding Inventory Data
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory {InventoryId=1, InventoryName="Broiler Starter", InventoryType="Food", InventoryDescription="50Kg Bag", Price= 400, Quantity= 1 }
               
                );

            /*modelBuilder.Entity<Product>().HasData(
               new Product { ProductId = 1, ProductName = "Tomato", ProductType = "Veggie", ProductDescription = "Bulk Supply", Price = 350, Quantity = 1 },
               new Product { ProductId = 2, ProductName = "Chicken", ProductType = "Poultry", ProductDescription = "Dressed", Price = 150, Quantity = 2 },
               new Product { ProductId = 3, ProductName = "Malad Duck", ProductType = "Poultry", ProductDescription = "Live", Price = 300, Quantity = 1 }
               );
            
            modelBuilder.Entity<ProductInventory>().HasData(
                new ProductInventory {ProductId = 2, InventoryId=4, InventoryQuantity = 1 } 
                );
            */
            base.OnModelCreating(modelBuilder);
            

        }
    }
}
