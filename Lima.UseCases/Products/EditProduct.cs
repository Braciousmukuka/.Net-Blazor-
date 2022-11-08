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
    public class EditProduct : IEditProduct
    {
        private readonly IProductRepository productRepository;

        public EditProduct(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task ExecuteAsync(Product product)
        {
            await productRepository.UpdateProductAsync(product);
        }
    }
}
