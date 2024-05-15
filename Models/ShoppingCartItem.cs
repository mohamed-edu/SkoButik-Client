using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkoButik_Client.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemId { get; set; }

        [ForeignKey("Product")]
        public int FkProductId { get; set; }
        public Product? Product { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
