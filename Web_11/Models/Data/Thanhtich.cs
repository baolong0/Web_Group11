using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Thanhtich
    {
        public string IdThanhTich { get; set; }
        public string TenThanhTich { get; set; }
        public string IdLoaiThanhTich { get; set; }
        public string IdDoiBong { get; set; }

        public virtual Doibong IdDoiBongNavigation { get; set; }
        public virtual Loaithanhtich IdLoaiThanhTichNavigation { get; set; }
    }
}
