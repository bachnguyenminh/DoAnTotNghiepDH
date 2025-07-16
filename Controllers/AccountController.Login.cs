// AccountController.Login.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.ViewModels;

namespace WebTuyenSinh.Controllers;

public partial class AccountController
{
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var maHoaCCCD = Enc(vm.CCCD);
        var maHoaMatKhau = Enc(vm.Password);

        var user = await _ctx.TaiKhoanSinhVien
            .FirstOrDefaultAsync(x => x.CCCD == maHoaCCCD && x.MatKhau == maHoaMatKhau);

        if (user == null)
        {
            ModelState.AddModelError("", "Sai CCCD hoặc mật khẩu");
            return View(vm);
        }

        HttpContext.Session.SetString("CCCD", vm.CCCD);
        HttpContext.Session.SetString("HoTen", Dec(user.HoTen));

        var daCoThongTin = await _ctx.ThongTinSinhVien.AnyAsync(x => x.CCCD == vm.CCCD);

        if (daCoThongTin)
        {
            return RedirectToAction("NhapThongTin");
        }
        else
        {
            return RedirectToAction("ThongTinNguyenVong", "Account"); // hoặc nơi bạn muốn chuyển đến sau khi login thành công
        }
    }

    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Account");
    }
}
