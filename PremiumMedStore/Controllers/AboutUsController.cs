using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PremiumMedStore.Data;
using PremiumMedStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Controllers
{
    public class AboutUsController : Controller
    {

        private readonly PremiumDbContext _context;
        private readonly IStringLocalizer<HomeController> _sharedLocalizer;

        public AboutUsController(PremiumDbContext context,IStringLocalizer<HomeController> sharedLocalizer)
        {
            _context = context;
            _sharedLocalizer = sharedLocalizer;

        }
        public IActionResult Index()
        {
            AboutViewModel model = new AboutViewModel
            {
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Haqqımızda"

                }
            };
            ViewBag.Title = "Haqqımızda";
            ViewBag.Active = "Haqqimizda";
            ViewBag.TranslatedInfo = _sharedLocalizer;
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }
        public IActionResult Mission()
        {
            AboutViewModel model = new AboutViewModel
            {
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Missiya"

                }
            };
            ViewBag.Title = "Haqqımızda";
            ViewBag.Active = "Haqqimizda";
            ViewBag.TranslatedInfo = _sharedLocalizer;
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }
        public IActionResult Vision()
        {
            AboutViewModel model = new AboutViewModel
            {
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Vizyon"

                }
            };
            ViewBag.Title = "Haqqımızda";
            ViewBag.Active = "Haqqimizda";
            ViewBag.TranslatedInfo = _sharedLocalizer;
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }
        public IActionResult Quality()
        {
            AboutViewModel model = new AboutViewModel
            {
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Keyfiyyət Siyasəti"

                }
            };
            ViewBag.Title = "Haqqımızda";
            ViewBag.Active = "Haqqimizda";
            ViewBag.TranslatedInfo = _sharedLocalizer;
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }


    }
}
