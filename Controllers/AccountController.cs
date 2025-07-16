// AccountController.cs
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using WebTuyenSinh.Data;

namespace WebTuyenSinh.Controllers;

public partial class AccountController : Controller
{
    protected readonly WebTuyenSinhContext _ctx;
    protected readonly byte[] _key;
    protected readonly byte[] _iv;

    public AccountController(WebTuyenSinhContext ctx)
    {
        _ctx = ctx;
        var pass = "mahoa1234567890";
        _key = SHA256.HashData(Encoding.UTF8.GetBytes(pass));
        _iv = MD5.HashData(Encoding.UTF8.GetBytes(pass));
    }

    protected string Enc(string s)
    {
        using var aes = Aes.Create();
        aes.Key = _key; aes.IV = _iv;
        var data = Encoding.UTF8.GetBytes(s);
        return Convert.ToBase64String(aes.CreateEncryptor().TransformFinalBlock(data, 0, data.Length));
    }

    protected string Dec(string s)
    {
        using var aes = Aes.Create();
        aes.Key = _key; aes.IV = _iv;
        var data = Convert.FromBase64String(s);
        return Encoding.UTF8.GetString(aes.CreateDecryptor().TransformFinalBlock(data, 0, data.Length));
    }
}
