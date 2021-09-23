using CryptoHelper;
using Microsoft.AspNetCore.Mvc;
using PremiumMedStore.Data;
using PremiumMedStore.Models;
using PremiumMedStore.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly PremiumDbContext _context;
        public UserController(PremiumDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            //User user = new User
            //{
            //    Email = "Bahar@gmail.com",
            //    FullName = "Bahar",
            //    Password = Crypto.HashPassword("Bahar123")
            //};
            //_context.Users.Add(user);
            //_context.SaveChanges();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                User user = _context.Users.FirstOrDefault(u => u.Email == model.Email);

                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.Password, model.Password))
                    {
                        
                        await _context.SaveChangesAsync();
                        Response.Cookies.Append("token", user.Token, new Microsoft.AspNetCore.Http.CookieOptions
                        {
                            Expires = DateTime.Now.AddMinutes(30),
                            HttpOnly = true
                        });
                    }

                    return RedirectToAction("index", "home");
                }
            }

            return View(model);
        }
        public IActionResult LogOut(int Id)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == Id);

            if (user != null)
            {
                Response.Cookies.Delete("token");
                return RedirectToAction("index", "Home");
            }

            return NoContent();
        }
    }
}
