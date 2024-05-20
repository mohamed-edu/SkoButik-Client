﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkoButik_Client.Data;
using SkoButik_Client.Data.Cart;
using SkoButik_Client.Models;

namespace SkoButik_Client.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Brand).Include(p => p.Size).Include(p => p.Campaign);
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

        // POST: Products/UpdateProductSize
        [HttpPost]
        public async Task<IActionResult> UpdateProductSize(int productId, int sizeId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            product.FkSizeId = sizeId;

            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
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
            ViewData["FkCampaignId"] = new SelectList(_context.Campaigns, "CampaignId", "CampaignName", product.FkCampaignId);

            // Pass the product model to the view
            return View(product);
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Description,ImageUrl,Price,FkSizeId,FkBrandId,FkCampaignId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkBrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", product.FkBrandId);
            ViewData["FkSizeId"] = new SelectList(_context.Sizes, "SizeId", "SizeName", product.FkSizeId);
            ViewData["FkCampaignId"] = new SelectList(_context.Campaigns, "CampaignId", "CampaignName", product.FkCampaignId);
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
            ViewData["FkCampaignId"] = new SelectList(_context.Campaigns, "CampaignId", "CampaignName", product.FkCampaignId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Description,ImageUrl,Price,FkSizeId,FkBrandId, FkCampaignId")] Product product)
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
            ViewData["FkCampaignId"] = new SelectList(_context.Campaigns, "CampaignId", "CampaignName", product.FkCampaignId);
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
                .Include(p => p.Campaign)
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
            if (_context.Products?.Any() != true)
            {
                return Problem("Entity set 'MvcProductContext.Products' is null or empty.");
            }

            var search = from m in _context.Products select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                var terms = searchString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (terms.Length == 1)
                {
                    // Search by name or description
                    search = search.Where(s =>
                        s.ProductName.Contains(terms[0]) ||
                        s.Description.Contains(terms[0]));
                }
                else if (terms.Length == 2)
                {
                    // Search by name or description and size
                    search = search.Where(s =>
                        (s.ProductName.Contains(terms[0]) || s.Description.Contains(terms[0])) &&
                        s.Size.SizeName.Contains(terms[1]));
                }
            }

            var productList = await search.ToListAsync();
            return View(productList);
        }


        //GetStockStatus
        public async Task<IActionResult> GetStockStatus(int productId, int sizeId)
        {
            var inventory = await _context.ProductSizeInventories
                .FirstOrDefaultAsync(i => i.FkProductId == productId && i.FkSizeId == sizeId);

            if (inventory == null)
            {
                return Json(new { stockMessage = "Size not found", stockLevel = "none" });
            }

            string stockMessage;
            string stockLevel;

            if (inventory.QuantityInStock >= 3)
            {
                stockMessage = "Several in stock";
                stockLevel = "high";
            }
            else if (inventory.QuantityInStock == 1 || inventory.QuantityInStock == 2)
            {
                stockMessage = "Few left";
                stockLevel = "medium";
            }
            else
            {
                stockMessage = "Out of stock";
                stockLevel = "low";
            }

            return Json(new { stockMessage, stockLevel });
        }
    }
}
