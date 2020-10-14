using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Trandau
    {
        public Trandau()
        {
            Banthang = new HashSet<Banthang>();
        }

        public string IdTranDau { get; set; }
        public string DoiNha { get; set; }
        public string DoiKhach { get; set; }
        public DateTime? ThoiGianThiDau { get; set; }
        public string SanThiDau { get; set; }
        public string TiSo { get; set; }

        public virtual Doibong DoiKhachNavigation { get; set; }
        public virtual Doibong DoiNhaNavigation { get; set; }
        public virtual ICollection<Banthang> Banthang { get; set; }
    }
}
