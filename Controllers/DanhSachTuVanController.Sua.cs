using Microsoft.AspNetCore.Mvc;
using WebTuyenSinh.ViewModels;
using System;

namespace WebTuyenSinh.Controllers
{
    public partial class DanhSachTuVanController : Controller
    {
        // GET: /DanhSachTuVan/RenderSuaPartial?id=0123456789
        [HttpGet]
        public IActionResult RenderSuaPartial(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Thiếu ID.");

            var entity = _context.TuVanTuyenSinh.FirstOrDefault(x => x.SoDienThoai == id);
            if (entity == null)
                return NotFound("Không tìm thấy thông tin sinh viên.");

            var vm = new TuVanTuyenSinhVM
            {
                HoVaTen = entity.HoVaTen,
                NamSinh = DateTime.TryParse(entity.NamSinh, out var ns) ? ns : (DateTime?)null,
                SoDienThoai = entity.SoDienThoai,
                DiaChi = entity.DiaChi,
                Gmail = entity.Gmail,
                TrinhDoHocVan = entity.TrinhDoHocVan,
                DangHocTruong = entity.DangHocTruong,
                NganhHocQuanTam = entity.NganhHocQuanTam,
                HoTenPhuHuynh = entity.HoTenPhuHuynh,
                SoDienThoaiPhuHuynh = entity.SoDienThoaiPhuHuynh,
                NguoiPhuTrach = entity.NguoiPhuTrach,
                TrangThai = entity.TrangThai,
                GhiChu = entity.GhiChu,
                DanhSachNganhNghe = GetNganhNgheSelectList(),
                DanhSachQuanTriVien = GetQuanTriVienSelectList()
            };

            return PartialView("_SuaPartial", vm);
        }

        // POST: /DanhSachTuVan/Sua
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sua(TuVanTuyenSinhVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.DanhSachNganhNghe = GetNganhNgheSelectList();
                vm.DanhSachQuanTriVien = GetQuanTriVienSelectList();
                return PartialView("_SuaPartial", vm);
            }

            var entity = _context.TuVanTuyenSinh.FirstOrDefault(x => x.SoDienThoai == vm.SoDienThoai);
            if (entity == null)
                return NotFound("Không tìm thấy sinh viên.");

            entity.HoVaTen = vm.HoVaTen;
            entity.NamSinh = vm.NamSinh?.ToString("yyyy-MM-dd");
            entity.DiaChi = vm.DiaChi;
            entity.Gmail = vm.Gmail;
            entity.TrinhDoHocVan = vm.TrinhDoHocVan;
            entity.DangHocTruong = vm.DangHocTruong;
            entity.NganhHocQuanTam = vm.NganhHocQuanTam;
            entity.HoTenPhuHuynh = vm.HoTenPhuHuynh;
            entity.SoDienThoaiPhuHuynh = vm.SoDienThoaiPhuHuynh;
            entity.NguoiPhuTrach = vm.NguoiPhuTrach;
            entity.TrangThai = vm.TrangThai;
            entity.GhiChu = vm.GhiChu;

            _context.Update(entity);
            _context.SaveChanges();

            TempData["ThongBao"] = "✔️ Cập nhật thành công!";
            return RedirectToAction("Index");
        }
    }
}
