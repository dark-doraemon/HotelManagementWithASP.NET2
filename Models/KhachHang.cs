using System;
using System.Collections.Generic;

namespace HotelManagement.Models
{
    public partial class KhachHang
    {
        public string KhachHangId { get; set; } = null!;

        public virtual Person KhachHangNavigation { get; set; } = null!;
    }
}
