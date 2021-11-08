using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using PremiumMedStore.Data;
using PremiumMedStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly PremiumDbContext _context;
        private readonly IStringLocalizer<HomeController> _sharedLocalizer;
        public HomeController(PremiumDbContext context, IStringLocalizer<HomeController> sharedLocalizer)
        {
            _context = context;
            _sharedLocalizer = sharedLocalizer;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel
            {
                Welcome = _context.Welcomes.FirstOrDefault(),
                IndexProduct = _context.IndexProducts.ToList(),
                Clients = _context.Clients.ToList(),
                News = _context.News.ToList(),
                Products=_context.Products.ToList(),
                ProductCategory = _context.ProductCategories.ToList(),
            };
            ViewBag.Title = "Əsas Səhifə";
            ViewBag.TranslatedInfo = _sharedLocalizer;
            ViewBag.Page = "/Home/Index";
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }

        //dil deyisme numune
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

    }
}
