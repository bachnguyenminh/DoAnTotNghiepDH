using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;
using WebTuyenSinh.ViewModels;
using Microsoft.AspNetCore.Http;

namespace WebTuyenSinh.Controllers;

public partial class AccountController : Controller
{
    [HttpGet]
    public async Task<IActionResult> DangKyNguyenVong()
    {
        var cccd = HttpContext.Session.GetString("CCCD")?.Trim();
        if (string.IsNullOrEmpty(cccd))
            return RedirectToAction("Login");

        var cccdEnc = Enc(cccd);
        var existing = await _ctx.DangKyNguyenVong.FirstOrDefaultAsync(x => x.CCCD == cccdEnc);
        var danhSachNghe = await _ctx.NganhNghe.ToListAsync();

        var vm = new DangKyNguyenVongVM { CCCD = cccd };

        if (existing != null)
        {
            for (int i = 1; i <= 7; i++)
            {
                var tenProp = $"TenNghe{i}";
                var maProp = $"MaNghe{i}";
                var trangThaiProp = $"TrangThai{i}"; // Cập nhật

                var tenEnc = existing.GetType().GetProperty(tenProp)?.GetValue(existing)?.ToString();
                var maEnc = existing.GetType().GetProperty(maProp)?.GetValue(existing)?.ToString();
                var trangThaiEnc = existing.GetType().GetProperty(trangThaiProp)?.GetValue(existing)?.ToString(); // Cập nhật


                var tenDec = Dec(tenEnc ?? "");
                var maDec = Dec(maEnc ?? "");
                var trangThaiDec = Dec(trangThaiEnc ?? ""); // Cập nhật

                vm.GetType().GetProperty(tenProp)?.SetValue(vm, tenDec);
                vm.GetType().GetProperty(maProp)?.SetValue(vm, maDec);
                vm.GetType().GetProperty(trangThaiProp)?.SetValue(vm, trangThaiDec); // Cập nhật
            }
        }

        ViewBag.DanhSachNghe = danhSachNghe;
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DangKyNguyenVong(DangKyNguyenVongVM vm)
    {
        var danhSachNghe = await _ctx.NganhNghe.ToListAsync();
        string? LayMaNghe(string? tenNghe)
        {
            if (string.IsNullOrWhiteSpace(tenNghe)) return null;
            tenNghe = tenNghe.Trim();
            return danhSachNghe.FirstOrDefault(x => x.TenNghe.Trim() == tenNghe)?.MaNghe;
        }

        string? EncStr(string? s) => string.IsNullOrWhiteSpace(s) ? null : Enc(s);
        string? EncMa(string? tenNghe) => string.IsNullOrWhiteSpace(tenNghe) ? null : Enc(LayMaNghe(tenNghe));

        var cccdEnc = Enc(vm.CCCD);
        var existing = await _ctx.DangKyNguyenVong.FirstOrDefaultAsync(x => x.CCCD == cccdEnc);

        if (existing == null)
        {
            var entity = new DangKyNguyenVong
            {
                CCCD = cccdEnc
            };

            for (int i = 1; i <= 7; i++)
            {
                var tenProp = $"TenNghe{i}";
                var maProp = $"MaNghe{i}";
                var trangThaiProp = $"TrangThai{i}"; // Cập nhật

                var tenValue = vm.GetType().GetProperty(tenProp)?.GetValue(vm)?.ToString();
                var maValue = LayMaNghe(tenValue);
                var trangThaiValue = !string.IsNullOrWhiteSpace(tenValue) ? "0" : null;

                entity.GetType().GetProperty(tenProp)?.SetValue(entity, EncStr(tenValue));
                entity.GetType().GetProperty(maProp)?.SetValue(entity, EncStr(maValue));
                entity.GetType().GetProperty(trangThaiProp)?.SetValue(entity, EncStr(trangThaiValue));// Cập nhật
            }

            _ctx.DangKyNguyenVong.Add(entity);
        }
        else
        {
            for (int i = 1; i <= 7; i++)
            {
                var tenProp = $"TenNghe{i}";
                var maProp = $"MaNghe{i}";
                var trangThaiProp = $"TrangThai{i}"; // Cập nhật

                var tenValue = vm.GetType().GetProperty(tenProp)?.GetValue(vm)?.ToString();
                if (!string.IsNullOrWhiteSpace(tenValue))
                {
                    var maValue = LayMaNghe(tenValue);
                    var trangThaiValue = "0";

                    existing.GetType().GetProperty(tenProp)?.SetValue(existing, EncStr(tenValue));
                    existing.GetType().GetProperty(maProp)?.SetValue(existing, EncStr(maValue));
                    existing.GetType().GetProperty(trangThaiProp)?.SetValue(existing, EncStr(trangThaiValue));
                }
            }
        }

        await _ctx.SaveChangesAsync();
        TempData["Success"] = "Đã lưu nguyện vọng thành công!";
        return RedirectToAction("DangKyNguyenVong");
    }
}
