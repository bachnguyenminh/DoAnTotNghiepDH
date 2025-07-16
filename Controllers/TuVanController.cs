using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebTuyenSinh.Data;
using WebTuyenSinh.Models;
using WebTuyenSinh.ViewModels;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WebTuyenSinh.Controllers
{
    public class TuVanController : Controller
    {
        private readonly TuVanDbContext _context;

        public TuVanController(TuVanDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult TuVanTSHome()
        {
            var vm = new TuVanVM
            {
                DanhSachNganhNghe = GetNganhNgheSelectList()
            };
            ViewBag.ThongBao = TempData["ThongBao"];
            ViewBag.LoiTrung = TempData["LoiTrung"];
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DangKy(TuVanVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.DanhSachNganhNghe = GetNganhNgheSelectList();
                return View("TuVanTSHome", vm);
            }

            // Kiểm tra trùng số điện thoại hoặc Gmail
            bool soDienThoaiTonTai = _context.TuVanTuyenSinh.Any(x => x.SoDienThoai == vm.SoDienThoai);
            bool gmailTonTai = _context.TuVanTuyenSinh.Any(x => x.Gmail == vm.Gmail);

            if (soDienThoaiTonTai || gmailTonTai)
            {
                TempData["LoiTrung"] = "❌ Số điện thoại hoặc Gmail đã tồn tại.";
                vm.DanhSachNganhNghe = GetNganhNgheSelectList();
                return View("TuVanTSHome", vm);
            }

            // Kiểm tra họ tên chỉ chứa chữ cái và khoảng trắng
            if (!Regex.IsMatch(vm.HoVaTen ?? "", @"^[\p{L}\s]+$"))
            {
                ModelState.AddModelError("HoVaTen", "Họ tên chỉ được chứa chữ cái và khoảng trắng.");
            }

            // Kiểm tra số điện thoại chỉ chứa số và có 10 chữ số
            if (!Regex.IsMatch(vm.SoDienThoai ?? "", @"^\d{10}$"))
            {
                ModelState.AddModelError("SoDienThoai", "Số điện thoại phải gồm đúng 10 chữ số.");
            }

            // Kiểm tra Gmail hợp lệ
            if (string.IsNullOrWhiteSpace(vm.Gmail) || !vm.Gmail.Contains("@"))
            {
                ModelState.AddModelError("Gmail", "Email không hợp lệ. Phải chứa ký tự '@'.");
            }

            if (!ModelState.IsValid)
            {
                vm.DanhSachNganhNghe = GetNganhNgheSelectList();
                return View("TuVanTSHome", vm);
            }

            var nhaMang = XacDinhNhaMang(vm.SoDienThoai);

            var tuVan = new TuVanTuyenSinh
            {
                HoVaTen = vm.HoVaTen,
                SoDienThoai = vm.SoDienThoai,
                NhaMang = nhaMang,
                DiaChi = vm.DiaChi,
                Gmail = vm.Gmail,
                NamSinh = vm.NamSinh?.ToString("yyyy-MM-dd") ?? string.Empty,
                TrinhDoHocVan = vm.TrinhDoHocVan,
                NganhHocQuanTam = vm.NganhHocQuanTam,
                TrangThai = "Chua lien he",
                NgayDangKy = DateTime.Now.ToString("yyyy-MM-dd")
            };

            _context.TuVanTuyenSinh.Add(tuVan);
            _context.SaveChanges();

            TempData["ThongBao"] = "🎉 Đăng ký tư vấn thành công! Chúng tôi sẽ liên hệ với bạn sớm nhất.";
            return RedirectToAction("TuVanTSHome");
        }

        private List<SelectListItem> GetNganhNgheSelectList()
        {
            return _context.NganhNghe
                .Select(n => new SelectListItem
                {
                    Value = n.TenNghe,
                    Text = n.TenNghe
                }).ToList();
        }

        private string? XacDinhNhaMang(string soDienThoai)
        {
            if (string.IsNullOrWhiteSpace(soDienThoai) || soDienThoai.Length < 3)
                return null;

            var dauSo = soDienThoai.Substring(0, 3);

            string[] vinaphone = { "091", "094", "088", "083", "084", "085", "081", "082" };
            string[] viettel = { "086", "096", "097", "098", "032", "033", "034", "035", "036", "037", "038", "039" };
            string[] mobifone = { "089", "090", "093", "070", "079", "077", "076", "078" };
            string[] vietnamobile = { "052", "056", "058", "092" };
            string[] gmobile = { "059", "099" };
            string[] itelecom = { "087" };

            if (vinaphone.Contains(dauSo)) return "Vinaphone";
            if (viettel.Contains(dauSo)) return "Viettel";
            if (mobifone.Contains(dauSo)) return "Mobifone";
            if (vietnamobile.Contains(dauSo)) return "Vietnamobile";
            if (gmobile.Contains(dauSo)) return "Gmobile";
            if (itelecom.Contains(dauSo)) return "I-Telecom";

            return "Khong xac dinh";
        }
    }
}
