using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Controllers
{
    public class GaleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
