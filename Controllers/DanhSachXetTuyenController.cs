using Microsoft.AspNetCore.Mvc;
using WebTuyenSinh.Data;

public class DanhSachXetTuyenController : Controller
{
    private readonly WebTuyenSinhContext _context;
    public DanhSachXetTuyenController(WebTuyenSinhContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index(string tuKhoa)
    {
        var query = _context.TaiKhoanSinhVien.AsQueryable();

        if (!string.IsNullOrWhiteSpace(tuKhoa))
        {
            query = query.Where(x => x.CCCD.Contains(tuKhoa) || x.SoDienThoai.Contains(tuKhoa));
        }

        var danhSach = query.OrderByDescending(x => x.NgayDangKy).ToList();
        ViewBag.TuKhoa = tuKhoa;  // This should now work as you're inheriting from Controller
        return View(danhSach);
    }
}
