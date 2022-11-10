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
    public class LoaisanphamsController : Controller
    {
        private readonly Nhom03Context _context;

        public LoaisanphamsController(Nhom03Context context)
        {
            _context = context;
        }

        // GET: Loaisanphams
        public async Task<IActionResult> Index()
        {
              return View(await _context.Loaisanphams.ToListAsync());
        }

        // GET: Loaisanphams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Loaisanphams == null)
            {
                return NotFound();
            }

            var loaisanpham = await _context.Loaisanphams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaisanpham == null)
            {
                return NotFound();
            }

            return View(loaisanpham);
        }

        // GET: Loaisanphams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loaisanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tenloai,Trangthai")] Loaisanpham loaisanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaisanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaisanpham);
        }

        // GET: Loaisanphams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Loaisanphams == null)
            {
                return NotFound();
            }

            var loaisanpham = await _context.Loaisanphams.FindAsync(id);
            if (loaisanpham == null)
            {
                return NotFound();
            }
            return View(loaisanpham);
        }

        // POST: Loaisanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tenloai,Trangthai")] Loaisanpham loaisanpham)
        {
            if (id != loaisanpham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaisanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaisanphamExists(loaisanpham.Id))
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
            return View(loaisanpham);
        }

        // GET: Loaisanphams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Loaisanphams == null)
            {
                return NotFound();
            }

            var loaisanpham = await _context.Loaisanphams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaisanpham == null)
            {
                return NotFound();
            }

            return View(loaisanpham);
        }

        // POST: Loaisanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Loaisanphams == null)
            {
                return Problem("Entity set 'Nhom03Context.Loaisanpham'  is null.");
            }
            var loaisanpham = await _context.Loaisanphams.FindAsync(id);
            if (loaisanpham != null)
            {
                _context.Loaisanphams.Remove(loaisanpham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaisanphamExists(int id)
        {
          return _context.Loaisanphams.Any(e => e.Id == id);
        }
    }
}
