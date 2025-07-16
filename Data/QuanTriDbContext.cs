using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;

namespace WebTuyenSinh.Data
{
    public class QuanTriDbContext : DbContext
    {
        public QuanTriDbContext(DbContextOptions<QuanTriDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaiKhoanQuanTri> TaiKhoanQuanTri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Thiết lập TenDangNhap là khóa chính
            modelBuilder.Entity<TaiKhoanQuanTri>()
                .HasKey(t => t.TenDangNhap);

            // Cấu hình độ dài tối đa cho các cột (nếu cần)
            modelBuilder.Entity<TaiKhoanQuanTri>()
                .Property(t => t.TenDangNhap)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<TaiKhoanQuanTri>()
                .Property(t => t.MatKhau)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<TaiKhoanQuanTri>()
                .Property(t => t.QuyenHan)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<TaiKhoanQuanTri>()
                .Property(t => t.HoTen)
                .HasMaxLength(100);

            base.OnModelCreating(modelBuilder);
        }
    }
}
