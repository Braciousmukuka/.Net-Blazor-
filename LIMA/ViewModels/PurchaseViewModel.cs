using Lima.Businuess;
using System.ComponentModel.DataAnnotations;

namespace LIMA.ViewModels
{
    public class PurchaseViewModel
    {
        [Required]
        public string PurchaseOrder { get; set; }

        [Required]
        public int InventoryId { get; set; }

        public string InventoryName { get; set; }

        [Required]
        [Range(minimum:1, maximum:int.MaxValue, ErrorMessage ="Quantity should be greater than 1.")]
        public int QuantityToPurchase { get; set; }

        public double InventoryPrice { get; set; }
    }
}
