using System;
using System.Collections.Generic;

namespace HotelManagement.Models
{
    public partial class TrangThaiPhong
    {
        public TrangThaiPhong()
        {
            Phongs = new HashSet<Phong>();
        }

        public string MaTrangThai { get; set; } = null!;
        public string? TenTrangThai { get; set; }

        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
