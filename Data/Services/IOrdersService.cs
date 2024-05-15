using SkoButik_Client.Models;

namespace SkoButik_Client.Data.Services
{
    public interface IOrdersService
    {
        Task storeOrderAsync(List<ShoppingCartItem> items, string userId);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);

    }
}
