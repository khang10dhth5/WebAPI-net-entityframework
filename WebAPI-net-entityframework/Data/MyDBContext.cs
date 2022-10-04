using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_net_entityframework.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {

        }
        #region DbSet
        public DbSet<HangHoaData> HangHoas { get; set; }
        public DbSet<LoaiData> Loais { get; set; }
        public DbSet<DonHangData> DonHangs { get; set; }
        public DbSet<ChiTietDHData> DonHangChiTiets { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<LoaiData>(e =>
            {
                e.ToTable("Loai");
                e.HasKey(dh => dh.MaLoai);

            });
            model.Entity<HangHoaData>(e =>
            {
                e.ToTable("HangHoa");
                e.HasKey(dh => dh.MaHH);
                e.HasOne(e => e.Loai)
                 .WithMany(e => e.HangHoas)
                 .HasForeignKey(e => e.MaLoai)
                 .HasConstraintName("FK_HANGHOA_LOAI");

            });
            model.Entity<DonHangData>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDH);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
            });
            model.Entity<ChiTietDHData>(en =>
            {
                en.ToTable("ChiTietDH");
                en.HasKey(e => new
                {
                    e.MaDH,
                    e.MaHH
                });
                en.HasOne(e => e.DonHang)
                  .WithMany(e => e.DHChiTiets)
                  .HasForeignKey(e => e.MaDH)
                  .HasConstraintName("FK_CHITIETDH_DONHANG");

                en.HasOne(e => e.HangHoa)
                  .WithMany(e => e.DHChiTiets)
                  .HasForeignKey(e => e.MaHH)
                  .HasConstraintName("FK_CHITIETDH_HANGHOA");
            });
        }
    }
}
