using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkoButik_Client.Data;
using SkoButik_Client.Models;

namespace SkoButik_Client.Controllers
{
    public class ProductSizeInventoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductSizeInventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductSizeInventories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductSizeInventories.Include(p => p.Product).Include(p => p.Size);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductSizeInventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSizeInventory = await _context.ProductSizeInventories
                .Include(p => p.Product)
                .Include(p => p.Size)
                .FirstOrDefaultAsync(m => m.ProductSizeInventoryId == id);
            if (productSizeInventory == null)
            {
                return NotFound();
            }

            return View(productSizeInventory);
        }

        // GET: ProductSizeInventories/Create
        public IActionResult Create()
        {
            ViewData["FkProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            ViewData["FkSizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeName");
            return View();
        }

        // POST: ProductSizeInventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductSizeInventoryId,FkProductId,FkSizeId,QuantityInStock")] ProductSizeInventory productSizeInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productSizeInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", productSizeInventory.FkProductId);
            ViewData["FkSizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeName", productSizeInventory.FkSizeId);
            return View(productSizeInventory);
        }

        // GET: ProductSizeInventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSizeInventory = await _context.ProductSizeInventories.FindAsync(id);
            if (productSizeInventory == null)
            {
                return NotFound();
            }
            ViewData["FkProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", productSizeInventory.FkProductId);
            ViewData["FkSizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeName", productSizeInventory.FkSizeId);
            return View(productSizeInventory);
        }

        // POST: ProductSizeInventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductSizeInventoryId,FkProductId,FkSizeId,QuantityInStock")] ProductSizeInventory productSizeInventory)
        {
            if (id != productSizeInventory.ProductSizeInventoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productSizeInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSizeInventoryExists(productSizeInventory.ProductSizeInventoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", productSizeInventory.FkProductId);
            ViewData["FkSizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeName", productSizeInventory.FkSizeId);
            return View(productSizeInventory);
        }

        // GET: ProductSizeInventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSizeInventory = await _context.ProductSizeInventories
                .Include(p => p.Product)
                .Include(p => p.Size)
                .FirstOrDefaultAsync(m => m.ProductSizeInventoryId == id);
            if (productSizeInventory == null)
            {
                return NotFound();
            }

            return View(productSizeInventory);
        }

        // POST: ProductSizeInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productSizeInventory = await _context.ProductSizeInventories.FindAsync(id);
            if (productSizeInventory != null)
            {
                _context.ProductSizeInventories.Remove(productSizeInventory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSizeInventoryExists(int id)
        {
            return _context.ProductSizeInventories.Any(e => e.ProductSizeInventoryId == id);
        }
    }
}
