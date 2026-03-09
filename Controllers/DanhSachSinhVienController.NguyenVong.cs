using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;

namespace WebTuyenSinh.Controllers
{
    public partial class DanhSachSinhVienController
    {
        // Hiển thị bảng nguyện vọng
        public async Task<IActionResult> NguyenVong()
        {
            var danhSach = await _ctx.DangKyNguyenVong.ToListAsync();
            GiaiMaDanhSachNguyenVong(danhSach);
            return View(danhSach);
        }

        // Giải mã dữ liệu
        protected void GiaiMaDanhSachNguyenVong(List<DangKyNguyenVong> danhSach)
        {
            foreach (var item in danhSach)
            {
                item.CCCD = Dec(item.CCCD);

                item.TenNghe1 = Dec(item.TenNghe1);
                item.MaNghe1 = Dec(item.MaNghe1);
                item.TrangThai1 = Dec(item.TrangThai1);

                item.TenNghe2 = Dec(item.TenNghe2);
                item.MaNghe2 = Dec(item.MaNghe2);
                item.TrangThai2 = Dec(item.TrangThai2);

                item.TenNghe3 = Dec(item.TenNghe3);
                item.MaNghe3 = Dec(item.MaNghe3);
                item.TrangThai3 = Dec(item.TrangThai3);

                item.TenNghe4 = Dec(item.TenNghe4);
                item.MaNghe4 = Dec(item.MaNghe4);
                item.TrangThai4 = Dec(item.TrangThai4);

                item.TenNghe5 = Dec(item.TenNghe5);
                item.MaNghe5 = Dec(item.MaNghe5);
                item.TrangThai5 = Dec(item.TrangThai5);

                item.TenNghe6 = Dec(item.TenNghe6);
                item.MaNghe6 = Dec(item.MaNghe6);
                item.TrangThai6 = Dec(item.TrangThai6);

                item.TenNghe7 = Dec(item.TenNghe7);
                item.MaNghe7 = Dec(item.MaNghe7);
                item.TrangThai7 = Dec(item.TrangThai7);
            }
        }
    }
}
