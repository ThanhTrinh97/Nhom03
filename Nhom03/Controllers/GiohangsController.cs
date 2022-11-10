using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom03.Data;
using Nhom03.Models;

namespace Nhom03.Controllers
{
    public class GiohangsController : Controller
    {
        private readonly Nhom03Context _context;

        public GiohangsController(Nhom03Context context)
        {
            _context = context;
        }

        // GET: Giohangs
        public async Task<IActionResult> Index()
        {
            var nhom03Context = _context.Giohangs.Include(g => g.Sanpham).Include(g => g.Taikhoan);
            return View(await nhom03Context.ToListAsync());
        }

        // GET: Giohangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Giohangs == null)
            {
                return NotFound();
            }

            var giohang = await _context.Giohangs
                .Include(g => g.Sanpham)
                .Include(g => g.Taikhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giohang == null)
            {
                return NotFound();
            }

            return View(giohang);
        }

        // GET: Giohangs/Create
        public IActionResult Create()
        {
            ViewData["SanphamId"] = new SelectList(_context.Set<Sanpham>(), "Id", "Id");
            ViewData["TaikhoanId"] = new SelectList(_context.Taikhoans, "Id", "Id");
            return View();
        }

        // POST: Giohangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaikhoanId,SanphamId,Soluong")] Giohang giohang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giohang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SanphamId"] = new SelectList(_context.Set<Sanpham>(), "Id", "Id", giohang.SanphamId);
            ViewData["TaikhoanId"] = new SelectList(_context.Taikhoans, "Id", "Id", giohang.TaikhoanId);
            return View(giohang);
        }

        // GET: Giohangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Giohangs == null)
            {
                return NotFound();
            }

            var giohang = await _context.Giohangs.FindAsync(id);
            if (giohang == null)
            {
                return NotFound();
            }
            ViewData["SanphamId"] = new SelectList(_context.Set<Sanpham>(), "Id", "Id", giohang.SanphamId);
            ViewData["TaikhoanId"] = new SelectList(_context.Taikhoans, "Id", "Id", giohang.TaikhoanId);
            return View(giohang);
        }

        // POST: Giohangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaikhoanId,SanphamId,Soluong")] Giohang giohang)
        {
            if (id != giohang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giohang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiohangExists(giohang.Id))
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
            ViewData["SanphamId"] = new SelectList(_context.Set<Sanpham>(), "Id", "Id", giohang.SanphamId);
            ViewData["TaikhoanId"] = new SelectList(_context.Taikhoans, "Id", "Id", giohang.TaikhoanId);
            return View(giohang);
        }

        // GET: Giohangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Giohangs == null)
            {
                return NotFound();
            }

            var giohang = await _context.Giohangs
                .Include(g => g.Sanpham)
                .Include(g => g.Taikhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giohang == null)
            {
                return NotFound();
            }

            return View(giohang);
        }

        // POST: Giohangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Giohangs == null)
            {
                return Problem("Entity set 'Nhom03Context.Giohang'  is null.");
            }
            var giohang = await _context.Giohangs.FindAsync(id);
            if (giohang != null)
            {
                _context.Giohangs.Remove(giohang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiohangExists(int id)
        {
          return _context.Giohangs.Any(e => e.Id == id);
        }
    }
}
