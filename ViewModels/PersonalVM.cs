using System.ComponentModel.DataAnnotations;

namespace WebTuyenSinh.ViewModels;

public class PersonalVM
{
    [Required]
    public string CCCD { get; set; } = string.Empty;

    public string HoTen { get; set; } = string.Empty;
    public DateTime? NgaySinh { get; set; }
    public string GioiTinh { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SoDienThoai { get; set; } = string.Empty;
    public string TenTinhThanh { get; set; } = string.Empty;
    public string TenQuanHuyen { get; set; } = string.Empty;
    public string TenPhuongXa { get; set; } = string.Empty;
    public string SoNha { get; set; } = string.Empty;

    public string? DanToc { get; set; }
    public string? TonGiao { get; set; }
    public string? NoiCap { get; set; }
    public DateTime? NgayCap { get; set; }
    public DateTime? NgayHetHan { get; set; }

    // Các trường để upload file ảnh
    public IFormFile? FileAnhCaNhan { get; set; }
    public IFormFile? FileAnhCCCDMatTruoc { get; set; }
    public IFormFile? FileAnhCCCDMatSau { get; set; }
}
