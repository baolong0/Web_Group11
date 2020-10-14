using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class SubTinVideo
    {
        public int IdSubTinVideo { get; set; }
        public string IdTinVideo { get; set; }
        public int? IdVideo { get; set; }

        public virtual TinVideo IdTinVideoNavigation { get; set; }
        public virtual Video IdVideoNavigation { get; set; }
    }
}
