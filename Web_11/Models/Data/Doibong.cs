using System;
using System.Collections.Generic;

namespace Web_11.Models.data
{
    public partial class Doibong
    {
        public Doibong()
        {
            Cauthu = new HashSet<Cauthu>();
            SubTaitro = new HashSet<SubTaitro>();
            Thanhtich = new HashSet<Thanhtich>();
            ThongTinXepHang = new HashSet<ThongTinXepHang>();
            Thongtincoban = new HashSet<Thongtincoban>();
            TicketDoiKhachNavigation = new HashSet<Ticket>();
            TicketDoiNhaNavigation = new HashSet<Ticket>();
            TrandauDoiKhachNavigation = new HashSet<Trandau>();
            TrandauDoiNhaNavigation = new HashSet<Trandau>();
        }

        public string IdDoiBong { get; set; }
        public string TenDoi { get; set; }
        public string SourceLogo { get; set; }
        public string SourceBanner { get; set; }

        public virtual ICollection<Cauthu> Cauthu { get; set; }
        public virtual ICollection<SubTaitro> SubTaitro { get; set; }
        public virtual ICollection<Thanhtich> Thanhtich { get; set; }
        public virtual ICollection<ThongTinXepHang> ThongTinXepHang { get; set; }
        public virtual ICollection<Thongtincoban> Thongtincoban { get; set; }
        public virtual ICollection<Ticket> TicketDoiKhachNavigation { get; set; }
        public virtual ICollection<Ticket> TicketDoiNhaNavigation { get; set; }
        public virtual ICollection<Trandau> TrandauDoiKhachNavigation { get; set; }
        public virtual ICollection<Trandau> TrandauDoiNhaNavigation { get; set; }
    }
}
