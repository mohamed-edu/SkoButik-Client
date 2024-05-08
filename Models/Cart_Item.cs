using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkoButik_Client.Models
{
    public class Cart_Item
    {
        [Key]
        public int Cart_ItemId { get; set; }

        public int Cart_Item_Quantity { get; set; }

        public DateTime Cart_Item_StartDate { get; set; }
        public DateTime Cart_Item_EndDate { get; set; }

        [ForeignKey("Shopping_Session")]
        public int Shopping_SessionId { get; set; }
        public Shopping_Session? Shopping_Session { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
