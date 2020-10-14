using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Noidung
    {
        public Noidung()
        {
            SubTintuc = new HashSet<SubTintuc>();
        }

        public int IdNoiDung { get; set; }
        public string TextNoiDung { get; set; }

        public virtual ICollection<SubTintuc> SubTintuc { get; set; }
    }
}
