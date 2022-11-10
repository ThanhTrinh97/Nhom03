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
    public class TaikhoansController : Controller
    {
        private readonly Nhom03Context _context;

        public TaikhoansController(Nhom03Context context)
        {
            _context = context;
        }

        // GET: Taikhoans
        public async Task<IActionResult> Index()
        {
              return View(await _context.Taikhoans.ToListAsync());
        }

        // GET: Taikhoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Taikhoans == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.Taikhoans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            return View(taikhoan);
        }

        // GET: Taikhoans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Taikhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dangnhap,Matkhau,Email,Sdt,Diachi,Hoten,Quanly,Hinhanh,Trangthai")] Taikhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taikhoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taikhoan);
        }

        // GET: Taikhoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Taikhoans == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.Taikhoans.FindAsync(id);
            if (taikhoan == null)
            {
                return NotFound();
            }
            return View(taikhoan);
        }

        // POST: Taikhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dangnhap,Matkhau,Email,Sdt,Diachi,Hoten,Quanly,Hinhanh,Trangthai")] Taikhoan taikhoan)
        {
            if (id != taikhoan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taikhoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaikhoanExists(taikhoan.Id))
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
            return View(taikhoan);
        }

        // GET: Taikhoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Taikhoans == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.Taikhoans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            return View(taikhoan);
        }

        // POST: Taikhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Taikhoans == null)
            {
                return Problem("Entity set 'Nhom03Context.Taikhoan'  is null.");
            }
            var taikhoan = await _context.Taikhoans.FindAsync(id);
            if (taikhoan != null)
            {
                _context.Taikhoans.Remove(taikhoan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaikhoanExists(int id)
        {
          return _context.Taikhoans.Any(e => e.Id == id);
        }
    }
}
