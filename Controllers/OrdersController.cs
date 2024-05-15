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
            // Get the current user's id
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Call the service method with the userId
            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);

            return View(orders.ToList());
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
