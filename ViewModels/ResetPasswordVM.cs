using System.ComponentModel.DataAnnotations;

namespace WebTuyenSinh.ViewModels;

public class ResetPasswordVM
{
    public string CCCD { get; set; } = null!;

    [Required, DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$",
        ErrorMessage = "Mật khẩu ≥8 ký tự, gồm hoa, thường, số, ký tự đặc biệt")]
    [Display(Name = "Mật khẩu mới")]
    public string NewPassword { get; set; } = null!;

    [Required, DataType(DataType.Password), Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp")]
    [Display(Name = "Xác nhận mật khẩu")]
    public string ConfirmPassword { get; set; } = null!;
}