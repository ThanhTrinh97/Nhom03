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
    public class ChitiethoadonsController : Controller
    {
        private readonly Nhom03Context _context;

        public ChitiethoadonsController(Nhom03Context context)
        {
            _context = context;
        }

        // GET: Chitiethoadons
        public async Task<IActionResult> Index()
        {
            var nhom03Context = _context.Chitiethoadons.Include(c => c.Hoadon).Include(c => c.Sanpham);
            return View(await nhom03Context.ToListAsync());
        }

        // GET: Chitiethoadons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Chitiethoadons == null)
            {
                return NotFound();
            }

            var chitiethoadon = await _context.Chitiethoadons
                .Include(c => c.Hoadon)
                .Include(c => c.Sanpham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chitiethoadon == null)
            {
                return NotFound();
            }

            return View(chitiethoadon);
        }

        // GET: Chitiethoadons/Create
        public IActionResult Create()
        {
            ViewData["HoadonId"] = new SelectList(_context.Hoadons, "Id", "Id");
            ViewData["SanphamId"] = new SelectList(_context.Sanphams, "Id", "Id");
            return View();
        }

        // POST: Chitiethoadons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HoadonId,SanphamId,Soluong,Dongia")] Chitiethoadon chitiethoadon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chitiethoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoadonId"] = new SelectList(_context.Hoadons, "Id", "Id", chitiethoadon.HoadonId);
            ViewData["SanphamId"] = new SelectList(_context.Sanphams, "Id", "Id", chitiethoadon.SanphamId);
            return View(chitiethoadon);
        }

        // GET: Chitiethoadons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Chitiethoadons == null)
            {
                return NotFound();
            }

            var chitiethoadon = await _context.Chitiethoadons.FindAsync(id);
            if (chitiethoadon == null)
            {
                return NotFound();
            }
            ViewData["HoadonId"] = new SelectList(_context.Hoadons, "Id", "Id", chitiethoadon.HoadonId);
            ViewData["SanphamId"] = new SelectList(_context.Sanphams, "Id", "Id", chitiethoadon.SanphamId);
            return View(chitiethoadon);
        }

        // POST: Chitiethoadons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HoadonId,SanphamId,Soluong,Dongia")] Chitiethoadon chitiethoadon)
        {
            if (id != chitiethoadon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chitiethoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitiethoadonExists(chitiethoadon.Id))
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
            ViewData["HoadonId"] = new SelectList(_context.Hoadons, "Id", "Id", chitiethoadon.HoadonId);
            ViewData["SanphamId"] = new SelectList(_context.Sanphams, "Id", "Id", chitiethoadon.SanphamId);
            return View(chitiethoadon);
        }

        // GET: Chitiethoadons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Chitiethoadons == null)
            {
                return NotFound();
            }

            var chitiethoadon = await _context.Chitiethoadons
                .Include(c => c.Hoadon)
                .Include(c => c.Sanpham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chitiethoadon == null)
            {
                return NotFound();
            }

            return View(chitiethoadon);
        }

        // POST: Chitiethoadons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Chitiethoadons == null)
            {
                return Problem("Entity set 'Nhom03Context.Chitiethoadon'  is null.");
            }
            var chitiethoadon = await _context.Chitiethoadons.FindAsync(id);
            if (chitiethoadon != null)
            {
                _context.Chitiethoadons.Remove(chitiethoadon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChitiethoadonExists(int id)
        {
          return _context.Chitiethoadons.Any(e => e.Id == id);
        }
    }
}
