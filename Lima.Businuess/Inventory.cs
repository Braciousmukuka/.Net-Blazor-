using System.ComponentModel.DataAnnotations;

namespace Lima.Businuess
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        [Required]
        public string? InventoryName { get; set; }

        public string? InventoryType { get; set; }
        
        public string? InventoryDescription { get; set; }

        [Range(0, int.MaxValue, ErrorMessage ="Quantity must be greater or equal to {0}")]
        public int Quantity { get; set; }
 
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater or equal to {0}")]
        public double Price { get; set; } 
        
        public List<ProductInventory>? productInventories { get; set; }
    }
} 