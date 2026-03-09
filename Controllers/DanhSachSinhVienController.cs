using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using WebTuyenSinh.Data;

namespace WebTuyenSinh.Controllers
{
    public partial class DanhSachSinhVienController : Controller
    {
        private readonly WebTuyenSinhContext _ctx;
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public DanhSachSinhVienController(WebTuyenSinhContext ctx)
        {
            _ctx = ctx;
            var pass = "mahoa1234567890";
            _key = SHA256.HashData(Encoding.UTF8.GetBytes(pass));
            _iv = MD5.HashData(Encoding.UTF8.GetBytes(pass));
        }

        protected string Dec(string? s)
        {
            if (string.IsNullOrEmpty(s))
                return "";

            try
            {
                using var aes = Aes.Create();
                aes.Key = _key;
                aes.IV = _iv;
                var data = Convert.FromBase64String(s);
                return Encoding.UTF8.GetString(aes.CreateDecryptor().TransformFinalBlock(data, 0, data.Length));
            }
            catch
            {
                return s; // Nếu không giải mã được thì trả về nguyên bản
            }
        }
    }
}
