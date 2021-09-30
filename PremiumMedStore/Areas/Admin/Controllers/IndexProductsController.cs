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
                //photo1//
                IFormFile file = indexProduct.Upload1;
                string filExt = file.FileName[file.FileName.LastIndexOf(".")..];
                DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan diff = DateTime.Now.ToUniversalTime() - origin;
                string fileName = DateTime.Now.Ticks + filExt;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    indexProduct.Upload1.CopyTo(fs);
                }
                indexProduct.Photo1 = fileName;

                //photo2//
                IFormFile file1 = indexProduct.Upload2;
                string filExt1 = file1.FileName[file1.FileName.LastIndexOf(".")..];
                DateTime origin1 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan diff1 = DateTime.Now.ToUniversalTime() - origin1;
                string fileName1 = DateTime.Now.Ticks + filExt1;
                string path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName1);
                using (FileStream fs = new FileStream(path1, FileMode.OpenOrCreate))
                {
                    indexProduct.Upload2.CopyTo(fs);
                }
                indexProduct.Photo2 = fileName1;

                //photo3//
                IFormFile file2 = indexProduct.Upload3;
                string filExt2 = file2.FileName[file2.FileName.LastIndexOf(".")..];
                DateTime origin2 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan diff2 = DateTime.Now.ToUniversalTime() - origin2;
                string fileName2 = DateTime.Now.Ticks + filExt2;
                string path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName2);
                using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
                {
                    indexProduct.Upload3.CopyTo(fs);
                }
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
                    //photo1//
                    if (indexProduct.Upload1 != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", indexProduct.Photo1);
                        if (System.IO.File.Exists(oldFile))
                        {
                            _fileManager.Delete(oldFile);
                        }
                        IFormFile file = indexProduct.Upload1;
                        string filExt = file.FileName[file.FileName.LastIndexOf(".")..];
                        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                        TimeSpan diff = DateTime.Now.ToUniversalTime() - origin;
                        string fileName = DateTime.Now.Ticks + filExt;
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            indexProduct.Upload1.CopyTo(fs);
                        }
                        indexProduct.Photo1 = fileName;
                    }

                    //photo2//
                    if (indexProduct.Upload2 != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", indexProduct.Photo2);
                        if (System.IO.File.Exists(oldFile))
                        {
                            _fileManager.Delete(oldFile);
                        }
                        IFormFile file = indexProduct.Upload2;
                        string filExt = file.FileName[file.FileName.LastIndexOf(".")..];
                        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                        TimeSpan diff = DateTime.Now.ToUniversalTime() - origin;
                        string fileName = DateTime.Now.Ticks + filExt;
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            indexProduct.Upload2.CopyTo(fs);
                        }
                        indexProduct.Photo2 = fileName;
                    }

                    //photo3//
                    if (indexProduct.Upload3 != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", indexProduct.Photo3);
                        if (System.IO.File.Exists(oldFile))
                        {
                            _fileManager.Delete(oldFile);
                        }
                        IFormFile file = indexProduct.Upload3;
                        string filExt = file.FileName[file.FileName.LastIndexOf(".")..];
                        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                        TimeSpan diff = DateTime.Now.ToUniversalTime() - origin;
                        string fileName = DateTime.Now.Ticks + filExt;
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            indexProduct.Upload3.CopyTo(fs);
                        }
                        indexProduct.Photo3 = fileName;
                    }



                    _context.Update(indexProduct);
                    var a = await _context.SaveChangesAsync();
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
