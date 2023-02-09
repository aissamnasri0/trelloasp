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
    public class ListesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Listes
        public async Task<IActionResult> Index()
        {
              return _context.Listes != null ? 
                          View(await _context.Listes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Listes'  is null.");
        }

        // GET: Listes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Listes == null)
            {
                return NotFound();
            }

            var liste = await _context.Listes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (liste == null)
            {
                return NotFound();
            }

            return View(liste);
        }

        // GET: Listes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Listes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,IdProjet")] Liste liste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(liste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(liste);
        }

        // GET: Listes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Listes == null)
            {
                return NotFound();
            }

            var liste = await _context.Listes.FindAsync(id);
            if (liste == null)
            {
                return NotFound();
            }
            return View(liste);
        }

        // POST: Listes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,IdProjet")] Liste liste)
        {
            if (id != liste.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(liste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListeExists(liste.Id))
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
            return View(liste);
        }

        // GET: Listes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Listes == null)
            {
                return NotFound();
            }

            var liste = await _context.Listes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (liste == null)
            {
                return NotFound();
            }

            return View(liste);
        }

        // POST: Listes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Listes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Listes'  is null.");
            }
            var liste = await _context.Listes.FindAsync(id);
            if (liste != null)
            {
                _context.Listes.Remove(liste);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListeExists(int id)
        {
          return (_context.Listes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
