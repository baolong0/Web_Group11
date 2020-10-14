using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_11.Models.data;

namespace Web_11.Models
{
    public class TicketsViewsModel
    {
        public (string IDve, string srcLogoDoiNha, string srcLogoDoiKhach, DateTime? Thoigian)[] ListVeVsLogo { get; set; }
        public (string IDve, string srcLogoDoiNha, string srcLogoDoiKhach, DateTime? Thoigian) VeDuocChon { get; set; }
        public List<HinhanhQc> hinhanhQcs { get; set; }
        public List<Trandau> trandaus { get; set; }
        public List<Ticket> tickets { get; set; }
        public List<Doibong> doibongs { get; set; }
    }
}
