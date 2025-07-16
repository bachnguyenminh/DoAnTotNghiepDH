using System.ComponentModel.DataAnnotations;

namespace WebTuyenSinh.ViewModels
{
    public class ThongTinXetTuyenVM
    {
        [Required(ErrorMessage = "CCCD không được để trống")]
        public string CCCD { get; set; }

        // Trường học lớp 10
        [Required(ErrorMessage = "Tên trường lớp 10 không được để trống")]
        public string TruongHocLop10 { get; set; }

        [Required(ErrorMessage = "Tỉnh/Thành lớp 10 không được để trống")]
        public string TinhThanhLop10 { get; set; }

        [Required(ErrorMessage = "Quận/Huyện lớp 10 không được để trống")]
        public string QuanHuyenLop10 { get; set; }

        // Trường học lớp 11
        public string? TruongHocLop11 { get; set; }
        public string? TinhThanhLop11 { get; set; }
        public string? QuanHuyenLop11 { get; set; }

        // Trường học lớp 12
        public string? TruongHocLop12 { get; set; }
        public string? TinhThanhLop12 { get; set; }
        public string? QuanHuyenLop12 { get; set; }

        // Checkbox giống lớp 10
        public bool GiongLop10_Lop11 { get; set; }
        public bool GiongLop10_Lop12 { get; set; }

        // Ưu tiên
        public string? KhuVucUuTien { get; set; }
        public string? DoiTuongUuTien { get; set; }

        // Chứng chỉ
        public string? ChungChi { get; set; }
        public string? DiemChungChi { get; set; }

        // Đánh giá năng lực
        public string? DanhGiaNangLuc { get; set; }
        public string? DiemDanhGiaNangLuc { get; set; }

        // Điểm các môn (có thể để trống nếu không đăng ký theo điểm)
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

        // Dropdown hỗ trợ
        public List<string> DanhSachChungChi { get; set; } = new();
        public List<string> DanhSachDanhGiaNangLuc { get; set; } = new();
    }
}
