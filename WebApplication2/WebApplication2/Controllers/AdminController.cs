using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult AdminPage(string menuItem = "Home")
        {
            ViewData["Title"] = "Admin Panel";
            ViewData["ContentTitle"] = menuItem switch
            {
                "Student" => "Student Management",
                "Course" => "Course Management",
                "Teacher" => "Teacher Management",
                "Enroll" => "Enrollment Management",
                "Home" => "Dashboard",
                _ => "Admin Panel"
            };

            return menuItem switch
            {
                "Student" => RedirectToAction("Index", "StudentManagements"),
                "Course" => RedirectToAction("Index", "CourseManagements"),
                "Teacher" => RedirectToAction("Index", "TeacherManagements"),
                "Enroll" => View("~/Views/ContentAreaPages/EnrollPage.cshtml"),
                _ => View("~/Views/ContentAreaPages/Home.cshtml")
            };
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
