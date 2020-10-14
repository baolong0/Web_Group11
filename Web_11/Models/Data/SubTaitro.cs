using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class SubTaitro
    {
        public int IdSubTt { get; set; }
        public string IdDoiBong { get; set; }
        public string IdTaiTro { get; set; }

        public virtual Doibong IdDoiBongNavigation { get; set; }
        public virtual Taitro IdTaiTroNavigation { get; set; }
    }
}
