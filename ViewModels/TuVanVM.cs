using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebTuyenSinh.ViewModels;

public class TuVanVM
{
    [Required(ErrorMessage = "Họ và tên là bắt buộc")]
    public string HoVaTen { get; set; } = string.Empty;

    [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
    public string SoDienThoai { get; set; } = string.Empty;

    public string NhaMang { get; set; } = string.Empty;
    public string DiaChi { get; set; } = string.Empty;
    public string Gmail { get; set; } = string.Empty;

    [Required(ErrorMessage = "Năm sinh là bắt buộc")]
    [DataType(DataType.Date)]
    public DateTime? NamSinh { get; set; }

    [Required(ErrorMessage = "Trình độ học vấn là bắt buộc")]
    public string TrinhDoHocVan { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ngành học quan tâm là bắt buộc")]
    public string NganhHocQuanTam { get; set; } = string.Empty;

    public string TrangThai { get; set; } = string.Empty;
    public string? GhiChu { get; set; }
    public string NgayDangKy { get; set; } = string.Empty;

    public List<SelectListItem> DanhSachNganhNghe { get; set; } = new();
}
