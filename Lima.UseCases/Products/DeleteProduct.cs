using Lima.UseCases.Interfaces;
using Lima.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lima.UseCases.Products
{
    public class DeleteProduct : IDeleteProduct
    {
        private readonly IProductRepository productRepository;

        public DeleteProduct(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task ExecuteAsync(int productId)
        {
            await productRepository.DeleteProductAsync(productId);
        }
    }
}
