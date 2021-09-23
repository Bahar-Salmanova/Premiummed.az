using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PremiumMedStore.Data;
using PremiumMedStore.Filters;
using PremiumMedStore.Models;

namespace PremiumMedStore.Areas.Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    [Area("Admin")]
    public class ProductOrdersController : Controller
    {
        private readonly PremiumDbContext _context;

        public ProductOrdersController(PremiumDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ProductOrders
        public async Task<IActionResult> Index()
        {
            var premiumDbContext = _context.ProductOrders.Include(p => p.Product);
            return View(await premiumDbContext.ToListAsync());
        }

        // GET: Admin/ProductOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productOrder = await _context.ProductOrders
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productOrder == null)
            {
                return NotFound();
            }

            return View(productOrder);
        }

        // GET: Admin/ProductOrders/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Photo1");
            return View();
        }

        // POST: Admin/ProductOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Telephone,Adres,Message,ProductId")] ProductOrder productOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Photo1", productOrder.ProductId);
            return View(productOrder);
        }

        // GET: Admin/ProductOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productOrder = await _context.ProductOrders.FindAsync(id);
            if (productOrder == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Photo1", productOrder.ProductId);
            return View(productOrder);
        }

        // POST: Admin/ProductOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Telephone,Adres,Message,ProductId")] ProductOrder productOrder)
        {
            if (id != productOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductOrderExists(productOrder.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Photo1", productOrder.ProductId);
            return View(productOrder);
        }

        // GET: Admin/ProductOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productOrder = await _context.ProductOrders
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productOrder == null)
            {
                return NotFound();
            }

            return View(productOrder);
        }

        // POST: Admin/ProductOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productOrder = await _context.ProductOrders.FindAsync(id);
            _context.ProductOrders.Remove(productOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductOrderExists(int id)
        {
            return _context.ProductOrders.Any(e => e.Id == id);
        }
    }
}
