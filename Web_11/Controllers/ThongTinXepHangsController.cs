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
    public class ThongTinXepHangsController : Controller
    {
        public (string IDDoiBong, int? SoTran, int? Thang, int? Hoa, int? Thua, string HieuSo, int? Diem)[] listbangxephang { get; set; }
        int?[] listDiem = new int?[100];
        public (string DoiBong, int? Diem)[] DiemXepHang { get; set; }
        public IList<ThongTinXepHang> thongTinXepHangs { get; set; }
        private readonly FootballNewsContext _context;

        public ThongTinXepHangsController(FootballNewsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            BangXepHangViewModel bangXepHangViewModel = new BangXepHangViewModel();
            bangXepHangViewModel.listbangxephang = GetBangXepHang();
            bangXepHangViewModel.DiemXepHang = GetDiem();
            return View(bangXepHangViewModel);
        }

        public (string IDDoiBong, int? SoTran, int? Thang, int? Hoa, int? Thua, string HieuSo, int? Diem)[] GetBangXepHang()
        {
            List<ThongTinXepHang> tempBXH = _context.ThongTinXepHang.ToList();
            int temp = 0;
            listbangxephang = new (string IDDoiBong, int? SoTran, int? Thang, int? Hoa, int? Thua, string HieuSo, int? Diem)[100];
            foreach (var item in tempBXH)
            {
                listbangxephang[temp] = (GetTenDoiBong(item.IdDoiBong), item.SoTran, item.Thang, item.Hoa, item.Thua, item.HieuSo, item.Diem);
                temp++;
            }
            return listbangxephang;
        }
        public string GetTenDoiBong(string id)
        {
            string temp = "";
            foreach (var item in _context.Doibong)
            {
                if (item.IdDoiBong == id)
                {
                    temp = item.TenDoi;
                }

            }
            return temp;
        }

        public (string DoiBong, int? Diem)[] GetDiem()
        {
            int temp = 0;
            DiemXepHang = new (string DoiBong, int? Diem)[100];
            thongTinXepHangs = _context.ThongTinXepHang.ToArray();
            foreach (var item in _context.ThongTinXepHang)
            {
                listDiem[temp] = item.Diem;
                temp++;
            }
            temp = 0;
            foreach (var item in thongTinXepHangs)
            {
                if (item.Diem == listDiem[temp])
                {
                    DiemXepHang[temp] = (item.IdDoiBong, item.Diem = (item.Thang * 3) + item.Hoa);
                    temp++;
                }
            }
            return DiemXepHang;
        }

    }
}
