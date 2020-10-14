using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_11.Models;
using Web_11.Models.data;

namespace Web_11.Controllers
{
    public class AdminController : Controller
    {
        private readonly FootballNewsContext _context;

        public AdminController(FootballNewsContext context)
        {
            _context = context;
        }
        public IActionResult TinTuc()
        {
            TinTucModel tinTuc = new TinTucModel
            {
                Tintucs = _context.Tintuc.ToArray()
            };
            return View(tinTuc);
        }
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintuc
                .FirstOrDefaultAsync(m => m.IdTinTuc == id);
            if (tintuc == null)
            {
                return NotFound();
            }

            return View(tintuc);
        }

        // GET: Tintucs/Create
        public IActionResult CreateTinTuc()
        {
            return View();
        }
        public IActionResult CreateNoiDung()
        {
            return View();
        }
        public IActionResult CreateHinhAnh()
        {
            return View();
        }
        public IActionResult CreateSubTinTuc()
        {
            return View();
        }
        public IActionResult CreateHashTag()
        {
            return View();
        }

        // POST: Tintucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTinTuc([Bind("IdTinTuc,TieuDe,Avatar,TomTat,LuotTuongTac,LuotXem,TrangThaiHienThi,")] Tintuc  tintuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tintuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tintuc);
        }
        public IActionResult CreateTinTucTemp([Bind("IdTinTuc,TieuDe,Avatar,TomTat,LuotTuongTac,LuotXem,TrangThaiHienThi")] TinTucTemp tintuc)
        {
            
            return View(tintuc);
        }
       
        // GET: Tintucs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintuc.FindAsync(id);
            if (tintuc == null)
            {
                return NotFound();
            }
            return View(tintuc);
        }

        // POST: Tintucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdTinTuc,TieuDe,Avatar,TomTat,LuotTuongTac,LuotXem,TrangThaiHienThi")] Tintuc tintuc)
        {
            if (id != tintuc.IdTinTuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tintuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TintucExists(tintuc.IdTinTuc))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tintuc);
        }

        // GET: Tintucs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintuc
                .FirstOrDefaultAsync(m => m.IdTinTuc == id);
            if (tintuc == null)
            {
                return NotFound();
            }

            return View(tintuc);
        }

        // POST: Tintucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tintuc = await _context.Tintuc.FindAsync(id);
            _context.Tintuc.Remove(tintuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TintucExists(string id)
        {
            return _context.Tintuc.Any(e => e.IdTinTuc == id);
        }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}