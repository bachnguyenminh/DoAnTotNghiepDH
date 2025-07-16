using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;

namespace WebTuyenSinh.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<SinhVien> TaiKhoanSinhVien { get; set; }
        public DbSet<ThongTinSinhVien> ThongTinSinhVien { get; set; }
    }
}