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
    public class TicketsController : Controller
    {
        public List<Doibong> doibongs { get; set; }
        public (string IDve, string srcLogoDoiNha, string srcLogoDoiKhach, DateTime? Thoigian)[] ListVeVsLogo { get; set; }
        public (string IDve, string srcLogoDoiNha, string srcLogoDoiKhach, DateTime? Thoigian) VeDuocChon { get; set; }
        private readonly FootballNewsContext _context;

        public TicketsController(FootballNewsContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public IActionResult Index()
        {
            TicketsViewsModel ticketsViewsModel = new TicketsViewsModel();
            ticketsViewsModel.hinhanhQcs = _context.HinhanhQc.ToList();
            ticketsViewsModel.tickets = _context.Ticket.ToList();
            ticketsViewsModel.trandaus = _context.Trandau.ToList();
            ticketsViewsModel.doibongs = _context.Doibong.ToList();
            ticketsViewsModel.ListVeVsLogo = GetListVe();
            return View(ticketsViewsModel);
        }
        // GET: Tickets/Details/5
        public (string IDve, string srcLogoDoiNha, string srcLogoDoiKhach, DateTime? Thoigian)[] GetListVe()
        {
            List<Ticket> tempTicket = _context.Ticket.ToList();
            int temp = 0;
            ListVeVsLogo = new (string IDve, string srcLogoDoiNha, string srcLogoDoiKhach, DateTime? Thoigian)[100];
            foreach (var item in tempTicket)
            {
                ListVeVsLogo[temp] = (item.IdVe, GetLogoSrc(item.DoiNha), GetLogoSrc(item.DoiKhach), item.ThoiGianBatDau);
                temp++;
            }
            return ListVeVsLogo;
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
        public (string IDve, string srcLogoDoiNha, string srcLogoDoiKhach, DateTime? Thoigian) GetTicket(string id, (string IDve, string srcLogoDoiNha, string srcLogoDoiKhach, DateTime? Thoigian)[] listve)
        {
            foreach (var item in listve)
            {
                if (item.IDve==id)
                {
                     return item;
                }
            }
            return ("", "", "", null);
        }
       
            public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TicketsViewsModel ticketsViewsModel = new TicketsViewsModel();
            ticketsViewsModel.tickets = _context.Ticket.ToList();
            ticketsViewsModel.trandaus = _context.Trandau.ToList();
            ticketsViewsModel.doibongs = _context.Doibong.ToList();
            ticketsViewsModel.ListVeVsLogo = GetListVe();
            ticketsViewsModel.VeDuocChon = GetTicket(id,ListVeVsLogo);

            return View(ticketsViewsModel);
        }

    }
}
