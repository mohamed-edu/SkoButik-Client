using Microsoft.AspNetCore.Mvc;
using SkoButik_Client.Data.Cart;
using SkoButik_Client.Data.Services;
using SkoButik_Client.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using SkoButik_Client.Data.ViewModels;

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
                    Console.WriteLine($"ProductName: {item.Products?.ProductName}, Price: {item.Price}, Amount: {item.Amount}");
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
            var items = _shoppingCart.GetShoppingCartItems().ToList();

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _ordersService.storeOrderAsync(items, userId);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");

        }
    }
}
