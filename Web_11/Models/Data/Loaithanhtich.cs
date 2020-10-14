using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Loaithanhtich
    {
        public Loaithanhtich()
        {
            Thanhtich = new HashSet<Thanhtich>();
        }

        public string IdLoaiThanhTich { get; set; }
        public string TenLoaiThanhTich { get; set; }

        public virtual ICollection<Thanhtich> Thanhtich { get; set; }
    }
}
