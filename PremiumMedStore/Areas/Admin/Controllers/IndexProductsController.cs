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
    public class IndexProductsController : Controller
    {
        private readonly PremiumDbContext _context;

        public IndexProductsController(PremiumDbContext context)
        {
            _context = context;
        }

        // GET: Admin/IndexProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.IndexProducts.ToListAsync());
        }

        // GET: Admin/IndexProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indexProduct = await _context.IndexProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (indexProduct == null)
            {
                return NotFound();
            }

            return View(indexProduct);
        }

        // GET: Admin/IndexProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/IndexProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Desc,Photo1,Photo2,Photo3")] IndexProduct indexProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(indexProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(indexProduct);
        }

        // GET: Admin/IndexProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indexProduct = await _context.IndexProducts.FindAsync(id);
            if (indexProduct == null)
            {
                return NotFound();
            }
            return View(indexProduct);
        }

        // POST: Admin/IndexProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Desc,Photo1,Photo2,Photo3")] IndexProduct indexProduct)
        {
            if (id != indexProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(indexProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndexProductExists(indexProduct.Id))
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
            return View(indexProduct);
        }

        // GET: Admin/IndexProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indexProduct = await _context.IndexProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (indexProduct == null)
            {
                return NotFound();
            }

            return View(indexProduct);
        }

        // POST: Admin/IndexProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var indexProduct = await _context.IndexProducts.FindAsync(id);
            _context.IndexProducts.Remove(indexProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndexProductExists(int id)
        {
            return _context.IndexProducts.Any(e => e.Id == id);
        }
    }
}
