using Microsoft.EntityFrameworkCore;
using SkoButik_Client.Models;

namespace SkoButik_Client.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext _context;
        public OrdersService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _context.Orders
                .Include(n => n.OrderItems)
                .ThenInclude(n => n.Products)
                .Where(n => n.UserId == userId)
                .ToListAsync();

            return orders;
        }

        public async Task storeOrderAsync(List<ShoppingCartItem> items, string userId)
        {
            var order = new Order()
            {
                UserId = userId,
 

            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    FkProductId = item.Product.ProductId,
                    FkOrderId = order.OrderId,
                    Price = item.Product.Price

                };
                _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
    
}
