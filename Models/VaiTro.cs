using System;
using System.Collections.Generic;

namespace HotelManagement.Models
{
    public partial class VaiTro
    {
        public VaiTro()
        {
            NhanViens = new HashSet<NhanVien>();

        }


        public string MaVaiTro { get; set; } = null!;
        public string? TenVaiTro { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
