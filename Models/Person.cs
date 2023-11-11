using System;
using System.Collections.Generic;

namespace HotelManagement.Models
{
    public partial class Person
    {
        public Person()
        {
            OrderPhongs = new HashSet<OrderPhong>();
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public string PersonId { get; set; } = null!;
        public string? HoTen { get; set; }
        public int Tuoi { get; set; }
        public int GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public string? Cccd { get; set; }
        public string? Sdt { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }

        public virtual KhachHang? KhachHang { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
        public virtual ICollection<OrderPhong> OrderPhongs { get; set; }
    }
}
