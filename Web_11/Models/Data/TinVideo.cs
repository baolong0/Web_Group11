using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class TinVideo
    {
        public TinVideo()
        {
            SubTinVideo = new HashSet<SubTinVideo>();
        }

        public string IdTinVideo { get; set; }
        public string TieuDeVideo { get; set; }
        public string AvatarVideo { get; set; }
        public string TomTatVideo { get; set; }
        public int? LuotTuongTacVideo { get; set; }
        public int? LuotXemVideo { get; set; }
        public string TrangThaiHienThiVideo { get; set; }

        public virtual ICollection<SubTinVideo> SubTinVideo { get; set; }
    }
}
