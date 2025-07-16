using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebTuyenSinh.ViewModels
{
    public class TuVanTuyenSinhVM
    {
        [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
        [Display(Name = "Họ và tên")]
        public string HoVaTen { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày tháng năm sinh")]
        [DataType(DataType.Date)]
        [Display(Name = "Năm sinh")]
        public DateTime? NamSinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? DiaChi { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Gmail")]
        [Display(Name = "Gmail")]
        public string Gmail { get; set; }

        [Display(Name = "Trình độ học vấn")]
        public string? TrinhDoHocVan { get; set; }

        [Display(Name = "Đang học trường")]
        public string? DangHocTruong { get; set; }

        [Display(Name = "Ngành học quan tâm")]
        public string? NganhHocQuanTam { get; set; }

        [Display(Name = "Họ tên phụ huynh")]
        public string? HoTenPhuHuynh { get; set; }

        [Display(Name = "Số điện thoại phụ huynh")]
        public string? SoDienThoaiPhuHuynh { get; set; }

        [Display(Name = "Người phụ trách")]
        public string? NguoiPhuTrach { get; set; }

        [Display(Name = "Trạng thái")]
        public string? TrangThai { get; set; }

        [Display(Name = "Ghi chú")]
        public string? GhiChu { get; set; }

        // Danh sách phục vụ dropdown
        public List<SelectListItem> DanhSachNganhNghe { get; set; } = new();
        public List<SelectListItem> DanhSachQuanTriVien { get; set; } = new();
    }
}
