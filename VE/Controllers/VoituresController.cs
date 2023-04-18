using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VE.Data;
using VE.Models;

namespace VE.Controllers
{
    public class VoituresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoituresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Voitures
        public async Task<IActionResult> Index()
        {
              return _context.Voitures != null ? 
                          View(await _context.Voitures.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Voitures'  is null.");
        }

        // GET: Voitures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voitures = await _context.Voitures
                .FirstOrDefaultAsync(m => m.VoituresId == id);
            if (voitures == null)
            {
                return NotFound();
            }

            return View(voitures);
        }

        // GET: Voitures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoituresId,DateAchat,Marque,Finition,Modele,Annee,DateVente,PrixAchat,PrixVente,VoituresExists")] Voitures voitures)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voitures);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voitures);
        }

        // GET: Voitures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voitures = await _context.Voitures.FindAsync(id);
            if (voitures == null)
            {
                return NotFound();
            }
            return View(voitures);
        }

        // POST: Voitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoituresId,DateAchat,Marque,Finition,Modele,Annee,DateVente,PrixAchat,PrixVente,VoituresExists")] Voitures voitures)
        {
            if (id != voitures.VoituresId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voitures);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoituresExists(voitures.VoituresId))
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
            return View(voitures);
        }

        // GET: Voitures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voitures = await _context.Voitures
                .FirstOrDefaultAsync(m => m.VoituresId == id);
            if (voitures == null)
            {
                return NotFound();
            }

            return View(voitures);
        }

        // POST: Voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Voitures == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Voitures'  is null.");
            }
            var voitures = await _context.Voitures.FindAsync(id);
            if (voitures != null)
            {
                _context.Voitures.Remove(voitures);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoituresExists(int id)
        {
          return (_context.Voitures?.Any(e => e.VoituresId == id)).GetValueOrDefault();
        }
    }
}
