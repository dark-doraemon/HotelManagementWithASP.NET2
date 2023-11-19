using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelManagement.Models
{
    public partial class HotelContext : DbContext
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {

        }

        public virtual DbSet<DichVu> DichVus { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; } = null!;
        public virtual DbSet<LoaiTaiKhoan> LoaiTaiKhoans { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<OrderPhong> OrderPhongs { get; set; } = null!;
        public virtual DbSet<OrderPhongDichVu> OrderPhongDichVus { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Phong> Phongs { get; set; } = null!;
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;
        public virtual DbSet<TrangThaiPhong> TrangThaiPhongs { get; set; } = null!;
        public virtual DbSet<VaiTro> VaiTros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Hotel;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DichVu>(entity =>
            {
                entity.HasKey(e => e.MaDichVu)
                    .HasName("PK__Dich_Vu__C0E6DE8FC72B2A69");

                entity.ToTable("Dich_Vu");

                entity.Property(e => e.MaDichVu).HasMaxLength(255);

                entity.Property(e => e.TenDichVu).HasMaxLength(255);
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon)
                    .HasName("PK__Hoa_Don__835ED13B118615AA");

                entity.ToTable("Hoa_Don");

                entity.Property(e => e.MaHoaDon).HasMaxLength(255);

                entity.Property(e => e.MaOrderPhong).HasMaxLength(255);

                entity.Property(e => e.NgayIn).HasColumnType("datetime");

                entity.HasOne(d => d.MaOrderPhongNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaOrderPhong)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKHoa_Don624260");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.ToTable("Khach_Hang");

                entity.Property(e => e.KhachHangId)
                    .HasMaxLength(255)
                    .HasColumnName("KhachHang_ID");

                entity.HasOne(d => d.KhachHangNavigation)
                    .WithOne(p => p.KhachHang)
                    .HasForeignKey<KhachHang>(d => d.KhachHangId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKKhach_Hang279424");
            });


           

            modelBuilder.Entity<LoaiPhong>(entity =>
            {
                entity.HasKey(e => e.MaLoaiPhong)
                    .HasName("PK__Loai_Pho__23021217A48C92C2");


                entity.ToTable("Loai_Phong");

                entity.Property(e => e.MaLoaiPhong).HasMaxLength(255);

                entity.Property(e => e.TenLoaiPhong).HasMaxLength(255);
            });

            modelBuilder.Entity<LoaiTaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaLoaiTaiKhoan)
                    .HasName("PK__Loai_Tai__5F6E141C07C4DC2B");

                entity.ToTable("Loai_Tai_Khoan");

                entity.Property(e => e.MaLoaiTaiKhoan).HasMaxLength(255);

                entity.Property(e => e.TenLoai).HasMaxLength(255);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.ToTable("Nhan_Vien");

                entity.Property(e => e.NhanVienId)
                    .HasMaxLength(255)
                    .HasColumnName("NhanVienID");

                entity.Property(e => e.MaVaiTro).HasMaxLength(255);

                entity.Property(e => e.NgayDuocTuyen).HasColumnType("datetime");

                entity.HasOne(d => d.MaVaiTroNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaVaiTro)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKNhan_Vien799741");

                entity.HasOne(d => d.NhanVienNavigation)
                    .WithOne(p => p.NhanVien)
                    .HasForeignKey<NhanVien>(d => d.NhanVienId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKNhan_Vien605300");
            });

            modelBuilder.Entity<OrderPhong>(entity =>
            {
                entity.HasKey(e => e.MaOrderPhong)
                    .HasName("PK__Order_Ph__829E7C7605A5F40A");

                entity.ToTable("Order_Phong");

                entity.Property(e => e.MaOrderPhong).HasMaxLength(255);

                entity.Property(e => e.MaPhong).HasMaxLength(255);

                entity.Property(e => e.NgayDen).HasColumnType("datetime");

                entity.Property(e => e.NgayDi).HasColumnType("datetime");

                //entity.Property(e => e.TrangThaiThanhToan).HasColumnType("int");

                entity.Property(e => e.PersonId)
                    .HasMaxLength(255)
                    .HasColumnName("PersonID");

                entity.HasOne(d => d.MaPhongNavigation)
                     .WithMany(p => p.OrderPhongs)
                     .HasForeignKey(d => d.MaPhong)
                     .OnDelete(DeleteBehavior.Cascade)
                     .HasConstraintName("FKOrder_Phon460975");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.OrderPhongs)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKOrder_Phon746646");
            });

            modelBuilder.Entity<OrderPhongDichVu>(entity =>
            {
                entity.HasKey(e => new { e.MaOrderPhong, e.MaDichVu })
                    .HasName("PK__Order_Ph__6E90119E9EC16A77");

                entity.ToTable("Order_Phong_Dich_Vu");

                entity.Property(e => e.MaOrderPhong).HasMaxLength(255);

                entity.Property(e => e.MaDichVu).HasMaxLength(255);

                entity.HasOne(d => d.MaDichVuNavigation)
                    .WithMany(p => p.OrderPhongDichVus)
                    .HasForeignKey(d => d.MaDichVu)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKOrder_Phon597344");

                entity.HasOne(d => d.MaOrderPhongNavigation)
                    .WithMany(p => p.OrderPhongDichVus)
                    .HasForeignKey(d => d.MaOrderPhong)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKOrder_Phon17642");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.PersonId)
                    .HasMaxLength(255)
                    .HasColumnName("PersonID");

                entity.Property(e => e.Cccd)
                    .HasMaxLength(255)
                    .HasColumnName("CCCD");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.HoTen).HasMaxLength(255);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("SDT");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.MaPhong)
                    .HasName("PK__Phong__20BD5E5B177E3D28");

                entity.ToTable("Phong");

                entity.Property(e => e.MaPhong).HasMaxLength(255);

                entity.Property(e => e.MaLoaiPhong).HasMaxLength(255);

                entity.Property(e => e.MaTrangThai).HasMaxLength(255);

                entity.Property(e => e.MoTaPhong).HasMaxLength(255);

                entity.Property(e => e.TenPhong).HasMaxLength(255);

                entity.HasOne(d => d.MaLoaiPhongNavigation)
                    .WithMany(p => p.Phongs)
                    .HasForeignKey(d => d.MaLoaiPhong)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKPhong134689");

                entity.HasOne(d => d.MaTrangThaiNavigation)
                    .WithMany(p => p.Phongs)
                    .HasForeignKey(d => d.MaTrangThai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPhong128242");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaTaiKhoan)
                    .HasName("PK__Tai_Khoa__AD7C6529EF10FB2D");

                entity.ToTable("Tai_Khoan");

                entity.Property(e => e.MaTaiKhoan).HasMaxLength(255);

                entity.Property(e => e.LoaiTaiKhoan).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PersonId)
                    .HasMaxLength(255)
                    .HasColumnName("PersonID");

                entity.Property(e => e.UserName).HasMaxLength(255);

                entity.HasOne(d => d.LoaiTaiKhoanNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.LoaiTaiKhoan)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKTai_Khoan92928");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKTai_Khoan172310");
            });

            modelBuilder.Entity<TrangThaiPhong>(entity =>
            {
                entity.HasKey(e => e.MaTrangThai)
                    .HasName("PK__Trang_Th__AADE41383344BB34");

                entity.ToTable("Trang_Thai_Phong");

                entity.Property(e => e.MaTrangThai).HasMaxLength(255);

                entity.Property(e => e.TenTrangThai).HasMaxLength(255);
            });

            modelBuilder.Entity<VaiTro>(entity =>
            {
                entity.HasKey(e => e.MaVaiTro)
                    .HasName("PK__Vai_Tro__C24C41CFA446BD32");

                entity.ToTable("Vai_Tro");

                entity.Property(e => e.MaVaiTro).HasMaxLength(255);

                entity.Property(e => e.TenVaiTro).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
