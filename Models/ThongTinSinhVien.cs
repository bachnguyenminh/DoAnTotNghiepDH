using System.ComponentModel.DataAnnotations;

namespace WebTuyenSinh.Models;

public class ThongTinSinhVien
{
    [Key]
    public string CCCD { get; set; } = null!;

    public string? DanToc { get; set; }
    public string? TonGiao { get; set; }
    public string? NoiCap { get; set; }
    public string? NgayCap { get; set; }
    public string? NgayHetHan { get; set; }

    // Các trường ảnh dạng byte[] tương thích với SQL datatype IMAGE
    public byte[]? AnhCaNhan { get; set; }
    public byte[]? AnhCCCDMatTruoc { get; set; }
    public byte[]? AnhCCCDMatSau { get; set; }
}
