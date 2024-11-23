using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    // Phương thức hiển thị trang Login
    [HttpGet]
    public IActionResult Login()
    {
        return View(); // Trả về view Login.cshtml
    }

    // Phương thức xử lý yêu cầu khi nhấn nút Login
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Bỏ qua xác thực, điều hướng thẳng đến AdminPage
        return RedirectToAction("AdminPage", "Admin");
    }
}
