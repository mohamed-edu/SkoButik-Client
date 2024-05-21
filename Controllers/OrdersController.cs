using Microsoft.AspNetCore.Mvc;
using SkoButik_Client.Data.Cart;
using SkoButik_Client.Data.Services;
using SkoButik_Client.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using SkoButik_Client.Data.ViewModels;
using SkoButik_Client.Models;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SkoButik_Client.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly ApplicationDbContext _context;
        private readonly IOrdersService _ordersService;

        public OrdersController(ShoppingCart shoppingCart, ApplicationDbContext context, IOrdersService ordersService)
        {
            _shoppingCart = shoppingCart;
            _context = context;
            _ordersService = ordersService;
        }


        //SearchFilter
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _context.Products.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allProducts.Where(n =>
                    n.ProductName.ToLower().Contains(searchString.ToLower()) ||
                    n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                return View("Index", filteredResult);
            }

            return View("Index", allProducts);
        }

        ///________________________________________________________________________________

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);

            foreach (var order in orders)
            {
                Console.WriteLine($"OrderID: {order.OrderId}, UserID: {order.UserId}, FirstName: {order.ApplicationUser?.FirstName}");
                Console.WriteLine($"OrderItems Count: {order.OrderItems.Count}");
                foreach (var item in order.OrderItems)
                {
                    Console.WriteLine($"ProductName: {item.Products?.ProductName}, Price: {item.Products?.AdjustedPrice}, Amount: {item.Amount}");
                }
            }

            return View(orders);
        }
    



    //__________________________________________________________________________


    // Shopping Cart
    public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartitems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        //Add item to shopping cart
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);

            if (product != null)
            {
                _shoppingCart.AddItemToCart(product);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        //Remove item from shopping cart
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);

            if (product != null)
            {
                _shoppingCart.RemoveItemFromCart(product);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }



        // CompleteOrder
        public async Task<IActionResult> CompleteOrder()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("NotLoggedIn");
            }
            var items = _shoppingCart.GetShoppingCartItems().ToList();

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _ordersService.storeOrderAsync(items, userId);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");

        }

        // Action for NotLoggedIn view
        public IActionResult NotLoggedIn()
        {
            return View();
        }

        //_______________________________________________________________________

        // OrderStats

        //public IActionResult OrderStats()
        //{
        //    var orderItems = _context.Orders
        //        .Include(o => o.OrderItems)
        //        .ThenInclude(o => o.Products)
        //        .Where(o => o.OrderDate.Date >= DateTime.UtcNow.Date.AddDays(-7))
        //        .SelectMany(o => o.OrderItems)
        //        .ToList();

        //    // Create an instance of the adapter
        //    var adapter = new OrderStatsAdapter(_context);

        //    var orderStats = orderItems
        //        .GroupBy(o => o.Orders?.OrderDate.Date)
        //        .Select(g => new 
        //        {
        //            OrderDate = g.Key,
        //            OrderCount = g.Count(),
        //            TotalSales = adapter.CalculateTotalSales(g.ToList())
        //        })
        //        .OrderByDescending(o => o.OrderDate)
        //        .ToList()
        //     .Select(o => new OrderStatsViewModel
        //      {
        //          OrderDate = (DateTime)o.OrderDate,
        //          OrderCount = o.OrderCount,
        //          TotalSales = o.TotalSales
        //      })
        //        .ToList();

        //    return View(orderStats);
        //}

        public IActionResult OrderStats()
        {
                // Create an instance of the adapter
                var adapter = new OrderStatsAdapter(_context);

            var orderStats = _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Products)
                .ThenInclude(o => o.Campaign)
                .Where(o => o.OrderDate.Date >= DateTime.UtcNow.Date.AddDays(-7)) // Only consider orders from the last 7 days
                .GroupBy(o => o.OrderDate.Date)
                .Select(g => new
                {
                    OrderDate = g.Key,
                    OrderCount = g.Count(),
                    TotalSales = g.SelectMany(o => o.OrderItems).Sum(oi => oi.Amount * oi.Price)
                })
                .OrderByDescending(o => o.OrderDate)
                .ToList()
                .Select(o => new OrderStatsViewModel
                {
                    OrderDate = o.OrderDate,
                    OrderCount = o.OrderCount,
                    TotalSales = o.TotalSales
                })
                .ToList();

            return View(orderStats);
        }

        // MostSold
        public IActionResult MostSold()
        {
            var productStats = _context.OrderItems
                .Include(oi => oi.Products)
                .Where(oi => oi.Orders.OrderDate.Date >= DateTime.UtcNow.Date.AddDays(-7)) // Only consider orders from the last 7 days
                .GroupBy(oi => oi.FkProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    ProductName = g.FirstOrDefault().Products.ProductName,
                    TotalQuantity = g.Sum(oi => oi.Amount),
                    ImageUrl = g.FirstOrDefault().Products.ImageUrl
                })
                .OrderByDescending(p => p.TotalQuantity)
                .FirstOrDefault();

            var mostSoldProduct = productStats != null ? new ProductStatsViewModel
            {
                ProductName = productStats.ProductName,
                TotalQuantity = productStats.TotalQuantity,
                ImageUrl = productStats.ImageUrl,
            } : null;

            return View(mostSoldProduct);
        }

        public async Task<IActionResult> OrderList(string currency = "SEK")
        {
            var orders = await _context.Orders.Include(o => o.OrderItems).ThenInclude(o => o.Products).ThenInclude(o => o.Campaign).ToListAsync();
            decimal exchangeRate = 1.0m;

            if (currency != "SEK")
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync($"https://v6.exchangerate-api.com/v6/6e9a8cd53905eb9043c5f0ec/latest/SEK");
                    var rates = JObject.Parse(response)["conversion_rates"];
                    exchangeRate = rates[currency].Value<decimal>();
                }
            }

            var model = new OrderListViewModel
            {
                Orders = orders,
                SelectedCurrency = currency,
                ExchangeRate = exchangeRate
            };

            return View(model);
        }

        public IActionResult OrderDetails(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Products)
                    .ThenInclude(oi => oi.Campaign)
                .Include(o => o.ApplicationUser)
                .FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            var totalPrice = order.OrderItems.Sum(oi => oi.Amount * oi.Products.AdjustedPrice);

            var model = new OrderDetailsViewModel
            {
                Order = order,
                OrderedBy = order.ApplicationUser,
                TotalPrice = totalPrice
            };

            return View(model);
        }

    }
}
