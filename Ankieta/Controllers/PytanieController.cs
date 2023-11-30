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
    public class PytanieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PytanieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pytanies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pytanie.Include(p => p.AnkietaSzkolna);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pytanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pytanie == null)
            {
                return NotFound();
            }

            var pytanie = await _context.Pytanie
                .Include(p => p.AnkietaSzkolna)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pytanie == null)
            {
                return NotFound();
            }

            return View(pytanie);
        }

        // GET: Pytanies/Create
        public IActionResult Create()
        {
            ViewData["AnkietaSzkolnaId"] = new SelectList(_context.AnkietaSzkolna, "Id", "Name");
            return View();
        }

        // POST: Pytanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tresc,TypPytania,AnkietaSzkolnaId")] Pytanie pytanie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pytanie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnkietaSzkolnaId"] = new SelectList(_context.AnkietaSzkolna, "Id", "Name", pytanie.AnkietaSzkolnaId);
            return View(pytanie);
        }

        // GET: Pytanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pytanie == null)
            {
                return NotFound();
            }

            var pytanie = await _context.Pytanie.FindAsync(id);
            if (pytanie == null)
            {
                return NotFound();
            }
            ViewData["AnkietaSzkolnaId"] = new SelectList(_context.AnkietaSzkolna, "Id", "Name", pytanie.AnkietaSzkolnaId);
            return View(pytanie);
        }

        // POST: Pytanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tresc,TypPytania,AnkietaSzkolnaId")] Pytanie pytanie)
        {
            if (id != pytanie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pytanie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PytanieExists(pytanie.Id))
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
            ViewData["AnkietaSzkolnaId"] = new SelectList(_context.AnkietaSzkolna, "Id", "Namevp 889", pytanie.AnkietaSzkolnaId);
            return View(pytanie);
        }

        // GET: Pytanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pytanie == null)
            {
                return NotFound();
            }

            var pytanie = await _context.Pytanie
                .Include(p => p.AnkietaSzkolna)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pytanie == null)
            {
                return NotFound();
            }

            return View(pytanie);
        }

        // POST: Pytanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pytanie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pytanie'  is null.");
            }
            var pytanie = await _context.Pytanie.FindAsync(id);
            if (pytanie != null)
            {
                _context.Pytanie.Remove(pytanie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PytanieExists(int id)
        {
          return (_context.Pytanie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
