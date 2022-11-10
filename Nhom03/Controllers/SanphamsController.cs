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
    public class SanphamsController : Controller
    {
        private readonly Nhom03Context _context;

        public SanphamsController(Nhom03Context context)
        {
            _context = context;
        }

        // GET: Sanphams
        public async Task<IActionResult> Index()
        {
              return View(await _context.Sanphams.ToListAsync());
        }

        // GET: Sanphams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sanphams == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: Sanphams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SKU,Tensanpham,Mota,Dongia,Tonkho,LoaisanphamId,Hinhanh,Trangthai")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanpham);
        }

        // GET: Sanphams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sanphams == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            return View(sanpham);
        }

        // POST: Sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SKU,Tensanpham,Mota,Dongia,Tonkho,LoaisanphamId,Hinhanh,Trangthai")] Sanpham sanpham)
        {
            if (id != sanpham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanphamExists(sanpham.Id))
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
            return View(sanpham);
        }

        // GET: Sanphams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sanphams == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sanphams == null)
            {
                return Problem("Entity set 'Nhom03Context.Sanpham'  is null.");
            }
            var sanpham = await _context.Sanphams.FindAsync(id);
            if (sanpham != null)
            {
                _context.Sanphams.Remove(sanpham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(int id)
        {
          return _context.Sanphams.Any(e => e.Id == id);
        }
    }
}
