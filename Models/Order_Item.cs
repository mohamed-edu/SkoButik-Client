using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkoButik_Client.Models
{
    public class Order_Item
    {
        [Key]
        public int Order_ItemId { get; set; }

        [ForeignKey("Order_Detail")]
        public int FkOrder_DetailId { get; set; }
        public Order_Detail? Order_Detail { get; set; }

        [ForeignKey("Product")]
        public int FkProductId { get; set; }
        public Product? Product { get; set; }
    }
}
