using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTuyenSinh.Models
{
    [Table("ThongTinXetTuyen")]
    public class ThongTinXetTuyen
    {
        [Key]
        public string CCCD { get; set; }

        // Lớp 10
        public string? TruongHocLop10 { get; set; }
        public string? TinhThanhLop10 { get; set; }
        public string? QuanHuyenLop10 { get; set; }

        // Lớp 11
        public string? TruongHocLop11 { get; set; }
        public string? TinhThanhLop11 { get; set; }
        public string? QuanHuyenLop11 { get; set; }

        // Lớp 12
        public string? TruongHocLop12 { get; set; }
        public string? TinhThanhLop12 { get; set; }
        public string? QuanHuyenLop12 { get; set; }

        // Ưu tiên
        public string? KhuVucUuTien { get; set; }
        public string? DoiTuongUuTien { get; set; }

        // Chứng chỉ
        public string? ChungChi { get; set; }
        public string? DiemChungChi { get; set; }

        // Đánh giá năng lực
        public string? DanhGiaNangLuc { get; set; }
        public string? DiemDanhGiaNangLuc { get; set; }

        // Điểm các môn
        public string? Toan { get; set; }
        public string? NguVan { get; set; }
        public string? LichSu { get; set; }
        public string? DiaLy { get; set; }
        public string? GDCD { get; set; }
        public string? VatLy { get; set; }
        public string? HoaHoc { get; set; }
        public string? SinhHoc { get; set; }
        public string? CongNgheTinHoc { get; set; }
        public string? TiengAnh { get; set; }
        public string? TiengNga { get; set; }
        public string? TiengDuc { get; set; }
        public string? TiengTrung { get; set; }
        public string? TiengNhat { get; set; }
        public string? TiengHan { get; set; }
    }
}
