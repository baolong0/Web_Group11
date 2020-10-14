using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Banthang
    {
        public string IdBanThang { get; set; }
        public string IdCauThu { get; set; }
        public string IdTranDau { get; set; }
        public DateTime? ThoiDiem { get; set; }

        public virtual Cauthu IdCauThuNavigation { get; set; }
        public virtual Trandau IdTranDauNavigation { get; set; }
    }
}
