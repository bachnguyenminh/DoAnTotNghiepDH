using System.ComponentModel.DataAnnotations;

namespace WebTuyenSinh.Models
{
    public class NganhNghe
    {
        [Key]
        public string? MaNghe { get; set; }
        public string? TenNghe { get; set; }
        public string? TenNganh { get; set; }

        public string? ToHopMon { get; set; }

        public string? DiemDiemTrungTuyen { get; set; }
    }
}
