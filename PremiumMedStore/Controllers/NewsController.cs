using Microsoft.AspNetCore.Mvc;
using PremiumMedStore.Data;
using PremiumMedStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Controllers
{
    public class NewsController : Controller
    {

        private readonly PremiumDbContext _context;

        public NewsController(PremiumDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            NewsViewModel model = new NewsViewModel
            {
                News = _context.News.ToList(),
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Xəbərlər"

                }
            };
            ViewBag.Title = "Xəbərlər";
            ViewBag.Active = "Xəbərlər";
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }
        public IActionResult Measure(int id)
        {
            MeasureViewModel model = new MeasureViewModel
            {
                Measures = _context.Measures.ToList(),
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Tədbirlər"

                }
            };
            ViewBag.Title = "Tədbirlər";
            ViewBag.Active = "Xəbərlər";
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }

        [Route("/{controller}/{action}/{id?}")]
        public IActionResult SingleMeasure(int id)
        {
            MeasureViewModel model = new MeasureViewModel
            {
                Galeries = _context.Galeries.Take(5).ToList(),
                Measures = _context.Measures.ToList(),
                Measure = _context.Measures
                  .Where(m => m.Id == id).FirstOrDefault(),

                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Tədbirlər"

                }
            };
            ViewBag.Title = "Tədbirlər";
            ViewBag.Active = "Xəbərlər";
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }

        [Route("/{controller}/{action}/{id?}")]
        public IActionResult FreeNews(int id)
        {
            NewsViewModel model = new NewsViewModel
            {
                News = _context.News.ToList(),
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Xəbərlər"

                }
            };
            ViewBag.Title = "Xəbərlər";
            ViewBag.Active = "Xəbərlər";
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }

        [Route("/{controller}/{action}/{id?}")]
        public IActionResult SingleNews(int id)
        {
            SingleNewsViewModel model = new SingleNewsViewModel
            {
                Galery = _context.Galeries.Take(5).ToList(),
                News = _context.News.ToList(),
                New = _context.News
                .Where(n => n.Id == id).FirstOrDefault(),
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Xəbərlər"

                }

            };
            ViewBag.Title = "Xəbərlər";
            ViewBag.Active = "Xəbərlər";
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }
    }
}
