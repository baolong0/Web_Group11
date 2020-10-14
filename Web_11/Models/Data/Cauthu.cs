using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Cauthu
    {
        public Cauthu()
        {
            Banthang = new HashSet<Banthang>();
        }

        public string IdCauThu { get; set; }
        public string TenCauThu { get; set; }
        public string SourceHact { get; set; }
        public string IdDoiBong { get; set; }

        public virtual Doibong IdDoiBongNavigation { get; set; }
        public virtual ICollection<Banthang> Banthang { get; set; }
    }
}
