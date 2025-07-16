using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;
using WebTuyenSinh.ViewModels;
using System.Threading.Tasks;

namespace WebTuyenSinh.Controllers
{
    public partial class AccountController : Controller
    {
        // Action để hiển thị thông tin nguyện vọng
        [HttpGet]
        public async Task<IActionResult> ThongTinNguyenVong()
        {
            // Lấy CCCD từ Session
            var cccd = HttpContext.Session.GetString("CCCD")?.Trim();
            if (string.IsNullOrEmpty(cccd))
            {
                return RedirectToAction("Login");
            }

            // Mã hóa CCCD
            var cccdEnc = Enc(cccd);

            // Lấy dữ liệu nguyện vọng từ cơ sở dữ liệu
            var existing = await _ctx.DangKyNguyenVong.FirstOrDefaultAsync(x => x.CCCD == cccdEnc);

            // Nếu không có nguyện vọng nào thì trả về view mặc định
            if (existing == null)
            {
                return View(new DangKyNguyenVongVM { CCCD = cccd });
            }

            // Khởi tạo ViewModel và map dữ liệu từ cơ sở dữ liệu
            var vm = new DangKyNguyenVongVM { CCCD = cccd };

            // Duyệt qua từng nguyện vọng và ánh xạ dữ liệu vào ViewModel
            for (int i = 1; i <= 7; i++)
            {
                string? maNghe = (string?)existing.GetType().GetProperty($"MaNghe{i}")?.GetValue(existing);
                string? tenNghe = (string?)existing.GetType().GetProperty($"TenNghe{i}")?.GetValue(existing);
                string? trangThai = (string?)existing.GetType().GetProperty($"TrangThai{i}")?.GetValue(existing);

                if (!string.IsNullOrEmpty(maNghe) && !string.IsNullOrEmpty(tenNghe))
                {
                    // Ánh xạ và giải mã các thuộc tính
                    vm.GetType().GetProperty($"TenNghe{i}")?.SetValue(vm, Dec(tenNghe));
                    vm.GetType().GetProperty($"MaNghe{i}")?.SetValue(vm, Dec(maNghe));
                    vm.GetType().GetProperty($"TrangThai{i}")?.SetValue(vm, Dec(trangThai ?? "0"));
                }
            }

            // Trả về view với ViewModel chứa nguyện vọng
            return View(vm);
        }
    }
}
