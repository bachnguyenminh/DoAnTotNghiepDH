using System.ComponentModel.DataAnnotations;
namespace WebTuyenSinh.Models
{
    public class TuVanTuyenSinh
    {
        [Key]
        public string SoDienThoai { get; set; }

        public string HoVaTen { get; set; }
        public string? NhaMang { get; set; }
        public string? DiaChi { get; set; }
        public string? Gmail { get; set; }
        public string? NamSinh { get; set; }
        public string? TrinhDoHocVan { get; set; }
        public string? DangHocTruong { get; set; }
        public string? NganhHocQuanTam { get; set; }
        public string? TrangThai { get; set; }
        public string? GhiChu { get; set; }
        public string? HoTenPhuHuynh {  get; set; }
        public string? SoDienThoaiPhuHuynh { get; set; }
        public string? NgayDangKy { get; set; }
        public string? NguoiPhuTrach { get; set; }
        public string? ThoiGianPhanCong { get; set; }
    }

}
