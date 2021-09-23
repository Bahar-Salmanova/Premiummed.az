using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremiumMedStore.Data;
using PremiumMedStore.Filters;
using PremiumMedStore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Areas.Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    [Area("Admin")]
    public class SettingsController : Controller
    {
        private readonly PremiumDbContext _context;

        public SettingsController(PremiumDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Settings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Settings.ToListAsync());
        }

        // GET: Admin/Settings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settings = await _context.Settings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (settings == null)
            {
                return NotFound();
            }

            return View(settings);
        }

        // GET: Admin/Settings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Settings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Telephone,Telephone2,Adress,Email,Logo")] Settings settings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(settings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(settings);
        }

        // GET: Admin/Settings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settings = await _context.Settings.FindAsync(id);
            if (settings == null)
            {
                return NotFound();
            }
            return View(settings);
        }

        // POST: Admin/Settings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Telephone,Telephone2,Adress,Email,Logo")] Settings settings)
        {
            if (id != settings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(settings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettingsExists(settings.Id))
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
            return View(settings);
        }

        // GET: Admin/Settings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settings = await _context.Settings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (settings == null)
            {
                return NotFound();
            }

            return View(settings);
        }

        // POST: Admin/Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var settings = await _context.Settings.FindAsync(id);
            _context.Settings.Remove(settings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SettingsExists(int id)
        {
            return _context.Settings.Any(e => e.Id == id);
        }
    }
}
