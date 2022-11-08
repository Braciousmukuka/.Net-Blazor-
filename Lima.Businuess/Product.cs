using Lima.Businuess.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lima.Businuess
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; } = string.Empty;

        public string ProductType { get; set; }

        public string ProductDescription { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to {0}")]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater or equal to {0}")]

        [Products2Inventories]
        public double Price { get; set; }

        public bool IsActive { get; set; } = true;

        public List<ProductInventory>? productInventories { get; set; }

        public double TotalInventoryCost()
        {
            return this.productInventories.Sum(x => x.Inventory?.Price * x.InventoryQuantity ?? 0);
        }

        public bool ValidatePricing()
        {
            if(productInventories == null || productInventories.Count <= 0 ) return true;
            
            if(this.TotalInventoryCost() > Price) return false;    

            return true;
        }

    }
}
