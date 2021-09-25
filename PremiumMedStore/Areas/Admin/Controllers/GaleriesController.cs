using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PremiumMedStore.Data;
using PremiumMedStore.Filters;
using PremiumMedStore.Helpers;
using PremiumMedStore.Models;

namespace PremiumMedStore.Areas.Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    [Area("Admin")]
    public class GaleriesController : Controller
    {
        private readonly PremiumDbContext _context;
        private readonly IFileManager _fileManager;

        public GaleriesController(PremiumDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
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
        public async Task<IActionResult> Create([Bind("Id,Upload1, Upload2, Upload3")] Galery galery)
        {
            if (galery.Upload1 == null)
            {
                ModelState.AddModelError("Uploads", "The Photo field is required.");
            }
            if (galery.Upload2 == null)
            {
                ModelState.AddModelError("Uploads", "The Photo field is required.");
            }
            if (galery.Upload3 == null)
            {
                ModelState.AddModelError("Uploads", "The Photo field is required.");
            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(galery.Upload1, "wwwroot/uploads");
                galery.Photo = fileName;

                var fileName1 = _fileManager.Upload(galery.Upload2, "wwwroot/uploads");
                galery.Photo1 = fileName1;

                var fileName2 = _fileManager.Upload(galery.Upload3, "wwwroot/uploads");
                galery.Photo2 = fileName2;

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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Upload1,Photo,Upload2,Photo1,Upload3,Photo2")] Galery galery)
        {
            if (id != galery.Id)
            {
                return NotFound();
            }
           

            if (ModelState.IsValid)
            {
                try
                {
                    if (galery.Upload1 != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", galery.Photo);
                        _fileManager.Delete(oldFile);

                        if (System.IO.File.Exists(oldFile))
                        {
                            _fileManager.Delete(oldFile);
                        }

                        var fileName = _fileManager.Upload(galery.Upload1, "wwwroot/uploads");
                        galery.Photo = fileName;


                    }
                    if (galery.Upload2 != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", galery.Photo1);
                        _fileManager.Delete(oldFile);

                        if (System.IO.File.Exists(oldFile))
                        {
                            _fileManager.Delete(oldFile);
                        }

                        var fileName = _fileManager.Upload(galery.Upload2, "wwwroot/uploads");
                        galery.Photo1 = fileName;


                    }
                    if (galery.Upload3 != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", galery.Photo2);
                        _fileManager.Delete(oldFile);

                        if (System.IO.File.Exists(oldFile))
                        {
                            _fileManager.Delete(oldFile);
                        };

                        var fileName = _fileManager.Upload(galery.Upload3, "wwwroot/uploads");
                        galery.Photo2 = fileName;


                    }
                    _context.Update(galery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(galery.Id))
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

        private bool NewsExists(int id)
        {
            throw new NotImplementedException();
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
