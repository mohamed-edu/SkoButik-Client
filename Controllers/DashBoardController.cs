using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkoButik_Client.Data;
using SkoButik_Client.Models;

namespace SkoButik_Client.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashBoardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> DashBoard()
        {
            // Fetch all OrderItems
            List<OrderItem> getAll = await _context.OrderItems.ToListAsync();

            // Calculate the total income
            decimal CountIncome = getAll.Sum(j => j.Price);

            // Set the formatted income as a ViewBag property (if needed for display)
            ViewBag.CountIncome = CountIncome.ToString("C0");

            // Pass the raw income to the view

            var purchasesData = await _context.OrderItems
                .GroupBy(oi => oi.Orders.OrderDate)
                .Select(g => new
                {
                    Date = g.Key,
                    TotalAmount = g.Sum(oi => oi.Amount)
                })
                .OrderBy(d => d.Date)
                .ToListAsync();

            var dates = purchasesData.Select(d => d.Date.ToString("yyyy-MM-dd")).ToList();
            var amounts = purchasesData.Select(d => d.TotalAmount).ToList();

            ViewBag.Dates = dates;
            ViewBag.Amounts = amounts;


            return View();
        }
    }

}
