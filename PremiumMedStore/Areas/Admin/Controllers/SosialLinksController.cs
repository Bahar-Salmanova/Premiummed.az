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
    public class SosialLinksController : Controller
    {
        private readonly PremiumDbContext _context;

        public SosialLinksController(PremiumDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SosialLinks
        public async Task<IActionResult> Index()
        {
            return View(await _context.SosialLinks.ToListAsync());
        }

        // GET: Admin/SosialLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sosialLinks = await _context.SosialLinks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sosialLinks == null)
            {
                return NotFound();
            }

            return View(sosialLinks);
        }

        // GET: Admin/SosialLinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/SosialLinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Url")] SosialLinks sosialLinks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sosialLinks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sosialLinks);
        }

        // GET: Admin/SosialLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sosialLinks = await _context.SosialLinks.FindAsync(id);
            if (sosialLinks == null)
            {
                return NotFound();
            }
            return View(sosialLinks);
        }

        // POST: Admin/SosialLinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Url")] SosialLinks sosialLinks)
        {
            if (id != sosialLinks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sosialLinks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SosialLinksExists(sosialLinks.Id))
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
            return View(sosialLinks);
        }

        // GET: Admin/SosialLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sosialLinks = await _context.SosialLinks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sosialLinks == null)
            {
                return NotFound();
            }

            return View(sosialLinks);
        }

        // POST: Admin/SosialLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sosialLinks = await _context.SosialLinks.FindAsync(id);
            _context.SosialLinks.Remove(sosialLinks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SosialLinksExists(int id)
        {
            return _context.SosialLinks.Any(e => e.Id == id);
        }
    }
}
