using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class SubCauthu
    {
        public int IdSubCt { get; set; }
        public string IdDoiBong { get; set; }
        public string IdCauThu { get; set; }

        public virtual Cauthu IdCauThuNavigation { get; set; }
        public virtual Doibong IdDoiBongNavigation { get; set; }
    }
}
