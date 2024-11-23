using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class ContentAreaPagesController : Controller
    {
        public IActionResult StudentManagement()
        {
            return View();
        }
    }

}
