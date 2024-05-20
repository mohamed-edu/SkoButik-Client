using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkoButik_Client.Models
{
    public class ProductSizeInventory
    {
        [Key]
        public int ProductSizeInventoryId { get; set; }

        [ForeignKey("Product")]
        public int FkProductId { get; set; }
        public Product? Product { get; set; }

        [ForeignKey("Size")]
        public int FkSizeId { get; set; }
        public Size? Size { get; set; }

        public int QuantityInStock { get; set; }
    }
}
