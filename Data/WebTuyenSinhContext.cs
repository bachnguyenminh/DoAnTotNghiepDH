using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;

namespace WebTuyenSinh.Data
{
    public class WebTuyenSinhContext : DbContext
    {
        public WebTuyenSinhContext(DbContextOptions<WebTuyenSinhContext> options) : base(options) { }

        // Ánh xạ đến bảng TaiKhoanSinhVien trong CSDL
        public DbSet<SinhVien> TaiKhoanSinhVien { get; set; }

        // Ánh xạ đến bảng ThongTinSinhVien
        public DbSet<ThongTinSinhVien> ThongTinSinhVien { get; set; }

        // Ánh xạ đến bảng ThongTinXetTuyen
        public DbSet<ThongTinXetTuyen> ThongTinXetTuyen { get; set; }
        public DbSet<DangKyNguyenVong> DangKyNguyenVong { get; set; }
        public DbSet<NganhNghe> NganhNghe { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Trường hợp tên class ≠ tên bảng trong DB, ánh xạ thủ công
            modelBuilder.Entity<SinhVien>().ToTable("TaiKhoanSinhVien");
            modelBuilder.Entity<ThongTinSinhVien>().ToTable("ThongTinSinhVien");
            modelBuilder.Entity<ThongTinXetTuyen>().ToTable("ThongTinXetTuyen");
            modelBuilder.Entity<DangKyNguyenVong>().ToTable("DangKyNguyenVong");
            modelBuilder.Entity<NganhNghe>().ToTable("NganhNghe");
        }
    }
}
