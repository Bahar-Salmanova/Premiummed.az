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
    public class GaleriesController : Controller
    {
        private readonly PremiumDbContext _context;

        public GaleriesController(PremiumDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Galeries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Galeries.ToListAsync());
        }

        // GET: Admin/Galeries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galery = await _context.Galeries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (galery == null)
            {
                return NotFound();
            }

            return View(galery);
        }

        // GET: Admin/Galeries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Galeries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Photo,Photo1,Photo2")] Galery galery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(galery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(galery);
        }

        // GET: Admin/Galeries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galery = await _context.Galeries.FindAsync(id);
            if (galery == null)
            {
                return NotFound();
            }
            return View(galery);
        }

        // POST: Admin/Galeries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Photo,Photo1,Photo2")] Galery galery)
        {
            if (id != galery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(galery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GaleryExists(galery.Id))
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
            return View(galery);
        }

        // GET: Admin/Galeries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galery = await _context.Galeries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (galery == null)
            {
                return NotFound();
            }

            return View(galery);
        }

        // POST: Admin/Galeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var galery = await _context.Galeries.FindAsync(id);
            _context.Galeries.Remove(galery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GaleryExists(int id)
        {
            return _context.Galeries.Any(e => e.Id == id);
        }
    }
}
