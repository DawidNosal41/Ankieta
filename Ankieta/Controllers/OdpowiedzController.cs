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
    public class OdpowiedzController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OdpowiedzController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Odpowiedz
        public async Task<IActionResult> Index()
        {
              return _context.Odpowiedz != null ? 
                          View(await _context.Odpowiedz.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Odpowiedz'  is null.");
        }

        // GET: Odpowiedz/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Odpowiedz == null)
            {
                return NotFound();
            }

            var odpowiedz = await _context.Odpowiedz
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odpowiedz == null)
            {
                return NotFound();
            }

            return View(odpowiedz);
        }

        // GET: Odpowiedz/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Odpowiedz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tresc")] Odpowiedz odpowiedz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odpowiedz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(odpowiedz);
        }

        // GET: Odpowiedz/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Odpowiedz == null)
            {
                return NotFound();
            }

            var odpowiedz = await _context.Odpowiedz.FindAsync(id);
            if (odpowiedz == null)
            {
                return NotFound();
            }
            return View(odpowiedz);
        }

        // POST: Odpowiedz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tresc")] Odpowiedz odpowiedz)
        {
            if (id != odpowiedz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odpowiedz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdpowiedzExists(odpowiedz.Id))
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
            return View(odpowiedz);
        }

        // GET: Odpowiedz/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Odpowiedz == null)
            {
                return NotFound();
            }

            var odpowiedz = await _context.Odpowiedz
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odpowiedz == null)
            {
                return NotFound();
            }

            return View(odpowiedz);
        }

        // POST: Odpowiedz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Odpowiedz == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Odpowiedz'  is null.");
            }
            var odpowiedz = await _context.Odpowiedz.FindAsync(id);
            if (odpowiedz != null)
            {
                _context.Odpowiedz.Remove(odpowiedz);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdpowiedzExists(int id)
        {
          return (_context.Odpowiedz?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
