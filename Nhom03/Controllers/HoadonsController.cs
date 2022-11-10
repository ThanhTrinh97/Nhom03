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
    public class HoadonsController : Controller
    {
        private readonly Nhom03Context _context;

        public HoadonsController(Nhom03Context context)
        {
            _context = context;
        }

        // GET: Hoadons
        public async Task<IActionResult> Index()
        {
            var nhom03Context = _context.Hoadons.Include(h => h.Taikhoan);
            return View(await nhom03Context.ToListAsync());
        }

        // GET: Hoadons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hoadons == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadons
                .Include(h => h.Taikhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hoadon == null)
            {
                return NotFound();
            }

            return View(hoadon);
        }

        // GET: Hoadons/Create
        public IActionResult Create()
        {
            ViewData["TaikhoanId"] = new SelectList(_context.Taikhoans, "Id", "Id");
            return View();
        }

        // POST: Hoadons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mahoadon,TaikhoanId,Ngaylap,Diachinhan,Sdtnhan,Tongcong,Trangthai")] Hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaikhoanId"] = new SelectList(_context.Taikhoans, "Id", "Id", hoadon.TaikhoanId);
            return View(hoadon);
        }

        // GET: Hoadons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hoadons == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadons.FindAsync(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            ViewData["TaikhoanId"] = new SelectList(_context.Taikhoans, "Id", "Id", hoadon.TaikhoanId);
            return View(hoadon);
        }

        // POST: Hoadons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mahoadon,TaikhoanId,Ngaylap,Diachinhan,Sdtnhan,Tongcong,Trangthai")] Hoadon hoadon)
        {
            if (id != hoadon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoadonExists(hoadon.Id))
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
            ViewData["TaikhoanId"] = new SelectList(_context.Taikhoans, "Id", "Id", hoadon.TaikhoanId);
            return View(hoadon);
        }

        // GET: Hoadons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hoadons == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadons
                .Include(h => h.Taikhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hoadon == null)
            {
                return NotFound();
            }

            return View(hoadon);
        }

        // POST: Hoadons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hoadons == null)
            {
                return Problem("Entity set 'Nhom03Context.Hoadon'  is null.");
            }
            var hoadon = await _context.Hoadons.FindAsync(id);
            if (hoadon != null)
            {
                _context.Hoadons.Remove(hoadon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoadonExists(int id)
        {
          return _context.Hoadons.Any(e => e.Id == id);
        }
    }
}
