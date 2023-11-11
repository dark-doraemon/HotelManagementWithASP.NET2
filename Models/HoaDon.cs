using System;
using System.Collections.Generic;

namespace HotelManagement.Models
{
    public partial class HoaDon
    {
        public string MaHoaDon { get; set; } = null!;
        public DateTime? NgayIn { get; set; }
        public float TongTien { get; set; }
        public string MaOrderPhong { get; set; } = null!;

        public virtual OrderPhong MaOrderPhongNavigation { get; set; } = null!;
    }
}
