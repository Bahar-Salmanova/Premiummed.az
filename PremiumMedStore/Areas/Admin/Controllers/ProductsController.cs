using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PremiumMedStore.Data;
using PremiumMedStore.Filters;
using PremiumMedStore.Helpers;
using PremiumMedStore.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            return View(await _context.Products.Include(p => p.ProductCategory).ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.Where(m => m.Id == id).Include(p => p.ProductCategory)
                .FirstOrDefaultAsync();
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewBag.Products = _context.ProductCategories.ToList();
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Upload,Upload1,Upload2,Upload3,ProductAbout,FullAbout,File,ProductCategoryId")] Products products)
        {
            if (products.Upload != null)
            {
                IFormFile file = products.Upload;
                string filExt = file.FileName[file.FileName.LastIndexOf(".")..];
                DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan diff = DateTime.Now.ToUniversalTime() - origin;
                string fileName = DateTime.Now.Ticks + filExt;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    products.Upload.CopyTo(fs);
                }
                products.Photo = fileName;
            }
            if (products.Upload1 == null)
            {
                ModelState.AddModelError("Upload1", "The Photo field is required.");
            }
            if (products.Upload2 == null)
            {
                ModelState.AddModelError("Upload2", "The Photo field is required.");
            }
            if (products.Upload3 == null)
            {
                ModelState.AddModelError("Upload3", "The Photo field is required.");
            }
            if (products.File != null)
            {
                IFormFile file4 = products.File;
                string filExt4 = file4.FileName[file4.FileName.LastIndexOf(".")..];
                DateTime origin4 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan diff4 = DateTime.Now.ToUniversalTime() - origin4;
                string fileName4 = DateTime.Now.Ticks + filExt4;
                string path4 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName4);
                using (FileStream fs = new FileStream(path4, FileMode.OpenOrCreate))
                {
                    products.File.CopyTo(fs);
                }
                products.ProductLink = fileName4;
            }
            
            if (ModelState.IsValid)
            {
                //photo1//
                

                //photo2//
                IFormFile file1 = products.Upload1;
                string filExt1 = file1.FileName[file1.FileName.LastIndexOf(".")..];
                DateTime origin1 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan diff1 = DateTime.Now.ToUniversalTime() - origin1;
                string fileName1 = DateTime.Now.Ticks + filExt1;
                string path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName1);
                using (FileStream fs = new FileStream(path1, FileMode.OpenOrCreate))
                {
                    products.Upload1.CopyTo(fs);
                }
                products.Photo1 = fileName1;

                //photo3//
                IFormFile file2 = products.Upload2;
                string filExt2 = file2.FileName[file2.FileName.LastIndexOf(".")..];
                DateTime origin2 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan diff2 = DateTime.Now.ToUniversalTime() - origin2;
                string fileName2 = DateTime.Now.Ticks + filExt2;
                string path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName2);
                using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
                {
                    products.Upload2.CopyTo(fs);
                }
                products.Photo2 = fileName2;

                //photo4//
                IFormFile file3 = products.Upload3;
                string filExt3 = file3.FileName[file3.FileName.LastIndexOf(".")..];
                DateTime origin3 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan diff3 = DateTime.Now.ToUniversalTime() - origin3;
                string fileName3 = DateTime.Now.Ticks + filExt3;
                string path3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName3);
                using (FileStream fs = new FileStream(path3, FileMode.OpenOrCreate))
                {
                    products.Upload3.CopyTo(fs);
                }
                products.Photo3 = fileName3;

                //file//
               


                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Products = _context.ProductCategories.ToList();
            //ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "Id", "Id", products.ProductCategoryId);
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
            ViewBag.Products = _context.ProductCategories.ToList();
            return View(products);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Photo,Upload,Upload1,Upload2,Upload3,File,Photo1,Photo2,Photo3,ProductAbout,FullAbout,ProductLink,ProductCategoryId")] Products products)
        {
           
            if (id != products.Id)
            {
                return NotFound();
            }
           
            if (ModelState.IsValid)
            {
                try
                {
                    //photo1//
                    if (products.Upload != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", products.Photo);
                        if (System.IO.File.Exists(oldFile))
                        {
                            _fileManager.Delete(oldFile);
                        }
                        IFormFile file = products.Upload;
                        string filExt = file.FileName[file.FileName.LastIndexOf(".")..];
                        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                        TimeSpan diff = DateTime.Now.ToUniversalTime() - origin;
                        string fileName = DateTime.Now.Ticks + filExt;
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            products.Upload.CopyTo(fs);
                        }
                        products.Photo = fileName;
                    }

                    //photo2//
                    if (products.Upload1 != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", products.Photo1);
                        if (System.IO.File.Exists(oldFile))
                        {
                            _fileManager.Delete(oldFile);
                        }
                        IFormFile file = products.Upload1;
                        string filExt = file.FileName[file.FileName.LastIndexOf(".")..];
                        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                        TimeSpan diff = DateTime.Now.ToUniversalTime() - origin;
                        string fileName = DateTime.Now.Ticks + filExt;
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            products.Upload1.CopyTo(fs);
                        }
                        products.Photo1 = fileName;
                    }

                    //photo3//
                    if (products.Upload2 != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", products.Photo2);
                        if (System.IO.File.Exists(oldFile))
                        {
                            _fileManager.Delete(oldFile);
                        }
                        IFormFile file = products.Upload2;
                        string filExt = file.FileName[file.FileName.LastIndexOf(".")..];
                        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                        TimeSpan diff = DateTime.Now.ToUniversalTime() - origin;
                        string fileName = DateTime.Now.Ticks + filExt;
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            products.Upload2.CopyTo(fs);
                        }
                        products.Photo2 = fileName;
                    }

                    //photo4//
                    if (products.Upload3 != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", products.Photo3);
                        if (System.IO.File.Exists(oldFile))
                        {
                            _fileManager.Delete(oldFile);
                        }
                        IFormFile file = products.Upload3;
                        string filExt = file.FileName[file.FileName.LastIndexOf(".")..];
                        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                        TimeSpan diff = DateTime.Now.ToUniversalTime() - origin;
                        string fileName = DateTime.Now.Ticks + filExt;
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            products.Upload3.CopyTo(fs);
                        }
                        products.Photo3 = fileName;
                    }
                    if (products.File != null)
                    {
                        //if()
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", products.ProductLink);
                        if (System.IO.File.Exists(oldFile))
                        {
                            _fileManager.Delete(oldFile);
                        }
                        IFormFile file = products.File;
                        string filExt = file.FileName[file.FileName.LastIndexOf(".")..];
                        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                        TimeSpan diff = DateTime.Now.ToUniversalTime() - origin;
                        string fileName = DateTime.Now.Ticks + filExt;
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            products.File.CopyTo(fs);
                        }
                        products.ProductLink = fileName;
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
            ViewBag.Products = _context.ProductCategories.ToList();
            //ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "Id", "Id", products.ProductCategoryId);
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
