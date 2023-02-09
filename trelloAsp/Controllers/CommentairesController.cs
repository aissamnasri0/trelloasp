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
    public class CommentairesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentairesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Commentaires
        public async Task<IActionResult> Index()
        {
              return _context.Commentaires != null ? 
                          View(await _context.Commentaires.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Commentaires'  is null.");
        }

        // GET: Commentaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Commentaires == null)
            {
                return NotFound();
            }

            var commentaire = await _context.Commentaires
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentaire == null)
            {
                return NotFound();
            }

            return View(commentaire);
        }

        // GET: Commentaires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Commentaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Contenu,DateCreation,IdCarte,IdUtilisateur")] Commentaire commentaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commentaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commentaire);
        }

        // GET: Commentaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Commentaires == null)
            {
                return NotFound();
            }

            var commentaire = await _context.Commentaires.FindAsync(id);
            if (commentaire == null)
            {
                return NotFound();
            }
            return View(commentaire);
        }

        // POST: Commentaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Contenu,DateCreation,IdCarte,IdUtilisateur")] Commentaire commentaire)
        {
            if (id != commentaire.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentaireExists(commentaire.Id))
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
            return View(commentaire);
        }

        // GET: Commentaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Commentaires == null)
            {
                return NotFound();
            }

            var commentaire = await _context.Commentaires
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentaire == null)
            {
                return NotFound();
            }

            return View(commentaire);
        }

        // POST: Commentaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Commentaires == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Commentaires'  is null.");
            }
            var commentaire = await _context.Commentaires.FindAsync(id);
            if (commentaire != null)
            {
                _context.Commentaires.Remove(commentaire);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentaireExists(int id)
        {
          return (_context.Commentaires?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
