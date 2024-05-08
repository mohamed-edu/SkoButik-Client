using System.ComponentModel.DataAnnotations;

namespace SkoButik_Client.Models
{
    public class Product_Inventory
    {
        [Key]
        public int Product_InventoryId { get; set; }
        public int Quantity { get; set; }

        public ICollection<Product>? Products { get; set; }

    }
}
