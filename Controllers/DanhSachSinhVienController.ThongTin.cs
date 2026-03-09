using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;
using System.Text;

namespace WebTuyenSinh.Controllers
{
    public partial class DanhSachSinhVienController
    {
        // Hiển thị danh sách thông tin sinh viên (bảng ThongTinSinhVien)
        public async Task<IActionResult> ThongTin()
        {
            var danhSach = await _ctx.ThongTinSinhVien.ToListAsync();
            GiaiMaDanhSachThongTin(danhSach);

            return View(danhSach);
        }

        // Giải mã danh sách ThongTinSinhVien
        protected void GiaiMaDanhSachThongTin(List<ThongTinSinhVien> danhSach)
        {
            foreach (var sv in danhSach)
            {
                sv.CCCD = Dec(sv.CCCD);
                sv.DanToc = Dec(sv.DanToc);
                sv.TonGiao = Dec(sv.TonGiao);
                sv.NoiCap = Dec(sv.NoiCap);
                sv.NgayCap = Dec(sv.NgayCap);
                sv.NgayHetHan = Dec(sv.NgayHetHan);

                // Giải mã và chuyển ảnh về base64 src
                sv.AnhCaNhanBase64 = sv.AnhCaNhan != null
                    ? $"data:image/jpeg;base64,{Dec(Encoding.UTF8.GetString(sv.AnhCaNhan))}"
                    : null;

                sv.AnhCCCDMatTruocBase64 = sv.AnhCCCDMatTruoc != null
                    ? $"data:image/jpeg;base64,{Dec(Encoding.UTF8.GetString(sv.AnhCCCDMatTruoc))}"
                    : null;

                sv.AnhCCCDMatSauBase64 = sv.AnhCCCDMatSau != null
                    ? $"data:image/jpeg;base64,{Dec(Encoding.UTF8.GetString(sv.AnhCCCDMatSau))}"
                    : null;
            }
        }
    }
}
