using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Hinhanh
    {
        public Hinhanh()
        {
            SubTintuc = new HashSet<SubTintuc>();
        }

        public int IdHinhAnh { get; set; }
        public string SourceHinhAnh { get; set; }

        public virtual ICollection<SubTintuc> SubTintuc { get; set; }
    }
}
