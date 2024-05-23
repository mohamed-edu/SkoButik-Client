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
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.ApplicationUser) // Include ApplicationUser to fetch user details
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Products) // Include Products within OrderItems
                .ThenInclude(oi => oi.Campaign)
                .Include(i => i.OrderItems)
                .ToListAsync();
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId)
        {
            var order = new Order()
            {
                UserId = userId
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var size = await _context.Inventories
                    .Where(i => i.FkProductId == item.Product.ProductId)
                    .Select(i => i.Sizes)
                    .FirstOrDefaultAsync();


                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    FkProductId = item.Product.ProductId,
                    FkOrderId = order.OrderId,
                    Price = item.Product.AdjustedPrice,
                    Sizes = size

                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
    
}
