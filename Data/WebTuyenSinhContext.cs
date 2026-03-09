using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;

namespace WebTuyenSinh.Data
{
    public class WebTuyenSinhContext : DbContext
    {
        public WebTuyenSinhContext(DbContextOptions<WebTuyenSinhContext> options) : base(options) { }

        public DbSet<SinhVien> TaiKhoanSinhVien { get; set; }
        public DbSet<ThongTinSinhVien> ThongTinSinhVien { get; set; }
        public DbSet<ThongTinXetTuyen> ThongTinXetTuyen { get; set; }
        public DbSet<DangKyNguyenVong> DangKyNguyenVong { get; set; }
        public DbSet<NganhNghe> NganhNghe { get; set; }
        public DbSet<LichSuDangNhap> LichSuDangNhap { get; set; }  // ✅ Sửa đúng tên thuộc tính

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SinhVien>().ToTable("TaiKhoanSinhVien");
            modelBuilder.Entity<ThongTinSinhVien>().ToTable("ThongTinSinhVien");
            modelBuilder.Entity<ThongTinXetTuyen>().ToTable("ThongTinXetTuyen");
            modelBuilder.Entity<DangKyNguyenVong>().ToTable("DangKyNguyenVong");
            modelBuilder.Entity<NganhNghe>().ToTable("NganhNghe");
            modelBuilder.Entity<LichSuDangNhap>().ToTable("LichSuDangNhap");
        }
    }
}
