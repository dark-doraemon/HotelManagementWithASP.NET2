using System;
using System.Collections.Generic;

namespace HotelManagement.Models
{
    public partial class DichVu
    {
        public DichVu()
        {
            OrderPhongDichVus = new HashSet<OrderPhongDichVu>();
        }

        public string MaDichVu { get; set; } = null!;
        public string? TenDichVu { get; set; }
        public float GiaDichVu { get; set; }

        public virtual ICollection<OrderPhongDichVu> OrderPhongDichVus { get; set; }
    }
}
