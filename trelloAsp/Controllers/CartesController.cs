using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trelloAsp.Data;
using trelloAsp.Models;

namespace trelloAsp.Controllers
{
    public class CartesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cartes
        public async Task<IActionResult> Index()
        {
              return _context.Cartes != null ? 
                          View(await _context.Cartes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Cartes'  is null.");
        }

        // GET: Cartes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cartes == null)
            {
                return NotFound();
            }

            var carte = await _context.Cartes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carte == null)
            {
                return NotFound();
            }

            return View(carte);
        }

        // GET: Cartes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cartes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titre,Description,DateCreation,IdListe")] Carte carte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carte);
        }

        // GET: Cartes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cartes == null)
            {
                return NotFound();
            }

            var carte = await _context.Cartes.FindAsync(id);
            if (carte == null)
            {
                return NotFound();
            }
            return View(carte);
        }

        // POST: Cartes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titre,Description,DateCreation,IdListe")] Carte carte)
        {
            if (id != carte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarteExists(carte.Id))
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
            return View(carte);
        }

        // GET: Cartes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cartes == null)
            {
                return NotFound();
            }

            var carte = await _context.Cartes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carte == null)
            {
                return NotFound();
            }

            return View(carte);
        }

        // POST: Cartes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cartes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cartes'  is null.");
            }
            var carte = await _context.Cartes.FindAsync(id);
            if (carte != null)
            {
                _context.Cartes.Remove(carte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarteExists(int id)
        {
          return (_context.Cartes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
