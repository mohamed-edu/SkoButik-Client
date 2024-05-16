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
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Brand).Include(p => p.Size);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Size)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Sizes = new SelectList(_context.Sizes, "SizeId", "SizeName", product.FkSizeId);

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            // Create a new instance of the Product class
            var product = new Product();

            // Set a default image URL
            product.ImageUrl = "/images/default-image.jpg"; // Replace with your default image URL

            // Populate ViewData for dropdown lists
            ViewData["FkBrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName");
            ViewData["FkSizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeName");

            // Pass the product model to the view
            return View(product);
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Description,ImageUrl,Price,FkSizeId,FkBrandId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkBrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", product.FkBrandId);
            ViewData["FkSizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeName", product.FkSizeId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["FkBrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", product.FkBrandId);
            ViewData["FkSizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeName", product.FkSizeId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Description,ImageUrl,Price,FkSizeId,FkBrandId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["FkBrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", product.FkBrandId);
            ViewData["FkSizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeName", product.FkSizeId);
            return View(product);
        }


        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Size)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        // this is for seach bar
        public async Task<IActionResult> SearchProduct(string searchString)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'MvcProductContext.Products' is null.");
            }

            var search = from m in _context.Products select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                search = search.Where(s => s.ProductName.Contains(searchString) || s.Description.Contains(searchString));
            }

            return View(await search.ToListAsync());
        }
    }
}
