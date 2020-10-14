using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Cthd
    {
        public string IdHoaDon { get; set; }
        public string IdVe { get; set; }
        public int? SoLuong { get; set; }

        public virtual Hoadon IdHoaDonNavigation { get; set; }
        public virtual Ticket IdVeNavigation { get; set; }
    }
}
