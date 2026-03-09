using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;

namespace WebTuyenSinh.Controllers
{
    public partial class DanhSachSinhVienController
    {
        // Hiển thị bảng thông tin xét tuyển
        public async Task<IActionResult> DiemHB()
        {
            var danhSach = await _ctx.ThongTinXetTuyen.ToListAsync();
            GiaiMaDanhSachXetTuyen(danhSach);

            return View("~/Views/DanhSachSinhVien/DiemHB.cshtml", danhSach);
        }

        // Giải mã toàn bộ dữ liệu
        protected void GiaiMaDanhSachXetTuyen(List<ThongTinXetTuyen> danhSach)
        {
            foreach (var item in danhSach)
            {
                item.CCCD = Dec(item.CCCD);

                item.TruongHocLop10 = Dec(item.TruongHocLop10);
                item.TinhThanhLop10 = Dec(item.TinhThanhLop10);
                item.QuanHuyenLop10 = Dec(item.QuanHuyenLop10);

                item.TruongHocLop11 = Dec(item.TruongHocLop11);
                item.TinhThanhLop11 = Dec(item.TinhThanhLop11);
                item.QuanHuyenLop11 = Dec(item.QuanHuyenLop11);

                item.TruongHocLop12 = Dec(item.TruongHocLop12);
                item.TinhThanhLop12 = Dec(item.TinhThanhLop12);
                item.QuanHuyenLop12 = Dec(item.QuanHuyenLop12);

                item.KhuVucUuTien = Dec(item.KhuVucUuTien);
                item.DiemKhuVucUuTien = Dec(item.DiemKhuVucUuTien);

                item.DoiTuongUuTien = Dec(item.DoiTuongUuTien);
                item.DiemDoiTuongUuTien = Dec(item.DiemDoiTuongUuTien);

                item.ChungChi = Dec(item.ChungChi);
                item.DiemChungChi = Dec(item.DiemChungChi);

                item.DanhGiaNangLuc = Dec(item.DanhGiaNangLuc);
                item.DiemDanhGiaNangLuc = Dec(item.DiemDanhGiaNangLuc);

                item.Toan = Dec(item.Toan);
                item.NguVan = Dec(item.NguVan);
                item.LichSu = Dec(item.LichSu);
                item.DiaLy = Dec(item.DiaLy);
                item.GDCD = Dec(item.GDCD);
                item.VatLy = Dec(item.VatLy);
                item.HoaHoc = Dec(item.HoaHoc);
                item.SinhHoc = Dec(item.SinhHoc);
                item.CongNgheTinHoc = Dec(item.CongNgheTinHoc);

                item.TiengAnh = Dec(item.TiengAnh);
                item.TiengNga = Dec(item.TiengNga);
                item.TiengDuc = Dec(item.TiengDuc);
                item.TiengTrung = Dec(item.TiengTrung);
                item.TiengNhat = Dec(item.TiengNhat);
                item.TiengHan = Dec(item.TiengHan);

                item.DiemA00 = Dec(item.DiemA00);
                item.DiemD01 = Dec(item.DiemD01);
            }
        }

    }
}
