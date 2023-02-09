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
    public class EtiquettesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtiquettesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Etiquettes
        public async Task<IActionResult> Index()
        {
              return _context.Etiquettes != null ? 
                          View(await _context.Etiquettes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Etiquettes'  is null.");
        }

        // GET: Etiquettes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Etiquettes == null)
            {
                return NotFound();
            }

            var etiquette = await _context.Etiquettes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etiquette == null)
            {
                return NotFound();
            }

            return View(etiquette);
        }

        // GET: Etiquettes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etiquettes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Couleur,IdCarte")] Etiquette etiquette)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etiquette);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etiquette);
        }

        // GET: Etiquettes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Etiquettes == null)
            {
                return NotFound();
            }

            var etiquette = await _context.Etiquettes.FindAsync(id);
            if (etiquette == null)
            {
                return NotFound();
            }
            return View(etiquette);
        }

        // POST: Etiquettes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Couleur,IdCarte")] Etiquette etiquette)
        {
            if (id != etiquette.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etiquette);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtiquetteExists(etiquette.Id))
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
            return View(etiquette);
        }

        // GET: Etiquettes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Etiquettes == null)
            {
                return NotFound();
            }

            var etiquette = await _context.Etiquettes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etiquette == null)
            {
                return NotFound();
            }

            return View(etiquette);
        }

        // POST: Etiquettes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Etiquettes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Etiquettes'  is null.");
            }
            var etiquette = await _context.Etiquettes.FindAsync(id);
            if (etiquette != null)
            {
                _context.Etiquettes.Remove(etiquette);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtiquetteExists(int id)
        {
          return (_context.Etiquettes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
