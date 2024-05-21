using SkoButik_Client.Data.Cart;
using SkoButik_Client.Models;

namespace SkoButik_Client.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart? ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        public decimal AdjustedPrice { get; set; }
    }
}
