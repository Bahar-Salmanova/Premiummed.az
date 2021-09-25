using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremiumMedStore.Data;
using PremiumMedStore.Filters;
using PremiumMedStore.Helpers;
using PremiumMedStore.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Areas.Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly PremiumDbContext _context;
        private readonly IFileManager _fileManager;

        public ProductsController(PremiumDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Upload,Upload1,Upload2,Upload3,ProductAbout,FullAbout,ProductLink")] Products products)
        {
            if (products.Upload == null)
            {
                ModelState.AddModelError("Uploads", "The Photo field is required.");
            }
            if (products.Upload1 == null)
            {
                ModelState.AddModelError("Uploads", "The Photo field is required.");
            }
            if (products.Upload2 == null)
            {
                ModelState.AddModelError("Uploads", "The Photo field is required.");
            }
            if (products.Upload3 == null)
            {
                ModelState.AddModelError("Uploads", "The Photo field is required.");
            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(products.Upload, "wwwroot/uploads");
                products.Photo = fileName;

                var fileName1 = _fileManager.Upload(products.Upload1, "wwwroot/uploads");
                products.Photo1 = fileName1;

                var fileName2 = _fileManager.Upload(products.Upload2, "wwwroot/uploads");
                products.Photo2 = fileName2;

                var fileName3 = _fileManager.Upload(products.Upload3, "wwwroot/uploads");
                products.Photo3 = fileName3;

                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Photo,Upload,Upload1,Upload2,Upload3,Photo1,Photo2,Photo3,ProductAbout,FullAbout,ProductLink")] Products products)
        {
           
            if (id != products.Id)
            {
                return NotFound();
            }
           
            if (ModelState.IsValid)
            {
                try
                {
                    if (products.Upload != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", products.Photo);
                        if (System.IO.File.Exists(oldFile))
                        {
                            _fileManager.Delete(oldFile);
                        }

                        var fileName = _fileManager.Upload(products.Upload, "wwwroot/uploads");
                        products.Photo = fileName;


                    }
                    if (products.Upload1 != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", products.Photo1);
                        if (System.IO.File.Exists(oldFile))
                        {
                            _fileManager.Delete(oldFile);
                        }

                        var fileName = _fileManager.Upload(products.Upload1, "wwwroot/uploads");
                        products.Photo1 = fileName;


                    }
                    if (products.Upload2 != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", products.Photo2);
                        if (System.IO.File.Exists(oldFile))
                        {
                            _fileManager.Delete(oldFile);
                        }

                        var fileName = _fileManager.Upload(products.Upload2, "wwwroot/uploads");
                        products.Photo2 = fileName;


                    }
                    if (products.Upload3 != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", products.Photo3);
                        if (System.IO.File.Exists(oldFile))
                        {
                            _fileManager.Delete(oldFile);
                        }

                        var fileName = _fileManager.Upload(products.Upload3, "wwwroot/uploads");
                        products.Photo3 = fileName;


                    }
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(products.Id))
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
            return View(products);
        }

        private bool NewsExists(int id)
        {
            throw new NotImplementedException();
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
