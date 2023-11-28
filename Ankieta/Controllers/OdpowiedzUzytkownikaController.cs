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
    public class OdpowiedzUzytkownikaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OdpowiedzUzytkownikaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OdpowiedzUzytkownika
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OdpowiedzUzytkownika.Include(o => o.Odpowiedz).Include(o => o.Uzytkownik);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OdpowiedzUzytkownika/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OdpowiedzUzytkownika == null)
            {
                return NotFound();
            }

            var odpowiedzUzytkownika = await _context.OdpowiedzUzytkownika
                .Include(o => o.Odpowiedz)
                .Include(o => o.Uzytkownik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odpowiedzUzytkownika == null)
            {
                return NotFound();
            }

            return View(odpowiedzUzytkownika);
        }

        // GET: OdpowiedzUzytkownika/Create
        public IActionResult Create()
        {
            ViewData["OdpowiedzId"] = new SelectList(_context.Odpowiedz, "Id", "Tresc");
            ViewData["UzytkownikId"] = new SelectList(_context.Set<Uzytkownik>(), "Id", "Name");
            return View();
        }

        // POST: OdpowiedzUzytkownika/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tresc,UzytkownikId,OdpowiedzId")] OdpowiedzUzytkownika odpowiedzUzytkownika)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odpowiedzUzytkownika);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OdpowiedzId"] = new SelectList(_context.Odpowiedz, "Id", "Id", odpowiedzUzytkownika.OdpowiedzId);
            ViewData["UzytkownikId"] = new SelectList(_context.Set<Uzytkownik>(), "Id", "Id", odpowiedzUzytkownika.UzytkownikId);
            return View(odpowiedzUzytkownika);
        }

        // GET: OdpowiedzUzytkownika/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OdpowiedzUzytkownika == null)
            {
                return NotFound();
            }

            var odpowiedzUzytkownika = await _context.OdpowiedzUzytkownika.FindAsync(id);
            if (odpowiedzUzytkownika == null)
            {
                return NotFound();
            }
            ViewData["OdpowiedzId"] = new SelectList(_context.Odpowiedz, "Id", "Tresc", odpowiedzUzytkownika.OdpowiedzId);
            ViewData["UzytkownikId"] = new SelectList(_context.Set<Uzytkownik>(), "Id", "Name", odpowiedzUzytkownika.UzytkownikId);
            return View(odpowiedzUzytkownika);
        }

        // POST: OdpowiedzUzytkownika/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tresc,UzytkownikId,OdpowiedzId")] OdpowiedzUzytkownika odpowiedzUzytkownika)
        {
            if (id != odpowiedzUzytkownika.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odpowiedzUzytkownika);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdpowiedzUzytkownikaExists(odpowiedzUzytkownika.Id))
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
            ViewData["OdpowiedzId"] = new SelectList(_context.Odpowiedz, "Id", "Tresc", odpowiedzUzytkownika.OdpowiedzId);
            ViewData["UzytkownikId"] = new SelectList(_context.Set<Uzytkownik>(), "Id", "Name", odpowiedzUzytkownika.UzytkownikId);
            return View(odpowiedzUzytkownika);
        }

        // GET: OdpowiedzUzytkownika/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OdpowiedzUzytkownika == null)
            {
                return NotFound();
            }

            var odpowiedzUzytkownika = await _context.OdpowiedzUzytkownika
                .Include(o => o.Odpowiedz)
                .Include(o => o.Uzytkownik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odpowiedzUzytkownika == null)
            {
                return NotFound();
            }

            return View(odpowiedzUzytkownika);
        }

        // POST: OdpowiedzUzytkownika/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OdpowiedzUzytkownika == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OdpowiedzUzytkownika'  is null.");
            }
            var odpowiedzUzytkownika = await _context.OdpowiedzUzytkownika.FindAsync(id);
            if (odpowiedzUzytkownika != null)
            {
                _context.OdpowiedzUzytkownika.Remove(odpowiedzUzytkownika);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdpowiedzUzytkownikaExists(int id)
        {
          return (_context.OdpowiedzUzytkownika?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
