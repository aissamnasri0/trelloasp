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
    public class UtilisateurProjetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UtilisateurProjetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UtilisateurProjets
        public async Task<IActionResult> Index()
        {
              return _context.UtilisateurProjets != null ? 
                          View(await _context.UtilisateurProjets.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UtilisateurProjets'  is null.");
        }

        // GET: UtilisateurProjets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UtilisateurProjets == null)
            {
                return NotFound();
            }

            var utilisateurProjet = await _context.UtilisateurProjets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilisateurProjet == null)
            {
                return NotFound();
            }

            return View(utilisateurProjet);
        }

        // GET: UtilisateurProjets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UtilisateurProjets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUtilisateur,IdProjet")] UtilisateurProjet utilisateurProjet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilisateurProjet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilisateurProjet);
        }

        // GET: UtilisateurProjets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UtilisateurProjets == null)
            {
                return NotFound();
            }

            var utilisateurProjet = await _context.UtilisateurProjets.FindAsync(id);
            if (utilisateurProjet == null)
            {
                return NotFound();
            }
            return View(utilisateurProjet);
        }

        // POST: UtilisateurProjets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUtilisateur,IdProjet")] UtilisateurProjet utilisateurProjet)
        {
            if (id != utilisateurProjet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilisateurProjet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilisateurProjetExists(utilisateurProjet.Id))
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
            return View(utilisateurProjet);
        }

        // GET: UtilisateurProjets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UtilisateurProjets == null)
            {
                return NotFound();
            }

            var utilisateurProjet = await _context.UtilisateurProjets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilisateurProjet == null)
            {
                return NotFound();
            }

            return View(utilisateurProjet);
        }

        // POST: UtilisateurProjets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UtilisateurProjets == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UtilisateurProjets'  is null.");
            }
            var utilisateurProjet = await _context.UtilisateurProjets.FindAsync(id);
            if (utilisateurProjet != null)
            {
                _context.UtilisateurProjets.Remove(utilisateurProjet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilisateurProjetExists(int id)
        {
          return (_context.UtilisateurProjets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
