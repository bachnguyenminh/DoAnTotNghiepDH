using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebTuyenSinh.Controllers;

public partial class AccountController
{
    [HttpGet]
    public async Task<IActionResult> Test()
    {
        var cccd = HttpContext.Session.GetString("CCCD")?.Trim();
        if (string.IsNullOrEmpty(cccd))
            return RedirectToAction("Login");

        var cccdEnc = Enc(cccd);

        var sinhvien = await _ctx.TaiKhoanSinhVien.FirstOrDefaultAsync(x => x.CCCD == cccdEnc);
        var XetTuyen = await _ctx.ThongTinXetTuyen.FirstOrDefaultAsync(x => x.CCCD == cccdEnc);
        if (sinhvien == null)
            return Content("Không tìm thấy thông tin sinh viên.");

        ViewBag.HoTen = Dec(sinhvien.HoTen);
        if (XetTuyen == null)
            return Content("Không tìm thấy thông tin sinh viên.");

        ViewBag.KhuVucUuTien = Dec(XetTuyen.KhuVucUuTien);
        return View();
    }
}