using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTuyenSinh.Data;

namespace WebTuyenSinh.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminKhachHangController : Controller
    {
        private readonly QuanTriDbContext _context;

        public AdminKhachHangController(QuanTriDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var danhSach = _context.TaiKhoanQuanTri.ToList(); // Giả lập dữ liệu khách hàng
            return View(danhSach);
        }
    }
}
