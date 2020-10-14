using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class ThongTinXepHang
    {
        public int IdThuTu { get; set; }
        public string IdDoiBong { get; set; }
        public int? SoTran { get; set; }
        public int? Thang { get; set; }
        public int? Hoa { get; set; }
        public int? Thua { get; set; }
        public string HieuSo { get; set; }
        public int? Diem { get; set; }

        public virtual Doibong IdDoiBongNavigation { get; set; }
    }
}
