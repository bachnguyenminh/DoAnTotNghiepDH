using WebTuyenSinh.Models;

namespace WebTuyenSinh.ViewModels
{
    public class PhieuDangKyViewModel
    {
        public SinhVien? TaiKhoan { get; set; }
        public ThongTinSinhVien? ThongTin { get; set; }
        public ThongTinXetTuyen? ThongTinXetTuyen { get; set; }
        public DangKyNguyenVong?NguyenVong { get; set; }
    }
}
