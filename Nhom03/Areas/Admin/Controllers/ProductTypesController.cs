﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom03.Data;
using Nhom03.Models;

namespace Nhom03.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private readonly Nhom03Context _context;

        public ProductTypesController(Nhom03Context context)
        {
            _context = context;
        }

        // GET: Admin/ProductTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.ProductTypes.ToListAsync());
        }

        // GET: Admin/ProductTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductTypes == null)
            {
                return NotFound();
            }

            var productTypes = await _context.ProductTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productTypes == null)
            {
                return NotFound();
            }

            return View(productTypes);
        }

        // GET: Admin/ProductTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status")] ProductType productTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }

        // GET: Admin/ProductTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductTypes == null)
            {
                return NotFound();
            }

            var productTypes = await _context.ProductTypes.FindAsync(id);
            if (productTypes == null)
            {
                return NotFound();
            }
            return View(productTypes);
        }

        // POST: Admin/ProductTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status")] ProductType productTypes)
        {
            if (id != productTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTypesExists(productTypes.Id))
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
            return View(productTypes);
        }

        // GET: Admin/ProductTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductTypes == null)
            {
                return NotFound();
            }

            var productTypes = await _context.ProductTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productTypes == null)
            {
                return NotFound();
            }

            return View(productTypes);
        }

        // POST: Admin/ProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductTypes == null)
            {
                return Problem("Entity set 'Trang_AdminContext.ProductTypes'  is null.");
            }
            var productTypes = await _context.ProductTypes.FindAsync(id);
            if (productTypes != null)
            {
                _context.ProductTypes.Remove(productTypes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTypesExists(int id)
        {
          return _context.ProductTypes.Any(e => e.Id == id);

        }
    }
}
