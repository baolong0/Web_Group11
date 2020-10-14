using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_11.Models.data;

namespace Web_11.Models
{
    public class ChitietthongtincobanModel
    {
        public Doibong Doibong { get; set; }
        public Thongtincoban thongtincoban { get; set; }
        public Cauthu Cauthu { get; set; }
        public (string value, string display)[] ThanhTichLoai1 { get; set; }
        public (string value, string display)[] ThanhTichLoai2 { get; set; }
        public (string ID_cauThu, string Ten_Cau_Thu, string HA_Cau_Thu)[] Cauthuteam { get; set; }
    }
}
