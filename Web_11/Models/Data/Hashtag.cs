using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Hashtag
    {
        public Hashtag()
        {
            SubTintuc = new HashSet<SubTintuc>();
        }

        public int IdHashtag { get; set; }
        public string Hashtag1 { get; set; }

        public virtual ICollection<SubTintuc> SubTintuc { get; set; }
    }
}
