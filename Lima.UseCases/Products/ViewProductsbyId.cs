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
    public class ViewProductsbyId : IViewProductsbyId
    {
        private readonly IProductRepository productRepository;

        public ViewProductsbyId(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<Product> ExecuteAsync(int productId)
        {
            return await productRepository.GetProductbyIdAsync(productId);
        }
    }
}
