using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http; // For session management
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        private readonly WebApplication2Context _context;

        public AccountController(WebApplication2Context context)
        {
            _context = context;
        }

        // Phương thức hiển thị trang Login
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Trả về view Login.cshtml
        }

        // Phương thức xử lý yêu cầu khi nhấn nút Login
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Kiểm tra email và password trong bảng Admin
            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.Email == email);

            if (admin == null || admin.Password != password) // So sánh mật khẩu (có thể mã hóa mật khẩu)
            {
                // Nếu không tìm thấy Admin hoặc mật khẩu không đúng
                ModelState.AddModelError("", "Email hoặc mật khẩu không đúng.");
                return View(); // Trả về lại view Login.cshtml
            }

            // Nếu email và mật khẩu đúng, xác thực người dùng và lưu vào session
            HttpContext.Session.SetString("AdminEmail", admin.Email); // Lưu email trong session

            // Điều hướng đến trang Dashboard của Admin
            return RedirectToAction("Dashboard", "Admin");
        }

        // Đăng xuất người dùng
        public IActionResult Logout()
        {
            // Xóa session để đăng xuất người dùng
            HttpContext.Session.Remove("AdminEmail");
            return RedirectToAction("Login", "Account");
        }
    }
}
