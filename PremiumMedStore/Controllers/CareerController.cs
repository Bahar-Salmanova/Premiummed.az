using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremiumMedStore.Data;
using PremiumMedStore.Models;
using PremiumMedStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Controllers
{
    public class CareerController : Controller
    {
         private readonly PremiumDbContext _context;

        public CareerController(PremiumDbContext context)
        {
            _context = context;

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
            return View(model);
        }
        [Route("{action}")]
        public IActionResult CareerApply(int id)
        {
            CareerViewModel model = new CareerViewModel
            {
                Vacancy = _context.Vacancies.Include(v=>v.VacancyForms).ToList(),
                
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Ana Səhifə",
                    Links = "Vakansiya"
                },
                Id = id
            };
            return View(model);
        }
        [HttpPost]
        [Route("{action}")]
        public IActionResult CareerApply(VacancyForm vacancyForm)
        {
            VacancyForm form = new VacancyForm
            {
                Name = vacancyForm.Name,
                Surname = vacancyForm.Surname,
                Telephone = vacancyForm.Telephone,
                Text = vacancyForm.Text,
                Email=vacancyForm.Email,    
                File=vacancyForm.File,
                VacancyId = vacancyForm.VacancyId

            };
            _context.VacancyForms.Add(form);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
