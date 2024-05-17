using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkoButik_Client.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        public int QuantityInStock { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        
    }
    
}
