using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Thongtincoban
    {
        public string IdThongTin { get; set; }
        public string DiaChi { get; set; }
        public string Hotline { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string SanVanDong { get; set; }
        public int? SucChua { get; set; }
        public string ChuTichClb { get; set; }
        public string Gđdh { get; set; }
        public string Hlvtruong { get; set; }
        public string Gđkt { get; set; }
        public string NhaTaiTro { get; set; }
        public string IdDoiBong { get; set; }

        public virtual Doibong IdDoiBongNavigation { get; set; }
    }
}
