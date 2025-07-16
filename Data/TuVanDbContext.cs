using Microsoft.EntityFrameworkCore;
using WebTuyenSinh.Models;

namespace WebTuyenSinh.Data
{
    public class TuVanDbContext : DbContext
    {
        public TuVanDbContext(DbContextOptions<TuVanDbContext> options) : base(options) { }

        public DbSet<TuVanTuyenSinh> TuVanTuyenSinh { get; set; }
        public DbSet<NganhNghe> NganhNghe { get; set; }
        public DbSet<TaiKhoanQuanTri> TaiKhoanQuanTri { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TuVanTuyenSinh>().ToTable("TuVanTuyenSinh");
            modelBuilder.Entity<NganhNghe>().ToTable("NganhNghe");
            modelBuilder.Entity<TaiKhoanQuanTri>().ToTable("TaiKhoanQuanTri");

        }
    }
}
