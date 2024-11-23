using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        // Action để hiển thị trang AdminPage
        [HttpGet]
        public IActionResult AdminPage()
        {
            return View(); // Trả về view AdminPage.cshtml
        }
    }
}
