using Microsoft.AspNetCore.Mvc;
using PremiumMedStore.Data;
using PremiumMedStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Controllers
{
    public class ContactController : Controller
    {
        private readonly PremiumDbContext _context;

        public ContactController(PremiumDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ContactViewModel model = new ContactViewModel
            {
                Setting=_context.Settings.FirstOrDefault(),
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Kontakt"
                }

            };
            
            return View(model);
        }
    }
}
