using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Imaging;
using System.Drawing;
using WebTuyenSinh.ViewModels;

namespace WebTuyenSinh.Controllers;

public partial class AccountController
{
    [HttpGet]
    public IActionResult ForgotPassword() => View();

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var user = await _ctx.TaiKhoanSinhVien.FirstOrDefaultAsync(x => x.CCCD == Enc(vm.CCCD));
        if (user == null)
        {
            ModelState.AddModelError("CCCD", "Không tìm thấy CCCD đã nhập");
            return View(vm);
        }

        TempData["CCCD"] = vm.CCCD;
        return RedirectToAction("ResetPassword");
    }

    [HttpGet]
    public IActionResult ResetPassword()
    {
        var cccd = TempData["CCCD"] as string;
        if (cccd == null) return RedirectToAction("Login");
        return View(new ResetPasswordVM { CCCD = cccd });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var user = await _ctx.TaiKhoanSinhVien.FirstOrDefaultAsync(x => x.CCCD == Enc(vm.CCCD));
        if (user == null)
        {
            ModelState.AddModelError("", "Không tìm thấy người dùng");
            return View(vm);
        }

        user.MatKhau = Enc(vm.NewPassword);
        await _ctx.SaveChangesAsync();

        TempData["Success"] = "Đặt lại mật khẩu thành công!";
        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult CaptchaImage()
    {
        string code = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
        HttpContext.Session.SetString("CaptchaCode", code);

        using var bmp = new Bitmap(120, 40);
        using var g = Graphics.FromImage(bmp);
        g.Clear(Color.White);
        using var font = new Font("Arial", 20, FontStyle.Bold);
        g.DrawString(code, font, Brushes.Black, new PointF(10, 5));
        using var ms = new MemoryStream();
        bmp.Save(ms, ImageFormat.Png);
        return File(ms.ToArray(), "image/png");
    }
}
