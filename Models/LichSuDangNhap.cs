using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTuyenSinh.Models
{
    [Table("LichSuDangNhap")]
    public class LichSuDangNhap
    {
        [Key]
        public string? CCCD { get; set; }

        public string? LichSu { get; set; }
    }
}
