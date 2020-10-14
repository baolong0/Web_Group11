using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_11.Models;
using Web_11.Models.data;

namespace Web_11.Controllers
{
    public class ThongtincobansController : Controller
    {
        private IList<Cauthu> Cauthus { get; set; }
        private Thongtincoban thongtincoban { get; set; }
        private Doibong Doibong { get; set; }
        private IList<Thanhtich> Thanhtiches { get; set; }
        private IList<SubTinVideo> subTinVideos { get; set; }
        private IList<Video> Videos { get; set; }
        private TinVideo TinVideo { get; set; }
        private IList<SubTintuc> subTintucs { get; set; }
        private IList<Hashtag> Hashtags { get; set; }
        private Tintuc Tintucs { get; set; }
        public Video[] Video { get; private set; }
        private IList<Noidung> NoiDungs { get; set; }
        private IList<Hinhanh> Hinhanhs { get; set; }
        int?[] listIDVideo = new int?[100];
        int?[] listIDnoiDung = new int?[100];
        int?[] listIDHinhAnh = new int?[100];
        int?[] listIDHashtag = new int?[100];
        string[] listIDThanhTichloai1 = new string[100];
        string[] listIDThanhTichloai2 = new string[100];
        string[] listCauThu = new string[100];

        public (string value, string display)[] VideoTinVideo { get; set; }
        public (string value, string display)[] NoiDungTin { get; set; }
        public (string value, string display)[] HashtagTin { get; set; }
        public (string value, string display)[] HinhAnhTin { get; set; }
        public(string value, string display)[] ThanhTichLoai1 { get; set; }
        public (string value, string display)[] ThanhTichLoai2 { get; set; }
        public (string ID_cauThu, string Ten_Cau_Thu, string HA_Cau_Thu)[] Cauthuteam { get; set; }
        public List<Doibong> doibongs { get; set; }
        public (string IDTranDau, string srcLogoDoiNha, string srcLogoDoiKhach, DateTime? Thoigian ,string SanVanDong)[] ListLichThiDau { get; set; }
        private readonly FootballNewsContext _context; 

        public ThongtincobansController(FootballNewsContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ThongTinCoBanViewModel thongTinCoBanViewModel = new ThongTinCoBanViewModel();
            thongTinCoBanViewModel.doibongs = _context.Doibong.ToArray();
            thongTinCoBanViewModel.trandaus = _context.Trandau.ToArray();
            thongTinCoBanViewModel.HinhanhQcs = _context.HinhanhQc.ToArray();
            thongTinCoBanViewModel.Tintucs = _context.Tintuc.ToArray();
            thongTinCoBanViewModel.tinVideos = _context.TinVideo.ToArray();
            thongTinCoBanViewModel.ListLichThiDau = Getlichthidau();
            return View (thongTinCoBanViewModel);
        }
        public (string IDTranDau, string srcLogoDoiNha, string srcLogoDoiKhach, DateTime? Thoigian , string SanVanDong)[] Getlichthidau()
        {
            List<Trandau> tempTranDau = _context.Trandau.ToList();
            int temp = 0;
            ListLichThiDau = new (string IDTranDau, string srcLogoDoiNha, string srcLogoDoiKhach, DateTime? Thoigian, string SanVanDong)[100];
            foreach(var item in tempTranDau)
            {
                ListLichThiDau[temp] = (item.IdTranDau, GetLogoSrc(item.DoiNha), GetLogoSrc(item.DoiKhach), item.ThoiGianThiDau ,item.SanThiDau);
                temp++;
            }
            return ListLichThiDau;

        }
        public string GetLogoSrc(string id)
        {
            string temp = "";
            foreach (var item in _context.Doibong)
            {
                if (item.IdDoiBong == id)
                {
                    temp = item.SourceLogo;
                }

            }
            return temp;
        }
        public Thongtincoban GetThongtincoban(string id)
        {
            foreach(var item in _context.Thongtincoban)
            {
                if (item.IdDoiBong == id)
                {
                    thongtincoban = item;
                }
            }
            return thongtincoban;
        }
        public Doibong GetDoibong(string id)
        {
            foreach(var item in _context.Doibong)
            {
                if (item.IdDoiBong == id)
                {
                    Doibong = item;
                }
            }
            return Doibong;
        }
        
        public async Task<IActionResult> DetailsTTDB(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ChitietthongtincobanModel chitietthongtincobanModel = new ChitietthongtincobanModel();
            chitietthongtincobanModel.thongtincoban = GetThongtincoban(id);
            chitietthongtincobanModel.Doibong = GetDoibong(id);
            chitietthongtincobanModel.ThanhTichLoai1 = GetThanhTichLoai1(id);
            chitietthongtincobanModel.ThanhTichLoai2 = GetThanhTichLoai2(id);
            chitietthongtincobanModel.Cauthuteam = GetCauThuTeam(id);
            return View(chitietthongtincobanModel);

        }
        public async Task<IActionResult> DetailsTinTuc(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TinTucChiTietModel tinTucChiTietModel = new TinTucChiTietModel();
            tinTucChiTietModel.Tintucs = GetTintuc(id);
            tinTucChiTietModel.NoiDungTin = GetNoiDungTintuc(id);
            tinTucChiTietModel.HinhAnhTin = GetHinhAnhTintuc(id);
            tinTucChiTietModel.HashtagTin = GetHashTagTintuc(id);
            return View(tinTucChiTietModel);
        }
        public TinVideo GetTinVideo(string id)
        {
            foreach (var item in _context.TinVideo)
            {
                if (item.IdTinVideo == id)
                {
                    TinVideo = item;
                }
            }
            return TinVideo;
        }
        public Tintuc GetTintuc(string id)
        {
            foreach (var item in _context.Tintuc)
            {
                if (item.IdTinTuc == id)
                {
                    Tintucs = item;
                }
            }
            return Tintucs;
        }
        public (string value, string display)[] GetNoiDungTintuc(string id)
        {
            int temp = 0;
            subTintucs = _context.SubTintuc.ToArray();
            NoiDungs = _context.Noidung.ToArray();
            NoiDungTin = new (string value, string display)[100];
            foreach (var item in _context.SubTintuc)
            {
                if (item.IdTintuc == id & item.IdNoiDung != null)
                {
                    listIDnoiDung[temp] = item.IdNoiDung;
                    temp++;
                }
            }
            temp = 0;
            foreach (var item in NoiDungs)
            {
                if (item.IdNoiDung == listIDnoiDung[temp])
                {
                    NoiDungTin[temp] = (item.IdNoiDung.ToString(), item.TextNoiDung);
                    temp++;
                }
            }
            return NoiDungTin;
        }
        public (string value, string display)[] GetHinhAnhTintuc(string id)
        {
            int temp = 0;
            HinhAnhTin = new (string value, string display)[100];
            subTintucs = _context.SubTintuc.ToArray();
            Hinhanhs = _context.Hinhanh.ToArray();
            foreach (var item in _context.SubTintuc)
            {
                if (item.IdTintuc == id & item.IdHinhAnh != null)
                {
                    listIDHinhAnh[temp] = item.IdHinhAnh;
                    temp++;
                }
            }

            temp = 0;
            foreach (var item in Hinhanhs)
            {
                if (item.IdHinhAnh == listIDHinhAnh[temp])
                {
                    temp++;
                    HinhAnhTin[temp] = (item.IdHinhAnh.ToString(), item.SourceHinhAnh);
                }
            }
            return HinhAnhTin;
        }
        public (string value, string display)[] GetHashTagTintuc(string id)
        {
            int temp = 0;
            HashtagTin = new (string value, string display)[100];
            //subTintucs = _context.SubTintuc.ToArray();
            Hashtags = _context.Hashtag.ToArray();
            foreach (var item in _context.SubTintuc)
            {
                if (item.IdTintuc == id & item.IdHashtag != null)
                {
                    listIDHashtag[temp] = item.IdHashtag;
                    temp++;
                }
            }

            temp = 0;
            foreach (var item in Hashtags)
            {
                if (item.IdHashtag == listIDHashtag[temp])
                {
                    temp++;
                    HashtagTin[temp] = (item.IdHashtag.ToString(), item.Hashtag1);
                }
            }
            return HashtagTin;
        }

        public (string value, string display)[] GetThanhTichLoai1(string id)
        {
            int temp = 0;
            ThanhTichLoai1 = new (string value, string display)[100];
            Thanhtiches= _context.Thanhtich.ToArray();
            foreach (var item in _context.Thanhtich)
            {
                if (item.IdDoiBong == id & item.IdLoaiThanhTich == "LOAITHANHTICH01")
                {
                    listIDThanhTichloai1[temp] = item.IdThanhTich;
                    temp++;
                }
            }

            temp = 0;
            foreach (var item in Thanhtiches)
            {
                if (item.IdThanhTich == listIDThanhTichloai1[temp])
                {
                    temp++;
                    ThanhTichLoai1[temp] = (item.IdThanhTich, item.TenThanhTich);
                }
            }
            return ThanhTichLoai1;
        }

        public (string value, string display)[] GetThanhTichLoai2(string id)
        {
            int temp = 0;
            ThanhTichLoai2 = new (string value, string display)[100];           
            Thanhtiches = _context.Thanhtich.ToArray();
            foreach (var item in _context.Thanhtich)
            {
                if (item.IdDoiBong == id & item.IdLoaiThanhTich == "LOAITHANHTICH02")
                {
                    listIDThanhTichloai2[temp] = item.IdThanhTich;
                    temp++;
                }
            }

            temp = 0;
            foreach (var item in Thanhtiches)
            {
                if (item.IdThanhTich == listIDThanhTichloai2[temp])
                {
                    temp++;
                    ThanhTichLoai2[temp] = (item.IdThanhTich, item.TenThanhTich);
                }
            }
            return ThanhTichLoai2;
        }
        public (string ID_cauThu, string Ten_Cau_Thu, string HA_Cau_Thu)[] GetCauThuTeam(string id)
        {
            int temp = 0;
            Cauthuteam = new (string ID_cauThu, string Ten_Cau_Thu, string HA_Cau_Thu)[100];
            Cauthus = _context.Cauthu.ToArray();
            foreach(var item in _context.Cauthu)
            {
                if (item.IdDoiBong == id)
                {
                    listCauThu[temp] = item.IdCauThu;
                    temp++;
                }
            }
            temp = 0;
            foreach(var item in Cauthus)
            {
                if (item.IdCauThu == listCauThu[temp])
                {
                    Cauthuteam[temp] = (item.IdCauThu, item.TenCauThu,item.SourceHact);
                    temp++;
                }
            }
            return Cauthuteam;
        }
    }
}
