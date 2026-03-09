using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WebTuyenSinh.Controllers;

// Đây là 1 phần mở rộng của DanhSachTuVanController, nên cần có partial
public partial class DanhSachTuVanController : Controller
{
    // Khóa SID, SECRET và số Stringee của bạn
    private const string API_SID = "SK.0.Emem0X7bciudHW7tXKf1rQmToKXDRvxz";
    private const string API_SECRET = "ZkNOM1p1UTFielVQeVkxN09TcXo2c0twbFo1azJ5YlE=";
    private const string SO_STRINGEE = "+842871062267";

    private const string ANSWER_URL = "http://v2.stringee.com:8282/project_answer_url";
    private const string EVENT_URL = "http://v2.stringee.com:8282/project_event_url";

    // Tạo JWT Token từ API SID và SECRET
    private string TaoJwtToken()
    {
        var keyBytes = Convert.FromBase64String(API_SECRET);
        var securityKey = new SymmetricSecurityKey(keyBytes);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var header = new JwtHeader(credentials);
        var payload = new JwtPayload
        {
            { "jti", Guid.NewGuid().ToString() },
            { "iss", API_SID },
            { "exp", DateTimeOffset.UtcNow.AddMinutes(60).ToUnixTimeSeconds() }
        };

        var token = new JwtSecurityToken(header, payload);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    // API để thực hiện cuộc gọi
    [HttpPost("DanhSachTuVan/GoiDien")]
    public async Task<IActionResult> GoiDien([FromBody] GoiYeuCau model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.SoDienThoai))
                return BadRequest(new { success = false, message = "Thiếu số điện thoại." });

            // Chuẩn hóa số điện thoại
            var soCanGoi = model.SoDienThoai.Trim();
            if (soCanGoi.StartsWith("0"))
                soCanGoi = "+84" + soCanGoi.Substring(1);
            else if (!soCanGoi.StartsWith("+84"))
                soCanGoi = "+84" + soCanGoi;

            var token = TaoJwtToken();

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var body = new
            {
                from = SO_STRINGEE,
                to = soCanGoi,
                answer_url = ANSWER_URL,
                event_url = EVENT_URL
            };

            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://api.stringee.com/v1/call2/callout", content);

            var result = await response.Content.ReadAsStringAsync();

            return Ok(new
            {
                success = response.IsSuccessStatusCode,
                stringeeResponse = result,
                soGoiDi = soCanGoi
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    // Model đầu vào
    public class GoiYeuCau
    {
        public string SoDienThoai { get; set; } = string.Empty;
    }
}
