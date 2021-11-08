using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremiumMedStore.Data;
using PremiumMedStore.Models;
using PremiumMedStore.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Controllers
{
    public class ProductsController : Controller
    {

        private readonly PremiumDbContext _context;

        public ProductsController(PremiumDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            ProductViewModel model = new ProductViewModel
            {
                Products=_context.Products.Where(p => p.ProductCategoryId == id).Include(p=>p.ProductCategory).ToList(),
                ProductCategory=_context.ProductCategories.Where(pc => pc.Id == id).FirstOrDefault(),
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Məhsullar"

                },
                Id=id,
            };
            ViewBag.Title = "Məhsullar";
            ViewBag.Active = "Məhsullar";
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }

        [Route("{action}")]
        public IActionResult Order(int id)
        {
            ProductOrderViewModel model = new ProductOrderViewModel
            {
              ProductOrders=_context.ProductOrders.Include(p=>p.Product).ToList(),
                
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Məhsullar"
                },
                Id = id
            };
            ViewBag.Title = "Məhsullar";
            ViewBag.Active = "Məhsullar";
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }
        [HttpPost]
        [Route("{action}")]
        public IActionResult Order(ProductOrder productOrder)
        {
            ProductOrder order = new ProductOrder
            {
                Name = productOrder.Name,
                Surname = productOrder.Surname,
                Telephone = productOrder.Telephone,
                Adres = productOrder.Adres,
                Message = productOrder.Message,
                ProductId=productOrder.ProductId,
               
            };
            _context.ProductOrders.Add(order);
            _context.SaveChanges();

            ViewBag.Title = "Məhsullar";
            ViewBag.Active = "Məhsullar";
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return Redirect("/products/product/"+productOrder.ProductId);
        }
       
        [Route("/{controller}/{action}/{id?}")]
        public IActionResult Product(int id)
        {
            ProductViewModel model = new ProductViewModel
            {
                Product = _context.Products
                .Where(p => p.Id == id).FirstOrDefault(),

                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Məhsullar"

                }
            };

            ViewBag.Title = "Məhsullar";
            ViewBag.Active = "Məhsullar";
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }
        public FileResult ShowPDF(int id)
        {
            var premiumDbContext = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", premiumDbContext.ProductLink);
            var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            return File(fileStream, "application/pdf");
        }

        [Route("/{controller}/{action}/{id?}")]
        public IActionResult ProductCategory()
        {
            ProductCategoryViewModel model = new ProductCategoryViewModel
            {
                ProductCategories = _context.ProductCategories.ToList(),
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Məhsullar"

                }
            };
            ViewBag.Title = "Məhsullar";
            ViewBag.Active = "Məhsullar";
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }
    }
}
