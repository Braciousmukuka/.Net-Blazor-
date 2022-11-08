﻿using Lima.Businuess;
using Lima.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lima.Plugins.EFCore
{
    public class ProductTransactionRepository : IProductTransactionRepository
    {
        private readonly LimaContext db;
        private readonly IProductRepository productRepository;

        public ProductTransactionRepository(LimaContext db, IProductRepository productRepository)
        {
            this.db = db;
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductTransaction>> GetProductTransactionsAsync(
            string productName,
            DateTime? dateFrom, 
            DateTime? dateTo, 
            ProductTransactionType? transactionType)
        {
            if (dateTo.HasValue) dateTo = dateTo.Value.AddDays(1);
           var query = from pt in db.ProductTransactions
                       join prod in db.Products on pt.ProductId equals prod.ProductId
                       where 
                            (string.IsNullOrWhiteSpace(productName) || prod.ProductName.ToLower().IndexOf(productName.ToLower()) >= 0) &&
                            (!dateFrom.HasValue || pt.TransactionDate >= dateFrom.Value.Date) &&
                            (!dateTo.HasValue || pt.TransactionDate <= dateTo.Value.Date) &&
                            (!transactionType.HasValue || pt.ActivityType == transactionType)
                        select pt;    
            return await query.Include(x => x.Product).ToListAsync();
        }

        public async Task ProduceAsync(string productionNumber, Product product, int quantity, double price, string doneBy)
        {
            //Taking away from Inventories 
            var prod = await this.productRepository.GetProductbyIdAsync(product.ProductId);
            if (prod != null)
            {
                foreach(var pi in prod.productInventories)
                {
                    int qtyBefore = pi.InventoryQuantity;
                    pi.Inventory.Quantity -= quantity * pi.InventoryQuantity;

                    this.db.InventoryTransactions.Add(new InventoryTransaction
                    {
                        ProductionNumber = productionNumber,
                        InventoryId = pi.Inventory.InventoryId,
                        QuantityBefore = qtyBefore,
                        ActivityType = InventoryTransactionType.ProduceProduct,
                        QuantityAfter = pi.Inventory.Quantity,
                        TransactionDate = DateTime.Now,
                        DoneBy = doneBy,
                        UnitPrice = price


                    });
                }
            } 

            this.db.ProductTransactions.Add(new ProductTransaction
            {
                ProductionNumber = productionNumber,    
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                ActivityType = ProductTransactionType.ProduceProduct,
                QuantityAfter = product.Quantity + quantity,    
                TransactionDate = DateTime.Now, 
                DoneBy = doneBy,
                UnitPrice = price,  

            });
            await this.db.SaveChangesAsync();
        }
        public async Task SellProductAsync(string salesOrderNumber, Product product, int quantity, double price, string doneBy)
        {
            this.db.ProductTransactions.Add(new ProductTransaction
            {
                SalesOrderNumber = salesOrderNumber,    
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                ActivityType = ProductTransactionType.SellProduct,
                QuantityAfter = product.Quantity + quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,    
                UnitPrice = price,
            });
            await this.db.SaveChangesAsync();
        }
    }
}
