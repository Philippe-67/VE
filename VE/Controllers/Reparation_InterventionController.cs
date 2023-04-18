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
    public class Reparation_InterventionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Reparation_InterventionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reparation_Intervention
        public async Task<IActionResult> Index()
        {
              return _context.Reparation_Intervention != null ? 
                          View(await _context.Reparation_Intervention.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Reparation_Intervention'  is null.");
        }

        // GET: Reparation_Intervention/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reparation_Intervention == null)
            {
                return NotFound();
            }

            var reparation_Intervention = await _context.Reparation_Intervention
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reparation_Intervention == null)
            {
                return NotFound();
            }

            return View(reparation_Intervention);
        }

        // GET: Reparation_Intervention/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reparation_Intervention/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeIntervention")] Reparation_Intervention reparation_Intervention)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reparation_Intervention);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reparation_Intervention);
        }

        // GET: Reparation_Intervention/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reparation_Intervention == null)
            {
                return NotFound();
            }

            var reparation_Intervention = await _context.Reparation_Intervention.FindAsync(id);
            if (reparation_Intervention == null)
            {
                return NotFound();
            }
            return View(reparation_Intervention);
        }

        // POST: Reparation_Intervention/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeIntervention")] Reparation_Intervention reparation_Intervention)
        {
            if (id != reparation_Intervention.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reparation_Intervention);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Reparation_InterventionExists(reparation_Intervention.Id))
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
            return View(reparation_Intervention);
        }

        // GET: Reparation_Intervention/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reparation_Intervention == null)
            {
                return NotFound();
            }

            var reparation_Intervention = await _context.Reparation_Intervention
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reparation_Intervention == null)
            {
                return NotFound();
            }

            return View(reparation_Intervention);
        }

        // POST: Reparation_Intervention/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reparation_Intervention == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reparation_Intervention'  is null.");
            }
            var reparation_Intervention = await _context.Reparation_Intervention.FindAsync(id);
            if (reparation_Intervention != null)
            {
                _context.Reparation_Intervention.Remove(reparation_Intervention);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Reparation_InterventionExists(int id)
        {
          return (_context.Reparation_Intervention?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
