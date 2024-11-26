using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        // Action cho AdminPage
        public IActionResult AdminPage(string menuItem = "Home")
        {
            ViewData["Title"] = "Admin Panel"; // Tiêu đề chung của Admin Panel
            ViewData["ContentTitle"] = menuItem switch
            {
                "Student" => "Student Management",
                "Course" => "Course Management",
                "Teacher" => "Teacher Management",
                "Enroll" => "Enrollment Management",
                "Home" => "Dashboard",
                _ => "Admin Panel"
            };

            // Chuyển hướng tới các trang con dựa vào menuItem
            return menuItem switch
            {
                "Student" => RedirectToAction("Index", "StudentManagements"), // Chuyển hướng đến trang StudentManagements
                "Course" => RedirectToAction("Index", "CourseManagements"),  // Chuyển hướng đến trang CourseManagements
                "Teacher" => RedirectToAction("Index", "TeacherManagements"), // Chuyển hướng đến trang TeacherManagements
                "Enroll" => View("~/Views/ContentAreaPages/EnrollPage.cshtml"), // Render view EnrollPage.cshtml
                "Logout" => View("~/Views/Account/Login.cshtml"), // Render view EnrollPage.cshtml
                _ => View("~/Views/ContentAreaPages/Home.cshtml") // Trang mặc định khi không có lựa chọn
            };
        }
    }
}
