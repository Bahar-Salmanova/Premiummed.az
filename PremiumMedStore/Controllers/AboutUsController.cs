using Microsoft.AspNetCore.Mvc;
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

        public AboutUsController(PremiumDbContext context)
        {
            _context = context;

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
            return View(model);
        }


    }
}
