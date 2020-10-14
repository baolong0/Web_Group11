using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_11.Models.data;

namespace Web_11.Controllers
{
    public class TrandausController : Controller
    {
        private readonly FootballNewsContext _context;

        public TrandausController(FootballNewsContext context)
        {
            _context = context;
        }
       
    }
}
