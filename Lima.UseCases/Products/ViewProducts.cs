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
    public class ViewProducts : IViewProducts
    {
        private readonly IProductRepository productRepository;

        public ViewProducts(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<Product>> ExecuteAsync(string name = "")
        {
            return await productRepository.GetProductsAsync(name);
        }
    }
}
