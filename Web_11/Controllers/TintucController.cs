using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_11.Models;
using Web_11.Models.data;

namespace Web_11.Controllers
{
    public class TintucController : Controller
    {
        private readonly FootballNewsContext _context;
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
        public (string value, string display)[] VideoTinVideo { get; set; }
        public (string value, string display)[] NoiDungTin { get; set; }
        public (string value, string display)[] HashtagTin { get; set; }
        public (string value, string display)[] HinhAnhTin { get; set; }

        public TintucController(FootballNewsContext context)
        {
            _context = context;
        }

        // GET: Tintuc
        public async Task<IActionResult> Index()
        {
            TinTucViewsModel tinTucViewsModel = new TinTucViewsModel();
            tinTucViewsModel.subTinVideos = _context.SubTinVideo.ToArray();
            tinTucViewsModel.tinVideos = _context.TinVideo.ToArray();
            tinTucViewsModel.subTintucs = _context.SubTintuc.ToArray();
            tinTucViewsModel.Tintucs = _context.Tintuc.ToArray();
            tinTucViewsModel.Hashtags = _context.Hashtag.ToArray();
            tinTucViewsModel.TintucHots = (from s in _context.Tintuc orderby s.LuotXem select s).Take(5).ToArray();
            tinTucViewsModel.TintucTrongTuans = _context.Tintuc.ToArray();
            tinTucViewsModel.TintucChuyenNhuongs = GetTinChuyenNhuong();            
            return View(tinTucViewsModel);
        }
        public List<Tintuc> GetTinChuyenNhuong() 
        {
            List<string> ListIdChuyenNhuong = new List<string>();
            List<Tintuc> ListTin = new List<Tintuc>();
            int temp = 0;
            foreach (var item in _context.SubTintuc)
            {
                if (item.IdHashtag == 1)
                {
                    ListIdChuyenNhuong.Add(item.IdTintuc);
                }
            }
            ListIdChuyenNhuong.Add("");
            foreach (var item in _context.Tintuc)
            {
                if (item.IdTinTuc == ListIdChuyenNhuong[temp])
                { 
                    ListTin.Add(item);
                    temp++;
                }
            }
            return ListTin;
        }
        public async Task<IActionResult> DetailsVideo(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TinTucChiTietModel tinTucChiTietModel = new TinTucChiTietModel();
            tinTucChiTietModel.TinVideo = GetTinVideo(id);
            tinTucChiTietModel.VideoTinVideo = GetVideo(id);
            return View(tinTucChiTietModel);
        }

        // GET: Tintuc/Details/5
        public async Task<IActionResult> Details(string id)
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
        public (string value, string display)[] GetVideo(string id)
        {
            int temp = 0;
            VideoTinVideo = new (string value, string display)[100];
            subTinVideos = _context.SubTinVideo.ToArray();
            Videos = _context.Video.ToArray();
            foreach (var item in _context.SubTinVideo)
            {
                if (item.IdTinVideo == id )
                {
                    listIDVideo[temp] = item.IdVideo;
                    temp++;
                }
            }

            temp = 0;
            foreach (var item in Videos)
            {
                if (item.IdVideo == listIDVideo[temp])
                {
                    
                    VideoTinVideo[temp] = (item.IdVideo.ToString(), item.SourceVideo);
                    temp++;
                }
            }
            return VideoTinVideo;
        }


    }

}
