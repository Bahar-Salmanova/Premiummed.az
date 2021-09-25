using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
    public class IndexProductsController : Controller
    {
        private readonly PremiumDbContext _context;
        private readonly IFileManager _fileManager;

        public IndexProductsController(PremiumDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
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
        public async Task<IActionResult> Create([Bind("Id,Title,Desc,Upload1,Upload2,Upload3")] IndexProduct indexProduct)
        {
            if (indexProduct.Upload1 == null)
            {
                ModelState.AddModelError("Uploads", "The Photo field is required.");
            }
            if (indexProduct.Upload2 == null)
            {
                ModelState.AddModelError("Uploads", "The Photo field is required.");
            }
            if (indexProduct.Upload3 == null)
            {
                ModelState.AddModelError("Uploads", "The Photo field is required.");
            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(indexProduct.Upload1, "wwwroot/uploads");
                indexProduct.Photo1 = fileName;

                var fileName1 = _fileManager.Upload(indexProduct.Upload2, "wwwroot/uploads");
                indexProduct.Photo2 = fileName1;

                var fileName2 = _fileManager.Upload(indexProduct.Upload3, "wwwroot/uploads");
                indexProduct.Photo3 = fileName2;
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Desc,Photo1,Photo2,Photo3,Upload1,Upload2,Upload3")] IndexProduct indexProduct)
        {
            if (id != indexProduct.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    if (indexProduct.Upload1 != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", indexProduct.Photo1);
                        _fileManager.Delete(oldFile);

                        var fileName = _fileManager.Upload(indexProduct.Upload1, "wwwroot/uploads");
                        indexProduct.Photo1 = fileName;


                    }
                    if (indexProduct.Upload2 != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", indexProduct.Photo2);
                        _fileManager.Delete(oldFile);

                        var fileName = _fileManager.Upload(indexProduct.Upload2, "wwwroot/uploads");
                        indexProduct.Photo2 = fileName;


                    }
                    if (indexProduct.Upload3 != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", indexProduct.Photo3);
                        _fileManager.Delete(oldFile);

                        var fileName = _fileManager.Upload(indexProduct.Upload3, "wwwroot/uploads");
                        indexProduct.Photo3 = fileName;


                    }
                    _context.Update(indexProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(indexProduct.Id))
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

        private bool NewsExists(int id)
        {
            throw new NotImplementedException();
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
