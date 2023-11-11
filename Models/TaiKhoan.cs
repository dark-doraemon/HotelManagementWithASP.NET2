using System;
using System.Collections.Generic;

namespace HotelManagement.Models
{
    public partial class TaiKhoan
    {
        public string MaTaiKhoan { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string LoaiTaiKhoan { get; set; } = null!;
        public string PersonId { get; set; } = null!;

        public virtual LoaiTaiKhoan LoaiTaiKhoanNavigation { get; set; } = null!;
        public virtual Person Person { get; set; } = null!;
    }
}
