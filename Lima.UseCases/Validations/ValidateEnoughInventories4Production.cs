using Lima.Businuess;
using Lima.UseCases.Interfaces;
using Lima.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lima.UseCases.Validations
{
    public class ValidateEnoughInventories4Production : IValidateEnoughInventories4Production
    {
        private readonly IProductRepository productRepository;

        public ValidateEnoughInventories4Production(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<bool> ExecuteAsync(Product product, int quantity)
        {
            var prod = await productRepository.GetProductbyIdAsync(product.ProductId);
            foreach (var pi in prod.productInventories)
            {
                if (pi.InventoryQuantity * quantity > pi.Inventory.Quantity)
                    return false;
            }
            return true;
        }
    }
}
