using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_11.Models.data;

namespace Web_11.Models
{
    public class ThongTinCoBanViewModel
    {
        public (string IDTranDau, string srcLogoDoiNha, string srcLogoDoiKhach, DateTime? Thoigian, string SanVanDong)[] ListLichThiDau { get; set; }
        public IList<Trandau> trandaus { get; set; }
        public IList<Doibong> doibongs { get; set; }
        public IList<HinhanhQc> HinhanhQcs { get; set; }
        public IList<TinVideo> tinVideos { get; set; }
        public IList<Tintuc> Tintucs { get; set; }
        


    }
}
