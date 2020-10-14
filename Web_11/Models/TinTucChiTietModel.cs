using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_11.Models.data;

namespace Web_11.Models
{
    public class TinTucChiTietModel
    {
        public Tintuc Tintucs { get; set; }
        public TinVideo TinVideo { get; set; }
        public (string value, string display)[] VideoTinVideo { get; set; }
        public (string value, string display)[] NoiDungTin { get; set; }
        public (string value, string display)[] HashtagTin { get; set; }
        public (string value, string display)[] HinhAnhTin { get; set; }
      

    }
}
