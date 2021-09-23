using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class VacancyFormsController : Controller
    {
        private readonly PremiumDbContext _context;

        public VacancyFormsController(PremiumDbContext context)
        {
            _context = context;
        }

        // GET: Admin/VacancyForms
        public async Task<IActionResult> Index()
        {
            var premiumDbContext = _context.VacancyForms.Include(v => v.Vacancy);
            return View(await premiumDbContext.ToListAsync());
        }

        // GET: Admin/VacancyForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancyForm = await _context.VacancyForms
                .Include(v => v.Vacancy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancyForm == null)
            {
                return NotFound();
            }

            return View(vacancyForm);
        }

        // GET: Admin/VacancyForms/Create
        public IActionResult Create()
        {
            ViewData["VacancyId"] = new SelectList(_context.Vacancies, "Id", "Id");
            return View();
        }

        // POST: Admin/VacancyForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,VacancyId,Surname,Telephone,Text,File")] VacancyForm vacancyForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacancyForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VacancyId"] = new SelectList(_context.Vacancies, "Id", "Id", vacancyForm.VacancyId);
            return View(vacancyForm);
        }

        // GET: Admin/VacancyForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancyForm = await _context.VacancyForms.FindAsync(id);
            if (vacancyForm == null)
            {
                return NotFound();
            }
            ViewData["VacancyId"] = new SelectList(_context.Vacancies, "Id", "Id", vacancyForm.VacancyId);
            return View(vacancyForm);
        }

        // POST: Admin/VacancyForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,VacancyId,Surname,Telephone,Text,File")] VacancyForm vacancyForm)
        {
            if (id != vacancyForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacancyForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyFormExists(vacancyForm.Id))
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
            ViewData["VacancyId"] = new SelectList(_context.Vacancies, "Id", "Id", vacancyForm.VacancyId);
            return View(vacancyForm);
        }

        // GET: Admin/VacancyForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancyForm = await _context.VacancyForms
                .Include(v => v.Vacancy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancyForm == null)
            {
                return NotFound();
            }

            return View(vacancyForm);
        }

        // POST: Admin/VacancyForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacancyForm = await _context.VacancyForms.FindAsync(id);
            _context.VacancyForms.Remove(vacancyForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacancyFormExists(int id)
        {
            return _context.VacancyForms.Any(e => e.Id == id);
        }
    }
}
