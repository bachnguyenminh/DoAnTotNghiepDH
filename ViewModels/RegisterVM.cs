using System;
using System.ComponentModel.DataAnnotations;

namespace WebTuyenSinh.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string CCCD { get; set; }

        [Required]
        public string HoDem { get; set; }

        [Required]
        public string Ten { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        public string GioiTinh { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string SoDienThoai { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }

        // Thông tin địa chỉ
        [Required]
        public string ProvinceId { get; set; }
        public string ProvinceName { get; set; }

        [Required]
        public string DistrictId { get; set; }
        public string DistrictName { get; set; }

        [Required]
        public string WardId { get; set; }
        public string WardName { get; set; }

        public string SoNha { get; set; }
    }
}
