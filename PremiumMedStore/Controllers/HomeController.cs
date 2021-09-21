using Microsoft.AspNetCore.Mvc;
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

        public HomeController(PremiumDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel
            {
                Welcome = _context.Welcomes.FirstOrDefault(),
                IndexProduct = _context.IndexProducts.ToList(),
                Clients = _context.Clients.ToList(),
                News = _context.News.ToList(),
            };
            return View(model);
        }

       
    }
}
