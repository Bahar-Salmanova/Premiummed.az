using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremiumMedStore.Data;
using PremiumMedStore.Helpers;
using PremiumMedStore.Models;
using PremiumMedStore.ViewModel;
using System.IO;
using System.Linq;

namespace PremiumMedStore.Controllers
{
    public class CareerController : Controller
    {
        private readonly PremiumDbContext _context;
        private readonly IFileManager _fileManager;

        public CareerController(PremiumDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;

        }
        public IActionResult Index()
        {
            CareerViewModel model = new CareerViewModel
            {
                Vacancy = _context.Vacancies.ToList(),
                VacancyForm = _context.VacancyForms.FirstOrDefault(),
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Vakansiya"
                }
            };
            ViewBag.Title = "Karyera";
            ViewBag.Active = "Karyera";
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }
        [Route("{action}")]
        public IActionResult CareerApply(int id)
        {
            CareerViewModel model = new CareerViewModel
            {
                Vacancy = _context.Vacancies.Include(v => v.VacancyForms).ToList(),

                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Vakansiya"
                },
                Id = id
            };
            ViewBag.Title = "Karyera";
            ViewBag.Active = "Karyera";
            ViewBag.ProductCategories = _context.ProductCategories.ToList();
            return View(model);
        }

        [HttpPost]
        [Route("{action}")]
        public IActionResult CareerApply(VacancyForm vacancyForm)
        {
            if(vacancyForm.VacancyId == 0)
            {
                return NotFound();
            }
            if (vacancyForm.Upload.ContentType != "application/pdf")
            {
                ModelState.AddModelError("VacancyForm.Upload", "yalniz pdf fayli olar");
                CareerViewModel model = new CareerViewModel
                {
                    Vacancy = _context.Vacancies.Include(v => v.VacancyForms).ToList(),

                    BreadCrumb = new BreadCrumbViewModel
                    {
                        Title = "Ana Səhifə",
                        Links = "Vakansiya"
                    },
                    Id = vacancyForm.VacancyId
                };
                ViewBag.Title = "Karyera";
                ViewBag.Active = "Karyera";
                ViewBag.ProductCategories = _context.ProductCategories.ToList();
                return View(model);
            };

            var fileName = _fileManager.Upload(vacancyForm.Upload, "wwwroot/uploads");
            vacancyForm.File = fileName;
            //VacancyForm form = new VacancyForm
            //{
            //    Name = vacancyForm.Name,
            //    Surname = vacancyForm.Surname,
            //    Telephone = vacancyForm.Telephone,
            //    Text = vacancyForm.Text,
            //    Email=vacancyForm.Email,    
            //    File = fileName,
            //    VacancyId = vacancyForm.VacancyId
            //};
            _context.VacancyForms.Add(vacancyForm);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
