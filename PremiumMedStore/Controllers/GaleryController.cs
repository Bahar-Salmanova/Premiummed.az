using Microsoft.AspNetCore.Mvc;
using PremiumMedStore.Data;
using PremiumMedStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Controllers
{
    public class GaleryController : Controller
    {


        private readonly PremiumDbContext _context;

        public GaleryController(PremiumDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            GaleryViewModel model = new GaleryViewModel
            {
                Galery = _context.Galeries.ToList(),
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Qalereya"
                }
            };
            return View(model);
        }
    }
}
