using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Ticket
    {
        public Ticket()
        {
            Cthd = new HashSet<Cthd>();
        }

        public string IdVe { get; set; }
        public string IdLoaiVe { get; set; }
        public string DoiNha { get; set; }
        public string DoiKhach { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }

        public virtual Doibong DoiKhachNavigation { get; set; }
        public virtual Doibong DoiNhaNavigation { get; set; }
        public virtual Loaive IdLoaiVeNavigation { get; set; }
        public virtual ICollection<Cthd> Cthd { get; set; }
    }
}
