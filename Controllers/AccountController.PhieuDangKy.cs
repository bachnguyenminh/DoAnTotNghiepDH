using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;
using WebTuyenSinh.ViewModels;

namespace WebTuyenSinh.Controllers
{
    public partial class AccountController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> PhieuDangKy()
        {
            var cccd = HttpContext.Session.GetString("CCCD")?.Trim();
            if (string.IsNullOrEmpty(cccd))
                return RedirectToAction("Login");

            var cccdEnc = Enc(cccd);

            var sinhvien = await _ctx.TaiKhoanSinhVien.FirstOrDefaultAsync(x => x.CCCD == cccdEnc);
            var ThongTin = await _ctx.ThongTinSinhVien.FirstOrDefaultAsync(x => x.CCCD == cccdEnc);
            var XetTuyen = await _ctx.ThongTinXetTuyen.FirstOrDefaultAsync(x => x.CCCD == cccdEnc);
            var NguyenVong = await _ctx.DangKyNguyenVong.FirstOrDefaultAsync(x => x.CCCD == cccdEnc);

            if (sinhvien == null)
                return Content("Không tìm thấy thông tin sinh viên.");
            ViewBag.CCCD = SafeDec(sinhvien.CCCD);
            ViewBag.HoTen = SafeDec(sinhvien.HoTen);
            ViewBag.GioiTinh = SafeDec(sinhvien.GioiTinh);
            ViewBag.NgaySinh = SafeDec(sinhvien.NgaySinh);
            ViewBag.Email = SafeDec(sinhvien.Email);
            ViewBag.SoDienThoai = SafeDec(sinhvien.SoDienThoai);
            ViewBag.Ten_Tinh_Thanh = SafeDec(sinhvien.Ten_Tinh_Thanh);
            ViewBag.Ten_Quan_Huyen = SafeDec(sinhvien.Ten_Quan_Huyen);
            ViewBag.Ten_Phuong_Xa = SafeDec(sinhvien.Ten_Phuong_Xa);

            if (ThongTin == null)
                return Content("Không tìm thấy thông tin sinh viên.");
            ViewBag.DanToc = Dec(ThongTin.DanToc);

            if (XetTuyen == null)
                return Content("Không tìm thấy thông tin sinh viên.");
            ViewBag.TruongHocLop10 = SafeDec(XetTuyen.TruongHocLop10);
            ViewBag.QuanHuyenLop10 = SafeDec(XetTuyen.QuanHuyenLop10);
            ViewBag.TinhThanhLop10 = SafeDec(XetTuyen.TinhThanhLop10);

            ViewBag.TruongHocLop11 = SafeDec(XetTuyen.TruongHocLop11);
            ViewBag.QuanHuyenLop11 = SafeDec(XetTuyen.QuanHuyenLop11);
            ViewBag.TinhThanhLop11 = SafeDec(XetTuyen.TinhThanhLop11);

            ViewBag.TruongHocLop12 = SafeDec(XetTuyen.TruongHocLop12);
            ViewBag.QuanHuyenLop12 = SafeDec(XetTuyen.QuanHuyenLop12);
            ViewBag.TinhThanhLop12 = SafeDec(XetTuyen.TinhThanhLop12);

            if (NguyenVong == null)
                return Content("Không tìm thấy thông tin sinh viên.");
            ViewBag.TenNghe1 = SafeDec(NguyenVong.TenNghe1);
            ViewBag.MaNghe1 = SafeDec(NguyenVong.MaNghe1);

            ViewBag.TenNghe2 = SafeDec(NguyenVong.TenNghe2);
            ViewBag.MaNghe2 = SafeDec(NguyenVong.MaNghe2);

            ViewBag.TenNghe3 = SafeDec(NguyenVong.TenNghe3);
            ViewBag.MaNghe3 = SafeDec(NguyenVong.MaNghe3);

            ViewBag.TenNghe4 = SafeDec(NguyenVong.TenNghe4);
            ViewBag.MaNghe4 = SafeDec(NguyenVong.MaNghe4);

            ViewBag.TenNghe5 = SafeDec(NguyenVong.TenNghe5);
            ViewBag.MaNghe5 = SafeDec(NguyenVong.MaNghe5);

            ViewBag.TenNghe6 = SafeDec(NguyenVong.TenNghe6);
            ViewBag.MaNghe6 = SafeDec(NguyenVong.MaNghe6);

            ViewBag.TenNghe7 = SafeDec(NguyenVong.TenNghe7);
            ViewBag.MaNghe7 = SafeDec(NguyenVong.MaNghe7);

            return View();

        }
        private string SafeDec (string? value)
        {
            var resul = string.IsNullOrEmpty(value) ? "" : Dec(value);
            return string.IsNullOrEmpty(resul) ? " " : resul;
        }
    }
}
