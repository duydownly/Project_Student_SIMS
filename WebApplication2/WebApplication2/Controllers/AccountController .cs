using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View(); // Return the Login view
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            return View(); // Stub for Login action
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login"); // Stub for Logout action
        }
    }
}
