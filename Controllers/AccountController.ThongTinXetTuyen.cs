using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;
using WebTuyenSinh.ViewModels;

namespace WebTuyenSinh.Controllers;

public partial class AccountController
{
    private readonly List<string> _dsChungChi = new()
    {
        "Không có", "IELTS", "TOEFL iBT", "SAT", "ACT", "DELF/DALF", "JLPT", "TOPIK", "HSK"
    };

    private readonly List<string> _dsDanhGia = new()
    {
        "Không có", "Kỳ thi ĐGNL Đại học quốc gia hà nội", "Kỳ thi ĐGTD Đại học bách khoa hà nội"
    };

    private string EncFloat(string? value) => string.IsNullOrEmpty(value) ? "" : Enc(value);
    private string? DecFloat(string? value) => string.IsNullOrEmpty(value) ? null : Dec(value);

    [HttpGet]
    public async Task<IActionResult> ThongTinXetTuyen()
    {
        var cccd = HttpContext.Session.GetString("CCCD");
        if (string.IsNullOrEmpty(cccd))
            return RedirectToAction("Login");

        var existing = await _ctx.ThongTinXetTuyen.FirstOrDefaultAsync(x => x.CCCD == cccd);
        var vm = new ThongTinXetTuyenVM
        {
            CCCD = cccd,
            DanhSachChungChi = _dsChungChi,
            DanhSachDanhGiaNangLuc = _dsDanhGia
        };

        if (existing != null)
        {
            vm.TinhThanhLop10 = Dec(existing.TinhThanhLop10);
            vm.QuanHuyenLop10 = Dec(existing.QuanHuyenLop10);
            vm.TruongHocLop10 = Dec(existing.TruongHocLop10);

            vm.TinhThanhLop11 = Dec(existing.TinhThanhLop11);
            vm.QuanHuyenLop11 = Dec(existing.QuanHuyenLop11);
            vm.TruongHocLop11 = Dec(existing.TruongHocLop11);

            vm.TinhThanhLop12 = Dec(existing.TinhThanhLop12);
            vm.QuanHuyenLop12 = Dec(existing.QuanHuyenLop12);
            vm.TruongHocLop12 = Dec(existing.TruongHocLop12);

            vm.KhuVucUuTien = Dec(existing.KhuVucUuTien);
            vm.DoiTuongUuTien = Dec(existing.DoiTuongUuTien);
            vm.ChungChi = Dec(existing.ChungChi);
            vm.DiemChungChi = DecFloat(existing.DiemChungChi);
            vm.DanhGiaNangLuc = Dec(existing.DanhGiaNangLuc);
            vm.DiemDanhGiaNangLuc = DecFloat(existing.DiemDanhGiaNangLuc);

            vm.Toan = DecFloat(existing.Toan);
            vm.NguVan = DecFloat(existing.NguVan);
            vm.LichSu = DecFloat(existing.LichSu);
            vm.DiaLy = DecFloat(existing.DiaLy);
            vm.GDCD = DecFloat(existing.GDCD);
            vm.VatLy = DecFloat(existing.VatLy);
            vm.HoaHoc = DecFloat(existing.HoaHoc);
            vm.SinhHoc = DecFloat(existing.SinhHoc);
            vm.CongNgheTinHoc = DecFloat(existing.CongNgheTinHoc);
            vm.TiengAnh = DecFloat(existing.TiengAnh);
            vm.TiengNga = DecFloat(existing.TiengNga);
            vm.TiengDuc = DecFloat(existing.TiengDuc);
            vm.TiengTrung = DecFloat(existing.TiengTrung);
            vm.TiengNhat = DecFloat(existing.TiengNhat);
            vm.TiengHan = DecFloat(existing.TiengHan);
        }

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ThongTinXetTuyen(ThongTinXetTuyenVM vm)
    {
        vm.DanhSachChungChi = _dsChungChi;
        vm.DanhSachDanhGiaNangLuc = _dsDanhGia;

        var cccdSession = HttpContext.Session.GetString("CCCD");
        if (string.IsNullOrEmpty(cccdSession) || vm.CCCD != cccdSession)
        {
            ModelState.AddModelError("", "Phiên làm việc không hợp lệ. Vui lòng đăng nhập lại.");
            return RedirectToAction("Login");
        }

        if (!ModelState.IsValid)
            return View(vm);

        var cccdEnc = Enc(vm.CCCD);
        var existing = await _ctx.ThongTinXetTuyen.FirstOrDefaultAsync(x => x.CCCD == vm.CCCD);

        void GanThongTin(ThongTinXetTuyen info)
        {
            info.TinhThanhLop10 = Enc(vm.TinhThanhLop10);
            info.QuanHuyenLop10 = Enc(vm.QuanHuyenLop10);
            info.TruongHocLop10 = Enc(vm.TruongHocLop10);

            info.TinhThanhLop11 = Enc(vm.GiongLop10_Lop11 ? vm.TinhThanhLop10 : vm.TinhThanhLop11);
            info.QuanHuyenLop11 = Enc(vm.GiongLop10_Lop11 ? vm.QuanHuyenLop10 : vm.QuanHuyenLop11);
            info.TruongHocLop11 = Enc(vm.GiongLop10_Lop11 ? vm.TruongHocLop10 : vm.TruongHocLop11);

            info.TinhThanhLop12 = Enc(vm.GiongLop10_Lop12 ? vm.TinhThanhLop10 : vm.TinhThanhLop12);
            info.QuanHuyenLop12 = Enc(vm.GiongLop10_Lop12 ? vm.QuanHuyenLop10 : vm.QuanHuyenLop12);
            info.TruongHocLop12 = Enc(vm.GiongLop10_Lop12 ? vm.TruongHocLop10 : vm.TruongHocLop12);

            info.KhuVucUuTien = Enc(vm.KhuVucUuTien);
            info.DoiTuongUuTien = Enc(vm.DoiTuongUuTien);
            info.ChungChi = Enc(vm.ChungChi);
            info.DiemChungChi = EncFloat(vm.DiemChungChi);
            info.DanhGiaNangLuc = Enc(vm.DanhGiaNangLuc);
            info.DiemDanhGiaNangLuc = EncFloat(vm.DiemDanhGiaNangLuc);

            info.Toan = EncFloat(vm.Toan);
            info.NguVan = EncFloat(vm.NguVan);
            info.LichSu = EncFloat(vm.LichSu);
            info.DiaLy = EncFloat(vm.DiaLy);
            info.GDCD = EncFloat(vm.GDCD);
            info.VatLy = EncFloat(vm.VatLy);
            info.HoaHoc = EncFloat(vm.HoaHoc);
            info.SinhHoc = EncFloat(vm.SinhHoc);
            info.CongNgheTinHoc = EncFloat(vm.CongNgheTinHoc);
            info.TiengAnh = EncFloat(vm.TiengAnh);
            info.TiengNga = EncFloat(vm.TiengNga);
            info.TiengDuc = EncFloat(vm.TiengDuc);
            info.TiengTrung = EncFloat(vm.TiengTrung);
            info.TiengNhat = EncFloat(vm.TiengNhat);
            info.TiengHan = EncFloat(vm.TiengHan);
        }

        if (existing != null)
            GanThongTin(existing);
        else
        {
            var newTT = new ThongTinXetTuyen { CCCD = cccdEnc };
            GanThongTin(newTT);
            _ctx.ThongTinXetTuyen.Add(newTT);
        }

        await _ctx.SaveChangesAsync();
        TempData["Success"] = "Lưu thông tin xét tuyển thành công!";
        return RedirectToAction("ThongTinXetTuyen");
    }
}
