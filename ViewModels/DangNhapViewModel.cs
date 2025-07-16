using System.ComponentModel.DataAnnotations;

namespace WebTuyenSinh.ViewModels
{
    public class DangNhapViewModel
    {
        [Required]
        public string TenDangNhap { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
    }
}
