using System.ComponentModel.DataAnnotations;

namespace WebTuyenSinh.Models
{
    public class TaiKhoanSinhVien
    {
        [Key]
        public string? CCCD { get; set; } = string.Empty;
        public string? HoTen { get; set; } = string.Empty;
        public DateTime? NgaySinh { get; set; }
        public string? GioiTinh { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? SoDienThoai { get; set; } = string.Empty;
        public string? Ten_Tinh_Thanh { get; set; } = string.Empty;
        public string? Ten_Quan_Huyen { get; set; } = string.Empty;
        public string? Ten_Phuong_Xa { get; set; } = string.Empty;
        public string? SoNha { get; set; } = string.Empty;
    }
}
