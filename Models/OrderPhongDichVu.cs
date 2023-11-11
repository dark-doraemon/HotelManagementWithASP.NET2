using System;
using System.Collections.Generic;

namespace HotelManagement.Models
{
    public partial class OrderPhongDichVu
    {
        public string MaOrderPhong { get; set; } = null!;
        public string MaDichVu { get; set; } = null!;
        public int? SoLuong { get; set; }
        public float? DonGia { get; set; }

        public virtual DichVu MaDichVuNavigation { get; set; } = null!;
        public virtual OrderPhong MaOrderPhongNavigation { get; set; } = null!;
    }
}
