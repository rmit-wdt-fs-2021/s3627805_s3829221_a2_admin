using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InternetBankingAdmin.Models;
using Microsoft.EntityFrameworkCore;
using SimpleHashing;

namespace InternetBankingAdmin.Controllers
{
    [Route("/Mcba/AdminLogin")]
    public class LoginController : Controller
    {
        public IActionResult Login() => View();


        [HttpPost]
        public IActionResult Login(string id, string password)
        {
            var admin = new Admin();

            // Login failed
            if (admin.ID != id || !PBKDF2.Verify(admin.PasswordHash, password))
            {
                ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
                return View(new Login());
            }

            // Login succeeded
            else
            {
                HttpContext.Session.SetString(nameof(Admin.ID), admin.ID);

                return RedirectToAction("Index", "Admin");
            }
        }


        [Route("[action]")]
        public IActionResult Logout()
        {
            // Remove session
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
