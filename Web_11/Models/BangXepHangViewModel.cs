using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_11.Models.data;

namespace Web_11.Models
{
    public class BangXepHangViewModel
    {
        public IList<ThongTinXepHang> thongTinXepHangs { get; set; }
        public (string IDDoiBong, int? SoTran, int? Thang, int? Hoa, int? Thua, string HieuSo, int? Diem)[] listbangxephang { get; set; }
        public (string DoiBong, int? Diem)[] DiemXepHang { get; set; }
    }
}
