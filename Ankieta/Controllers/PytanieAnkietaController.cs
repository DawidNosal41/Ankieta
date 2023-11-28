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
    public class PytanieAnkietaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PytanieAnkietaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PytanieAnkieta
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PytanieAnkieta.Include(p => p.Ankieta).Include(p => p.Pytanie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PytanieAnkieta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PytanieAnkieta == null)
            {
                return NotFound();
            }

            var pytanieAnkieta = await _context.PytanieAnkieta
                .Include(p => p.Ankieta)
                .Include(p => p.Pytanie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pytanieAnkieta == null)
            {
                return NotFound();
            }

            return View(pytanieAnkieta);
        }

        // GET: PytanieAnkieta/Create
        public IActionResult Create()
        {
            ViewData["AnkietaId"] = new SelectList(_context.Ankieta, "Id", "Id");
            ViewData["PytanieId"] = new SelectList(_context.Pytanie, "Id", "Id");
            return View();
        }

        // POST: PytanieAnkieta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PytanieId,AnkietaId")] PytanieAnkieta pytanieAnkieta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pytanieAnkieta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnkietaId"] = new SelectList(_context.Ankieta, "Id", "Id", pytanieAnkieta.AnkietaId);
            ViewData["PytanieId"] = new SelectList(_context.Pytanie, "Id", "Id", pytanieAnkieta.PytanieId);
            return View(pytanieAnkieta);
        }

        // GET: PytanieAnkieta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PytanieAnkieta == null)
            {
                return NotFound();
            }

            var pytanieAnkieta = await _context.PytanieAnkieta.FindAsync(id);
            if (pytanieAnkieta == null)
            {
                return NotFound();
            }
            ViewData["AnkietaId"] = new SelectList(_context.Ankieta, "Id", "Id", pytanieAnkieta.AnkietaId);
            ViewData["PytanieId"] = new SelectList(_context.Pytanie, "Id", "Id", pytanieAnkieta.PytanieId);
            return View(pytanieAnkieta);
        }

        // POST: PytanieAnkieta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PytanieId,AnkietaId")] PytanieAnkieta pytanieAnkieta)
        {
            if (id != pytanieAnkieta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pytanieAnkieta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PytanieAnkietaExists(pytanieAnkieta.Id))
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
            ViewData["AnkietaId"] = new SelectList(_context.Ankieta, "Id", "Id", pytanieAnkieta.AnkietaId);
            ViewData["PytanieId"] = new SelectList(_context.Pytanie, "Id", "Id", pytanieAnkieta.PytanieId);
            return View(pytanieAnkieta);
        }

        // GET: PytanieAnkieta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PytanieAnkieta == null)
            {
                return NotFound();
            }

            var pytanieAnkieta = await _context.PytanieAnkieta
                .Include(p => p.Ankieta)
                .Include(p => p.Pytanie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pytanieAnkieta == null)
            {
                return NotFound();
            }

            return View(pytanieAnkieta);
        }

        // POST: PytanieAnkieta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PytanieAnkieta == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PytanieAnkieta'  is null.");
            }
            var pytanieAnkieta = await _context.PytanieAnkieta.FindAsync(id);
            if (pytanieAnkieta != null)
            {
                _context.PytanieAnkieta.Remove(pytanieAnkieta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PytanieAnkietaExists(int id)
        {
          return (_context.PytanieAnkieta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
