using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Loaive
    {
        public Loaive()
        {
            Ticket = new HashSet<Ticket>();
        }

        public string IdLoaiVe { get; set; }
        public string TenLoaiVe { get; set; }
        public int? SoLuong { get; set; }
        public int? GiaVe { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
