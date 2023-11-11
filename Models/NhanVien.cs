using System;
using System.Collections.Generic;

namespace HotelManagement.Models
{
    public partial class NhanVien
    {
        public string NhanVienId { get; set; } = null!;
        public string MaVaiTro { get; set; } = null!;
        public DateTime? NgayDuocTuyen { get; set; }

        public virtual VaiTro MaVaiTroNavigation { get; set; } = null!;
        public virtual Person NhanVienNavigation { get; set; } = null!;
    }
}
