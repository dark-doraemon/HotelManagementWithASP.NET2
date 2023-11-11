using System;
using System.Collections.Generic;

namespace HotelManagement.Models
{
    public partial class LoaiPhong
    {
        public LoaiPhong()
        {
            Phongs = new HashSet<Phong>();
        }

        public string MaLoaiPhong { get; set; } = null!;
        public string? TenLoaiPhong { get; set; }
        public float GiaPhong { get; set; }

        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
