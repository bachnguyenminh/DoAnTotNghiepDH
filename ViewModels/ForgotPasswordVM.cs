using System.ComponentModel.DataAnnotations;

namespace WebTuyenSinh.ViewModels;

public class ForgotPasswordVM
{
    [Required, RegularExpression(@"^\d{12}$", ErrorMessage = "CCCD phải 12 chữ số")]
    [Display(Name = "Số CMND")]
    public string CCCD { get; set; } = null!;

    [Required(ErrorMessage = "Bạn phải nhập mã xác nhận")]
    [Display(Name = "Mã xác nhận")]
    public string InputCaptcha { get; set; } = null!;
}
