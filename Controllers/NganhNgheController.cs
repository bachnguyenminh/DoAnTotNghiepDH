using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WebTuyenSinh.Data;
using WebTuyenSinh.Models;

namespace WebTuyenSinh.Controllers
{
    public class NganhNgheController : Controller
    {
        private readonly WebTuyenSinhContext _context;
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public NganhNgheController(WebTuyenSinhContext context)
        {
            _context = context;
            var pass = "mahoa1234567890";
            _key = SHA256.HashData(Encoding.UTF8.GetBytes(pass));
            _iv = MD5.HashData(Encoding.UTF8.GetBytes(pass));
        }

        protected string Dec(string? s)
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

        public async Task<IActionResult> DanhSachNganhNghe()
        {
            var list = await _context.NganhNghe.ToListAsync();
            ViewBag.TrangThai = TempData["TrangThai"] ?? "OFF (Chưa xuất bản)";
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> XuatBanNganhNghe()
        {
            var ds = await _context.NganhNghe.ToListAsync();

            foreach (var item in ds)
            {
                if (item.ChiTieu == "0")
                {
                    item.ChiTieu = "1";
                }
            }

            TempData["ThongBao"] = "Đã có điểm chuẩn - Bấm vào xem chi tiết ngành nghề!";
            TempData["TrangThai"] = "ON (Đang xuất bản)";

            await _context.SaveChangesAsync();
            return RedirectToAction("DanhSachNganhNghe");
        }

        [HttpPost]
        public async Task<IActionResult> ThuHoiNganhNghe()
        {
            var ds = await _context.NganhNghe.ToListAsync();

            foreach (var item in ds)
            {
                item.ChiTieu = "0";
            }

            TempData["TrangThai"] = "OFF (Ăa xuất bản)";

            await _context.SaveChangesAsync();
            return RedirectToAction("DanhSachNganhNghe");
        }

        public async Task<IActionResult> Index()
        {
            var list = await _context.DangKyNguyenVong.ToListAsync();

            foreach (var item in list)
            {
                item.CCCD = Dec(item.CCCD);
                item.TenNghe1 = Dec(item.TenNghe1);
                item.TenNghe2 = Dec(item.TenNghe2);
                item.TenNghe3 = Dec(item.TenNghe3);
                item.TenNghe4 = Dec(item.TenNghe4);
                item.TenNghe5 = Dec(item.TenNghe5);
                item.TenNghe6 = Dec(item.TenNghe6);
                item.TenNghe7 = Dec(item.TenNghe7);
            }

            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> XuatBan()
        {
            var ds = await _context.DangKyNguyenVong.ToListAsync();

            foreach (var item in ds)
            {
                if (item.TrangThai1 == "0") item.TrangThai1 = "1";
                if (item.TrangThai2 == "0") item.TrangThai2 = "1";
                if (item.TrangThai3 == "0") item.TrangThai3 = "1";
                if (item.TrangThai4 == "0") item.TrangThai4 = "1";
                if (item.TrangThai5 == "0") item.TrangThai5 = "1";
                if (item.TrangThai6 == "0") item.TrangThai6 = "1";
                if (item.TrangThai7 == "0") item.TrangThai7 = "1";
            }

            await _context.SaveChangesAsync();
            TempData["TrangThai"] = "ON (Đang xuất bản)";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ThuHoi()
        {
            var ds = await _context.DangKyNguyenVong.ToListAsync();

            foreach (var item in ds)
            {
                item.TrangThai1 = "0";
                item.TrangThai2 = "0";
                item.TrangThai3 = "0";
                item.TrangThai4 = "0";
                item.TrangThai5 = "0";
                item.TrangThai6 = "0";
                item.TrangThai7 = "0";
            }

            await _context.SaveChangesAsync();
            TempData["TrangThai"] = "OFF (Ăa xuất bản)";
            return RedirectToAction("Index");
        }
    }
}
