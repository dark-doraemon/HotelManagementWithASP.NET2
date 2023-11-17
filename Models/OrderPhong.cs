using System;
using System.Collections.Generic;

namespace HotelManagement.Models
{
    public partial class OrderPhong
    {
        public OrderPhong()
        {
            HoaDons = new HashSet<HoaDon>();
            OrderPhongDichVus = new HashSet<OrderPhongDichVu>();
        }

        public string MaOrderPhong { get; set; } = null!;
        public DateTime? NgayDen { get; set; }
        public DateTime? NgayDi { get; set; }
        public string PersonId { get; set; } = null!;
        public string MaPhong { get; set; } = null!;
        public int TrangThaiThanhToan { get; set; }  = 0;

        public virtual Phong MaPhongNavigation { get; set; } = null!;
        public virtual Person Person { get; set; } = null!;
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual ICollection<OrderPhongDichVu> OrderPhongDichVus { get; set; }
    }
}