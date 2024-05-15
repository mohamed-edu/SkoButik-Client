using SkoButik_Client.Data.Cart;

namespace SkoButik_Client.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart? ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
