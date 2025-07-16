using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace WebTuyenSinh.Controllers;

public partial class DanhSachTuVanController
{
    // POST: /DanhSachTuVan/GoiDien
    [HttpPost]
    public IActionResult GoiDien([FromBody] GoiYeuCau model)
    {
        try
        {
            // Thông tin tài khoản Twilio
            const string accountSid = "YOUR_TWILIO_SID";
            const string authToken = "YOUR_TWILIO_AUTH_TOKEN";
            const string fromPhone = "+1XXXYYYZZZ"; // Số điện thoại Twilio đã đăng ký

            TwilioClient.Init(accountSid, authToken);

            var call = CallResource.Create(
                to: new PhoneNumber(model.SoDienThoai),
                from: new PhoneNumber(fromPhone),
                url: new Uri("http://demo.twilio.com/docs/voice.xml") // Nội dung cuộc gọi (có thể tuỳ chỉnh)
            );

            return Ok(new { success = true, message = "Đang thực hiện cuộc gọi..." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    public class GoiYeuCau
    {
        public string SoDienThoai { get; set; } = string.Empty;
    }
}
