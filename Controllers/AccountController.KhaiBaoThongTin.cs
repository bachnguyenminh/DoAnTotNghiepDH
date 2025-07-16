// ✅ Controllers/AccountController.KhaiBaoThongTin.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebTuyenSinh.Models;
using System.Linq;

namespace WebTuyenSinh.Controllers
{
    public partial class AccountController : Controller
    {
        [HttpGet]
        public IActionResult TrangKhaiBao()
        {
            // Lấy CCCD đã mã hóa từ session
            string? cccdMaHoa = HttpContext.Session.GetString("CCCD");
            if (string.IsNullOrEmpty(cccdMaHoa))
                return RedirectToAction("Login");

            // Giải mã CCCD
            string cccd = Dec(cccdMaHoa);

            // Truy vấn sinh viên từ database
            var sv = _ctx.TaiKhoanSinhVien.FirstOrDefault(s => s.CCCD == cccd);
            if (sv == null)
                return RedirectToAction("Login");

            // Nếu trường KhaiBao cũng mã hóa thì giải mã nó:
            string khaiBaoGiaiMa = Dec(sv.KhaiBao);

            // Truyền vào ViewBag
            ViewBag.KhaiBao = khaiBaoGiaiMa; // kết quả là "0" hoặc "1"

            return View(); // Load Views/Account/TrangKhaiBao.cshtml
        }
    }
}
