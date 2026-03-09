using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;

namespace WebTuyenSinh.Controllers
{
    public partial class DanhSachSinhVienController
    {
        // Action hiển thị danh sách sinh viên
        public async Task<IActionResult> Index()
        {
            var danhSach = await _ctx.TaiKhoanSinhVien.ToListAsync();

            GiaiMaDanhSach(danhSach);

            return View(danhSach);
        }

        // Giải mã toàn bộ danh sách sinh viên
        protected void GiaiMaDanhSach(List<SinhVien> danhSach)
        {
            foreach (var sv in danhSach)
            {
                GiaiMaToanBoSinhVien(sv);
            }
        }

        // Giải mã từng sinh viên (18 cột)
        protected void GiaiMaToanBoSinhVien(SinhVien sv)
        {
            sv.CCCD = Dec(sv.CCCD);
            sv.HoTen = Dec(sv.HoTen);
            sv.NgaySinh = Dec(sv.NgaySinh);
            sv.GioiTinh = Dec(sv.GioiTinh);
            sv.Email = Dec(sv.Email);
            sv.SoDienThoai = Dec(sv.SoDienThoai);
            sv.MatKhau = Dec(sv.MatKhau);
            sv.NgayDangKy = Dec(sv.NgayDangKy);
            sv.TrangThai = Dec(sv.TrangThai);

            sv.Ma_Tinh_Thanh = Dec(sv.Ma_Tinh_Thanh);
            sv.Ten_Tinh_Thanh = Dec(sv.Ten_Tinh_Thanh);
            sv.Ma_Quan_Huyen = Dec(sv.Ma_Quan_Huyen);
            sv.Ten_Quan_Huyen = Dec(sv.Ten_Quan_Huyen);
            sv.Ma_Phuong_Xa = Dec(sv.Ma_Phuong_Xa);
            sv.Ten_Phuong_Xa = Dec(sv.Ten_Phuong_Xa);
            sv.SoNha = Dec(sv.SoNha);
            sv.VaiTro = Dec(sv.VaiTro);
            sv.KhaiBao = Dec(sv.KhaiBao);
        }
    }
}
