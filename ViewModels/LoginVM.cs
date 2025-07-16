using System.ComponentModel.DataAnnotations;

namespace WebTuyenSinh.ViewModels;

public class LoginVM
{
    [Required, RegularExpression(@"^\d{12}$", ErrorMessage = "CCCD phải 12 chữ số")]
    [Display(Name = "CCCD của bạn")]
    public string CCCD { get; set; } = null!;

    [Required, DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$",
        ErrorMessage = "Mật khẩu ≥8 ký tự, gồm hoa, thường, số, ký tự đặc biệt")]
    [Display(Name = "Mật khẩu của bạn")]
    public string Password { get; set; } = null!;

    [Display(Name = "Giữ tôi luôn đăng nhập")]
    public bool RememberMe { get; set; }
}
