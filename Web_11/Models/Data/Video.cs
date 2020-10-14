using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Video
    {
        public Video()
        {
            SubTinVideo = new HashSet<SubTinVideo>();
        }

        public int IdVideo { get; set; }
        public string SourceVideo { get; set; }

        public virtual ICollection<SubTinVideo> SubTinVideo { get; set; }
    }
}
