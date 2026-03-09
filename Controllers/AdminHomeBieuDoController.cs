using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using WebTuyenSinh.Data;

namespace WebTuyenSinh.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminHomeBieuDoController : Controller
    {
        private readonly WebTuyenSinhContext _ctxTS;
        private readonly TuVanDbContext _ctxTV;
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public AdminHomeBieuDoController(WebTuyenSinhContext ctxTS, TuVanDbContext ctxTV)
        {
            _ctxTS = ctxTS;
            _ctxTV = ctxTV;

            var pass = "mahoa1234567890";
            _key = SHA256.HashData(Encoding.UTF8.GetBytes(pass));
            _iv = MD5.HashData(Encoding.UTF8.GetBytes(pass));
        }

        private string Dec(string? s)
        {
            if (string.IsNullOrEmpty(s))
                return "";

            try
            {
                using var aes = Aes.Create();
                aes.Key = _key;
                aes.IV = _iv;
                var data = Convert.FromBase64String(s);
                return Encoding.UTF8.GetString(aes.CreateDecryptor().TransformFinalBlock(data, 0, data.Length));
            }
            catch
            {
                return s;
            }
        }

        [HttpGet]
        public async Task<IActionResult> BieuDo()
        {
            var formatProvider = CultureInfo.InvariantCulture;

            // Biểu đồ 1: Tư vấn tuyển sinh
            var tuVanRaw = await _ctxTV.TuVanTuyenSinh.ToListAsync();
            var tuVanTheoNgay = tuVanRaw
                .Where(x => DateTime.TryParse(x.NgayDangKy, out _))
                .Select(x => DateTime.Parse(x.NgayDangKy!, formatProvider).Date)
                .GroupBy(date => date)
                .Select(g => new { Ngay = g.Key.ToString("yyyy-MM-dd"), SoLuong = g.Count() })
                .OrderBy(x => x.Ngay)
                .ToList();

            // Biểu đồ 2: Tài khoản sinh viên
            var taiKhoanRaw = await _ctxTS.TaiKhoanSinhVien.ToListAsync();
            var taiKhoanTheoNgay = taiKhoanRaw
                .Where(x => DateTime.TryParse(x.NgayDangKy, out _))
                .Select(x => DateTime.Parse(x.NgayDangKy!, formatProvider).Date)
                .GroupBy(date => date)
                .Select(g => new { Ngay = g.Key.ToString("yyyy-MM-dd"), SoLuong = g.Count() })
                .OrderBy(x => x.Ngay)
                .ToList();

            // Biểu đồ 3: Đăng ký nguyện vọng (đếm CCCD sau giải mã)
            var nguyenVongRaw = await _ctxTS.DangKyNguyenVong
                .Where(x => !string.IsNullOrEmpty(x.CCCD))
                .Select(x => x.CCCD)
                .ToListAsync();

            var soLuongNguyenVong = nguyenVongRaw
                .Select(cccd => Dec(cccd))
                .Distinct()
                .Count();

            ViewBag.TuVanTheoNgay = tuVanTheoNgay;
            ViewBag.TaiKhoanTheoNgay = taiKhoanTheoNgay;
            ViewBag.SoLuongNguyenVong = soLuongNguyenVong;

            return View("~/Views/AdminHome/BieuDo.cshtml");
        }
    }
}
