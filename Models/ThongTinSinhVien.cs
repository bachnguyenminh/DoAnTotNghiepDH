using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    // ➡️ Các thuộc tính phụ để hiển thị ảnh trong View:
    [NotMapped]
    public string? AnhCaNhanBase64 { get; set; }

    [NotMapped]
    public string? AnhCCCDMatTruocBase64 { get; set; }

    [NotMapped]
    public string? AnhCCCDMatSauBase64 { get; set; }
}
