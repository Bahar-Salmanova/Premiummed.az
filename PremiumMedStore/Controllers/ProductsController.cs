using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremiumMedStore.Data;
using PremiumMedStore.Models;
using PremiumMedStore.ViewModel;
using System;
using System.Collections.Generic;
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
        public IActionResult Index( int id)
        {
            ProductViewModel model = new ProductViewModel
            {
                Products = _context.Products.ToList(),
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Məhsullar"

                }
            };
            return View(model);
        }

        [Route("{action}")]
        public IActionResult Order(int id)
        {
            ProductOrderViewModel model = new ProductOrderViewModel
            {
               

                ProductOrder = _context.ProductOrders.FirstOrDefault(),
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Məhsullar"
                }
            };
            return View(model);
        }


        [HttpPost]
        [Route("/{action}")]
        public IActionResult Order(ProductOrder productOrder)
        {
            ProductOrder order = new ProductOrder
            {
                Name = productOrder.Name,
                Surname = productOrder.Surname,
                Telephone = productOrder.Telephone,
                Adres = productOrder.Adres,
                Message = productOrder.Message,
               
            };
            _context.ProductOrders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("index");
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


            return View(model);
        }
    }
}
