using Microsoft.AspNetCore.Mvc;
using PremiumMedStore.Filters;

namespace PremiumMedStore.Areas.Admin.Controllers
{

    [TypeFilter(typeof(Auth))]
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
