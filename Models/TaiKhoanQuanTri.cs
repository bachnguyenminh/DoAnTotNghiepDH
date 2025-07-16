using System.ComponentModel.DataAnnotations;

namespace WebTuyenSinh.Models
{
    public class TaiKhoanQuanTri
    {
        [Key]
        public string TenDangNhap { get; set; }

        [Required]
        public string MatKhau { get; set; }

        public string QuyenHan { get; set; } // Admin / CanBo

        public string HoTen { get; set; }

        public bool TrangThai { get; set; }

        public DateTime NgayTao { get; set; }
    }
}
