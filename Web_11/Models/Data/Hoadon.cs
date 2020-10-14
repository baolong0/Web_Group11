using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Cthd = new HashSet<Cthd>();
        }

        public string IdHoaDon { get; set; }
        public string IdKhachHang { get; set; }
        public DateTime? ThoiGian { get; set; }

        public virtual Khachhang IdKhachHangNavigation { get; set; }
        public virtual ICollection<Cthd> Cthd { get; set; }
    }
}
