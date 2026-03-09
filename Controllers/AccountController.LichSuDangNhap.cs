using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;

namespace WebTuyenSinh.Controllers
{
    public partial class AccountController
    {
        public async Task<IActionResult> LichSuDangNhap()
        {
            var cccd = HttpContext.Session.GetString("CCCD");
            if (string.IsNullOrEmpty(cccd))
                return RedirectToAction("Login");

            var existing = await _ctx.LichSuDangNhap.FirstOrDefaultAsync(x => x.CCCD == cccd);

            string lichSuText = existing?.LichSu ?? "Chưa có lịch sử đăng nhập.";

            return View("LichSuDangNhap", lichSuText);
        }

        [HttpPost]
        public async Task<IActionResult> LuuLichSuDangNhap(string noiDung)
        {
            var cccd = HttpContext.Session.GetString("CCCD");
            if (string.IsNullOrEmpty(cccd))
                return Json(false);

            var existing = await _ctx.LichSuDangNhap.FirstOrDefaultAsync(x => x.CCCD == cccd);

            if (existing == null)
            {
                existing = new LichSuDangNhap
                {
                    CCCD = cccd,
                    LichSu = noiDung
                };
                _ctx.LichSuDangNhap.Add(existing);
            }
            else
            {
                existing.LichSu += $"\n------------------------------\n{noiDung}";
            }

            await _ctx.SaveChangesAsync();
            return Json(true);
        }
    }
}
