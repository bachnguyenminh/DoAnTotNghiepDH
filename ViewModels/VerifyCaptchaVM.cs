using System.ComponentModel.DataAnnotations;

namespace WebTuyenSinh.ViewModels;

public class VerifyCaptchaVM
{
    // Mã captcha sẽ được sinh và render qua ảnh
    public string CaptchaCode { get; set; } = null!;

    [Required(ErrorMessage = "Bạn phải nhập mã xác nhận")]
    [Display(Name = "Mã xác nhận")]
    public string InputCaptcha { get; set; } = null!;
}
