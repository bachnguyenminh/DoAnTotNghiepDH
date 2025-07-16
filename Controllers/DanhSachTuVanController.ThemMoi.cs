using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebTuyenSinh.Data;
using WebTuyenSinh.Models;
using WebTuyenSinh.ViewModels;
using System.Text.RegularExpressions;

namespace WebTuyenSinh.Controllers;

public partial class DanhSachTuVanController
{
    [HttpGet]
    public IActionResult RenderThemMoiPartial()
    {
        var vm = new TuVanTuyenSinhVM
        {
            DanhSachNganhNghe = GetNganhNgheSelectList(),
            DanhSachQuanTriVien = GetQuanTriVienSelectList(),
            TrangThai = "Chưa liên hệ"
        };
        return PartialView("_ThemMoiPartial", vm);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ThemMoi(TuVanTuyenSinhVM vm)
    {
        if (!ModelState.IsValid)
        {
            vm.DanhSachNganhNghe = GetNganhNgheSelectList();
            vm.DanhSachQuanTriVien = GetQuanTriVienSelectList();
            return View(vm);
        }

        // Kiểm tra trùng
        bool sdtTonTai = _context.TuVanTuyenSinh.Any(x => x.SoDienThoai == vm.SoDienThoai);
        bool gmailTonTai = _context.TuVanTuyenSinh.Any(x => x.Gmail == vm.Gmail);

        if (sdtTonTai || gmailTonTai)
        {
            TempData["LoiTrung"] = "❌ Số điện thoại hoặc Gmail đã tồn tại.";
            vm.DanhSachNganhNghe = GetNganhNgheSelectList();
            vm.DanhSachQuanTriVien = GetQuanTriVienSelectList();
            return View(vm);
        }

        // Kiểm tra định dạng
        if (!Regex.IsMatch(vm.HoVaTen ?? "", @"^[\p{L}\s]+$"))
            ModelState.AddModelError("HoVaTen", "Họ tên chỉ được chứa chữ cái và khoảng trắng.");

        if (!Regex.IsMatch(vm.SoDienThoai ?? "", @"^\d{10}$"))
            ModelState.AddModelError("SoDienThoai", "Số điện thoại phải gồm đúng 10 chữ số.");

        if (string.IsNullOrWhiteSpace(vm.Gmail) || !vm.Gmail.Contains("@"))
            ModelState.AddModelError("Gmail", "Email không hợp lệ. Phải chứa ký tự '@'.");

        if (!ModelState.IsValid)
        {
            vm.DanhSachNganhNghe = GetNganhNgheSelectList();
            vm.DanhSachQuanTriVien = GetQuanTriVienSelectList();
            return View(vm);
        }

        var tuVan = new TuVanTuyenSinh
        {
            HoVaTen = vm.HoVaTen,
            NamSinh = vm.NamSinh?.ToString("yyyy-MM-dd"), // lưu dưới dạng chuỗi
            SoDienThoai = vm.SoDienThoai,
            NhaMang = XacDinhNhaMang(vm.SoDienThoai),
            DiaChi = vm.DiaChi,
            Gmail = vm.Gmail,
            TrinhDoHocVan = vm.TrinhDoHocVan,
            DangHocTruong = vm.DangHocTruong,
            NganhHocQuanTam = vm.NganhHocQuanTam,
            HoTenPhuHuynh = vm.HoTenPhuHuynh,
            SoDienThoaiPhuHuynh = vm.SoDienThoaiPhuHuynh,
            NguoiPhuTrach = vm.NguoiPhuTrach,
            TrangThai = vm.TrangThai ?? "Chưa liên hệ",
            GhiChu = vm.GhiChu,
            NgayDangKy = DateTime.Now.ToString("yyyy-MM-dd"), // lưu chuỗi yyyy-MM-dd
            ThoiGianPhanCong = null // chưa có
        };

        _context.TuVanTuyenSinh.Add(tuVan);
        _context.SaveChanges();

        TempData["ThongBao"] = "✅ Thêm mới thành công!";
        return RedirectToAction("Index");
    }

    private string XacDinhNhaMang(string sdt)
    {
        if (string.IsNullOrWhiteSpace(sdt) || sdt.Length < 3) return "Không xác định";
        var dauSo = sdt.Substring(0, 3);

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
        return "Không xác định";
    }

    private List<SelectListItem> GetNganhNgheSelectList()
    {
        return _context.NganhNghe.Select(n => new SelectListItem
        {
            Value = n.TenNghe,
            Text = n.TenNghe
        }).ToList();
    }

    private List<SelectListItem> GetQuanTriVienSelectList()
    {
        return _quanTriDb.TaiKhoanQuanTri.Select(q => new SelectListItem
        {
            Value = q.HoTen,
            Text = q.HoTen
        }).ToList();
    }
}
