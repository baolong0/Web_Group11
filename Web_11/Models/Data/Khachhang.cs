using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Hoadon = new HashSet<Hoadon>();
        }

        public string IdKhachHang { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }

        public virtual ICollection<Hoadon> Hoadon { get; set; }
    }
}
