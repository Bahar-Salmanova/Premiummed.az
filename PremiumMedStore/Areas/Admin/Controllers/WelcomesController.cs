using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PremiumMedStore.Data;
using PremiumMedStore.Models;

namespace PremiumMedStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WelcomesController : Controller
    {
        private readonly PremiumDbContext _context;

        public WelcomesController(PremiumDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Welcomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Welcomes.ToListAsync());
        }

        // GET: Admin/Welcomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welcome = await _context.Welcomes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (welcome == null)
            {
                return NotFound();
            }

            return View(welcome);
        }

        // GET: Admin/Welcomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Welcomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,About,Description")] Welcome welcome)
        {
            if (ModelState.IsValid)
            {
                _context.Add(welcome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(welcome);
        }

        // GET: Admin/Welcomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welcome = await _context.Welcomes.FindAsync(id);
            if (welcome == null)
            {
                return NotFound();
            }
            return View(welcome);
        }

        // POST: Admin/Welcomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,About,Description")] Welcome welcome)
        {
            if (id != welcome.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(welcome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WelcomeExists(welcome.Id))
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
            return View(welcome);
        }

        // GET: Admin/Welcomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welcome = await _context.Welcomes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (welcome == null)
            {
                return NotFound();
            }

            return View(welcome);
        }

        // POST: Admin/Welcomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var welcome = await _context.Welcomes.FindAsync(id);
            _context.Welcomes.Remove(welcome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WelcomeExists(int id)
        {
            return _context.Welcomes.Any(e => e.Id == id);
        }
    }
}
