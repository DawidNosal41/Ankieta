using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ankieta.Data;
using Ankieta.Models;

namespace Ankieta.Controllers
{
    public class AnkietaSzkolnaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnkietaSzkolnaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnkietaSzkolna
        public async Task<IActionResult> Index()
        {
              return _context.AnkietaSzkolna != null ? 
                          View(await _context.AnkietaSzkolna.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AnkietaSzkolna'  is null.");
        }

        // GET: AnkietaSzkolna/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AnkietaSzkolna == null)
            {
                return NotFound();
            }

            var ankietaSzkolna = await _context.AnkietaSzkolna
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ankietaSzkolna == null)
            {
                return NotFound();
            }

            return View(ankietaSzkolna);
        }

        // GET: AnkietaSzkolna/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnkietaSzkolna/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,StartData,EndData")] AnkietaSzkolna ankietaSzkolna)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ankietaSzkolna);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ankietaSzkolna);
        }

        // GET: AnkietaSzkolna/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AnkietaSzkolna == null)
            {
                return NotFound();
            }

            var ankietaSzkolna = await _context.AnkietaSzkolna.FindAsync(id);
            if (ankietaSzkolna == null)
            {
                return NotFound();
            }
            return View(ankietaSzkolna);
        }

        // POST: AnkietaSzkolna/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,StartData,EndData")] AnkietaSzkolna ankietaSzkolna)
        {
            if (id != ankietaSzkolna.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ankietaSzkolna);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnkietaSzkolnaExists(ankietaSzkolna.Id))
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
            return View(ankietaSzkolna);
        }

        // GET: AnkietaSzkolna/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AnkietaSzkolna == null)
            {
                return NotFound();
            }

            var ankietaSzkolna = await _context.AnkietaSzkolna
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ankietaSzkolna == null)
            {
                return NotFound();
            }

            return View(ankietaSzkolna);
        }

        // POST: AnkietaSzkolna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AnkietaSzkolna == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AnkietaSzkolna'  is null.");
            }
            var ankietaSzkolna = await _context.AnkietaSzkolna.FindAsync(id);
            if (ankietaSzkolna != null)
            {
                _context.AnkietaSzkolna.Remove(ankietaSzkolna);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnkietaSzkolnaExists(int id)
        {
          return (_context.AnkietaSzkolna?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
