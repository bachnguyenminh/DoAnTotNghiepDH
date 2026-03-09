using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebTuyenSinh.Controllers
{
    public partial class AccountController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> XoaTaiKhoan()
        {
            string? cccd = HttpContext.Session.GetString("CCCD")?.Trim();
            if (string.IsNullOrEmpty(cccd))
            {
                TempData["ErrorMessage"] = "Phiên đăng nhập đã hết. Vui lòng đăng nhập lại.";
                return RedirectToAction("Login");
            }

            try
            {
                var thongTinXTList = await _ctx.ThongTinXetTuyen.Where(x => x.CCCD == cccd).ToListAsync();
                var thongTinSVList = await _ctx.ThongTinSinhVien.Where(x => x.CCCD == cccd).ToListAsync();
                var nguyenVongList = await _ctx.DangKyNguyenVong.Where(x => x.CCCD == cccd).ToListAsync();
                var lichSuList = await _ctx.LichSuDangNhap.Where(x => x.CCCD == cccd).ToListAsync();
                var taiKhoanList = await _ctx.TaiKhoanSinhVien.Where(x => x.CCCD == cccd).ToListAsync();

                _ctx.ThongTinXetTuyen.RemoveRange(thongTinXTList);
                _ctx.ThongTinSinhVien.RemoveRange(thongTinSVList);
                _ctx.DangKyNguyenVong.RemoveRange(nguyenVongList);
                _ctx.LichSuDangNhap.RemoveRange(lichSuList);
                _ctx.TaiKhoanSinhVien.RemoveRange(taiKhoanList);

                await _ctx.SaveChangesAsync();

                TempData["SuccessMessage"] = "Tài khoản và dữ liệu đã được xóa.";
            }
            catch
            {
                TempData["ErrorMessage"] = "Đã xảy ra lỗi khi xóa dữ liệu.";
            }

            return RedirectToAction("Login");
        }
    }
}
