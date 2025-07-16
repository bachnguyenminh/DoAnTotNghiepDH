using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;
using WebTuyenSinh.ViewModels;
using System.Text;

namespace WebTuyenSinh.Controllers;

public partial class AccountController
{
    [HttpGet]
    public async Task<IActionResult> NhapThongTin()
    {
        var cccd = HttpContext.Session.GetString("CCCD");
        if (string.IsNullOrEmpty(cccd))
            return RedirectToAction("Login");

        var cccdMaHoa = Enc(cccd);
        var acc = await _ctx.TaiKhoanSinhVien.FirstOrDefaultAsync(x => x.CCCD == cccdMaHoa);
        if (acc == null) return NotFound();

        var thongtin = await _ctx.ThongTinSinhVien.FirstOrDefaultAsync(x => x.CCCD == cccdMaHoa);

        bool daDuThongTin = thongtin != null &&
            !string.IsNullOrWhiteSpace(thongtin.DanToc) &&
            !string.IsNullOrWhiteSpace(thongtin.TonGiao) &&
            !string.IsNullOrWhiteSpace(thongtin.NoiCap) &&
            !string.IsNullOrWhiteSpace(thongtin.NgayCap) &&
            !string.IsNullOrWhiteSpace(thongtin.NgayHetHan) &&
            thongtin.AnhCaNhan != null &&
            thongtin.AnhCCCDMatTruoc != null &&
            thongtin.AnhCCCDMatSau != null;

        if (daDuThongTin)
        {
            TempData["InfoStatus"] = "Đã nhập đầy đủ thông tin.";
        }

        DateTime? ngaySinh = ParseDate(Dec(acc.NgaySinh));

        var vm = new PersonalVM
        {
            CCCD = cccd,
            HoTen = Dec(acc.HoTen),
            NgaySinh = ngaySinh,
            GioiTinh = Dec(acc.GioiTinh),
            Email = Dec(acc.Email),
            SoDienThoai = Dec(acc.SoDienThoai),
            TenTinhThanh = Dec(acc.Ten_Tinh_Thanh),
            TenQuanHuyen = Dec(acc.Ten_Quan_Huyen),
            TenPhuongXa = Dec(acc.Ten_Phuong_Xa),
            SoNha = Dec(acc.SoNha),
            DanToc = thongtin?.DanToc != null ? Dec(thongtin.DanToc) : null,
            TonGiao = thongtin?.TonGiao != null ? Dec(thongtin.TonGiao) : null,
            NoiCap = thongtin?.NoiCap != null ? Dec(thongtin.NoiCap) : null,
            NgayCap = DecDate(thongtin?.NgayCap),
            NgayHetHan = DecDate(thongtin?.NgayHetHan),
        };

        if (thongtin?.AnhCaNhan != null)
            ViewData["AnhCaNhan"] = $"data:image/jpeg;base64,{Dec(Encoding.UTF8.GetString(thongtin.AnhCaNhan))}";

        if (thongtin?.AnhCCCDMatTruoc != null)
            ViewData["AnhCCCDMatTruoc"] = $"data:image/jpeg;base64,{Dec(Encoding.UTF8.GetString(thongtin.AnhCCCDMatTruoc))}";

        if (thongtin?.AnhCCCDMatSau != null)
            ViewData["AnhCCCDMatSau"] = $"data:image/jpeg;base64,{Dec(Encoding.UTF8.GetString(thongtin.AnhCCCDMatSau))}";

        return View("Personal", vm);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> NhapThongTin(PersonalVM vm)
    {
        if (!ModelState.IsValid)
            return View("Personal", vm);

        var cccdMaHoa = Enc(vm.CCCD);
        var thongtin = await _ctx.ThongTinSinhVien.FirstOrDefaultAsync(x => x.CCCD == cccdMaHoa);

        if (thongtin == null)
        {
            var tk = await _ctx.TaiKhoanSinhVien.FirstOrDefaultAsync(x => x.CCCD == cccdMaHoa);
            if (tk == null)
            {
                ModelState.AddModelError("", "Không tìm thấy tài khoản.");
                return View("Personal", vm);
            }

            thongtin = new ThongTinSinhVien { CCCD = cccdMaHoa };
            _ctx.ThongTinSinhVien.Add(thongtin);
        }

        async Task<byte[]?> ReadFile(IFormFile? file)
        {
            if (file == null || file.Length == 0) return null;
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            return Encoding.UTF8.GetBytes(Enc(Convert.ToBase64String(ms.ToArray())));
        }

        thongtin.DanToc = string.IsNullOrWhiteSpace(vm.DanToc) ? null : Enc(vm.DanToc);
        thongtin.TonGiao = string.IsNullOrWhiteSpace(vm.TonGiao) ? null : Enc(vm.TonGiao);
        thongtin.NoiCap = string.IsNullOrWhiteSpace(vm.NoiCap) ? null : Enc(vm.NoiCap);
        thongtin.NgayCap = vm.NgayCap.HasValue ? Enc(vm.NgayCap.Value.ToString("yyyy-MM-dd")) : null;
        thongtin.NgayHetHan = vm.NgayHetHan.HasValue ? Enc(vm.NgayHetHan.Value.ToString("yyyy-MM-dd")) : null;

        if (vm.FileAnhCaNhan != null)
            thongtin.AnhCaNhan = await ReadFile(vm.FileAnhCaNhan);
        if (vm.FileAnhCCCDMatTruoc != null)
            thongtin.AnhCCCDMatTruoc = await ReadFile(vm.FileAnhCCCDMatTruoc);
        if (vm.FileAnhCCCDMatSau != null)
            thongtin.AnhCCCDMatSau = await ReadFile(vm.FileAnhCCCDMatSau);

        await _ctx.SaveChangesAsync();

        TempData["Success"] = "Thông tin cá nhân đã được cập nhật.";
        return RedirectToAction("NhapThongTin");
    }

    private DateTime? DecDate(string? encrypted)
    {
        if (string.IsNullOrWhiteSpace(encrypted)) return null;
        var decrypted = Dec(encrypted);
        if (DateTime.TryParseExact(decrypted, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var result))
            return result;
        return null;
    }

    private DateTime? ParseDate(string? dateString)
    {
        if (string.IsNullOrWhiteSpace(dateString)) return null;
        if (DateTime.TryParseExact(dateString, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var dt))
            return dt;
        else if (DateTime.TryParse(dateString, out dt))
            return dt;
        return null;
    }

    public async Task<bool> DaNhapDayDuThongTin(string cccd)
    {
        var cccdMaHoa = Enc(cccd);
        var info = await _ctx.ThongTinSinhVien.FirstOrDefaultAsync(x => x.CCCD == cccdMaHoa);
        if (info == null) return false;

        return !string.IsNullOrWhiteSpace(info.DanToc) &&
               !string.IsNullOrWhiteSpace(info.TonGiao) &&
               !string.IsNullOrWhiteSpace(info.NoiCap) &&
               !string.IsNullOrWhiteSpace(info.NgayCap) &&
               !string.IsNullOrWhiteSpace(info.NgayHetHan) &&
               info.AnhCaNhan != null &&
               info.AnhCCCDMatTruoc != null &&
               info.AnhCCCDMatSau != null;
    }
}
