using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;
using WebTuyenSinh.ViewModels;

namespace WebTuyenSinh.Controllers;

public partial class AccountController
{
    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if (await _ctx.TaiKhoanSinhVien.AnyAsync(x => x.CCCD == Enc(vm.CCCD)))
        {
            ModelState.AddModelError("CCCD", "CCCD đã tồn tại");
            return View(vm);
        }

        var sv = new SinhVien
        {
            CCCD = Enc(vm.CCCD),
            HoTen = Enc($"{vm.HoDem} {vm.Ten}"),
            NgaySinh = Enc(vm.NgaySinh.ToString("yyyy-MM-dd")),
            GioiTinh = Enc(vm.GioiTinh),
            Email = Enc(vm.Email),
            SoDienThoai = Enc(vm.SoDienThoai),
            MatKhau = Enc(vm.Password),
            Ma_Tinh_Thanh = Enc(vm.ProvinceId),
            Ten_Tinh_Thanh = Enc(vm.ProvinceName),
            Ma_Quan_Huyen = Enc(vm.DistrictId),
            Ten_Quan_Huyen = Enc(vm.DistrictName),
            Ma_Phuong_Xa = Enc(vm.WardId),
            Ten_Phuong_Xa = Enc(vm.WardName),
            SoNha = Enc(vm.SoNha),
            VaiTro = Enc("User"),
            NgayDangKy = Enc(DateTime.Now.ToString("yyyy-MM-dd")),
            TrangThai = Enc("Kích hoạt"),
            KhaiBao = Enc("0"),
        };

        _ctx.TaiKhoanSinhVien.Add(sv);
        await _ctx.SaveChangesAsync();

        TempData["Success"] = "Đăng ký thành công!";
        return RedirectToAction("Login");
    }
}
