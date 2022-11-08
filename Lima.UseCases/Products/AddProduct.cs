using Lima.Businuess;
using Lima.UseCases.Interfaces;
using Lima.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lima.UseCases.Products
{
    public class AddProduct : IAddProduct
    {
        private readonly IProductRepository productInventory;

        public AddProduct(IProductRepository productInventory)
        {
            this.productInventory = productInventory;
        }
        public async Task ExecuteAsync(Product product)
        {
            if (product == null) return;

            await productInventory.AddProductAsync(product);
        }
    }
}
