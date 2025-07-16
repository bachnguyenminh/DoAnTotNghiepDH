using Microsoft.AspNetCore.Mvc;
using WebTuyenSinh.Data;

namespace WebTuyenSinh.Controllers;

[Route("[controller]/[action]")]
public partial class DanhSachTuVanController : Controller
{
    private readonly TuVanDbContext _context;
    private readonly QuanTriDbContext _quanTriDb;

    public DanhSachTuVanController(TuVanDbContext context, QuanTriDbContext quanTriDb)
    {
        _context = context;
        _quanTriDb = quanTriDb;
    }

    [HttpGet]
    public IActionResult Index(string tuKhoa)
    {
        var query = _context.TuVanTuyenSinh.AsQueryable();

        if (!string.IsNullOrWhiteSpace(tuKhoa))
        {
            query = query.Where(x => x.HoVaTen.Contains(tuKhoa) || x.SoDienThoai.Contains(tuKhoa));
        }

        var danhSach = query.OrderByDescending(x => x.NgayDangKy).ToList();
        ViewBag.TuKhoa = tuKhoa;
        return View(danhSach);
    }
}
