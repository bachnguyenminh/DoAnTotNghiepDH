using Microsoft.AspNetCore.Mvc;
using WebTuyenSinh.Data;
using WebTuyenSinh.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebTuyenSinh.Controllers
{
    public class AdminController : Controller
    {
        private readonly QuanTriDbContext _context;

        public AdminController(QuanTriDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(DangNhapViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var tk = _context.TaiKhoanQuanTri
                .FirstOrDefault(x => x.TenDangNhap == model.TenDangNhap && x.TrangThai);

            if (tk == null || tk.MatKhau != model.MatKhau) // Nên mã hóa mật khẩu khi so sánh
            {
                ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, tk.TenDangNhap),
                new Claim(ClaimTypes.Role, tk.QuyenHan),
                new Claim("HoTen", tk.HoTen)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "AdminHome"); // Điều hướng sau đăng nhập
        }

        public async Task<IActionResult> DangXuat()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("DangNhap");
        }
    }
}
