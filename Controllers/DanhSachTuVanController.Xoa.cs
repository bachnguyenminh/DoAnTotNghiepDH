using Microsoft.AspNetCore.Mvc;
using WebTuyenSinh.Models;

namespace WebTuyenSinh.Controllers
{
    public partial class DanhSachTuVanController : Controller
    {
        // XÓA MỘT
        [HttpGet]
        public IActionResult Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Thiếu ID.");

            var entity = _context.TuVanTuyenSinh.FirstOrDefault(x => x.SoDienThoai == id);
            if (entity == null)
                return NotFound("Không tìm thấy sinh viên.");

            _context.TuVanTuyenSinh.Remove(entity);
            _context.SaveChanges();

            TempData["ThongBao"] = "🗑️ Đã xóa sinh viên.";
            return RedirectToAction("Index");
        }

        // XÓA NHIỀU
        [HttpPost]
        public IActionResult XoaNhieu(List<string> chonSinhVien)
        {
            if (chonSinhVien == null || chonSinhVien.Count == 0)
            {
                TempData["ThongBao"] = "⚠️ Bạn chưa chọn sinh viên nào để xóa.";
                return RedirectToAction("Index");
            }

            var ds = _context.TuVanTuyenSinh
                .Where(x => chonSinhVien.Contains(x.SoDienThoai))
                .ToList();

            _context.TuVanTuyenSinh.RemoveRange(ds);
            _context.SaveChanges();

            TempData["ThongBao"] = $"🗑️ Đã xóa {ds.Count} sinh viên.";
            return RedirectToAction("Index");
        }
    }
}
