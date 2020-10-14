using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_11.Models.data;

namespace Web_11.Models
{
    public class TinTucModel
    {
        public IList<Tintuc> Tintucs { get; set; }

        public string Loc { get; private set; }
        public (string value, string display)[] ListLoc => new[] {
            ("Week", "Tuần này"),
            ("Mon", "Tháng Này"), 
            ("year", "Năm Này"), 
            ("all", "Tất Cả" )};
            public void OnPost(string loc) => Loc = loc;
        //public void OnPost() => Country = Request.Form["country"];
        public string TrangThai { get; private set; }
        public (string value, string display)[] ListTrangThai => new[] {
            ("Hiển Thị", "Hiển Thị"),
            ("Không Hiển Thị", "Không Hiển Thị"),
            ("all", "Tất Cả" )};
        public string SapXep { get; private set; }
        public (string value, string display)[] ListSapXep => new[] {
            ("Tương Tác", "Lượt tương tác"),
            ("Giảm Dần", "Lượt tương tác giảm dần"),
            ("all", "Tất Cả" )};
    }
}



