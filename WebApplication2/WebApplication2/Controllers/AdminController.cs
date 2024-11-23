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

            // Trả về các View con dựa vào menuItem
            return menuItem switch
            {
                "Student" => View("~/Views/ContentAreaPages/StudentManagement.cshtml"),
                "Course" => View("~/Views/ContentAreaPages/CourseManagement.cshtml"),
                "Teacher" => View("~/Views/ContentAreaPages/TeacherManagement.cshtml"),
                "Enroll" => View("~/Views/ContentAreaPages/EnrollManagement.cshtml"),
                "Logout" => RedirectToAction("Login", "Account"), // Xử lý đăng xuất
                _ => View("~/Views/ContentAreaPages/Home.cshtml") // Trang mặc định khi không có lựa chọn
            };
        }
    }
}
