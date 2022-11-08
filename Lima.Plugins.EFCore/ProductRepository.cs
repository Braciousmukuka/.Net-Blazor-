using Lima.Businuess;
using Lima.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lima.Plugins.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly LimaContext db;

        public ProductRepository(LimaContext db)
        {
            this.db = db;
        }

        public async Task AddProductAsync(Product product)
        {
          //  if (db.Products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase))) return;
            if (db.Products.Any(x => x.ProductName.ToLower() == product.ProductName.ToLower())) return;

            db.Products.Add(product);
            await db.SaveChangesAsync();    

        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await db.Products.FindAsync(productId);
            if (product != null)
            {
                product.IsActive = false;
                await db.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProductbyIdAsync(int productId)
        {
            return await db.Products.Include(x => x.productInventories)
                .ThenInclude(x => x.Inventory)
                .FirstOrDefaultAsync(x => x.ProductId == productId);
        }

        public async Task<List<Product>> GetProductsAsync(string name)
        {
            return await this.db.Products.Where(x => (x.ProductName.ToLower().IndexOf(name.ToLower()) >= 0 ||
                                                      string.IsNullOrWhiteSpace(name)) &&
                                                      x.IsActive == true).ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            //prevents Entering same name
           if (db.Products.Any(x => x.ProductName.ToLower() == product.ProductName.ToLower())) return;

            var prod = await db.Products.FindAsync(product.ProductId);
            if(prod != null)
            {
                prod.ProductName = product.ProductName;
                prod.ProductType = product.ProductType;
                prod.ProductDescription = product.ProductDescription;
                prod.Quantity = product.Quantity;
                prod.Price = product.Price;
                prod.productInventories = product.productInventories;

                await db.SaveChangesAsync();
            }
        }
    }
}
