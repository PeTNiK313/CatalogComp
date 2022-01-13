using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatalogComp.Models;

namespace CatalogComp.Controllers
{
    public class SponsersController : Controller
    {
        private readonly CatalogCompContext _context;

        public SponsersController(CatalogCompContext context)
        {
            _context = context;
        }

        // GET: Sponsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sponser.ToListAsync());
        }

        // GET: Sponsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponser = await _context.Sponser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sponser == null)
            {
                return NotFound();
            }

            return View(sponser);
        }

        // GET: Sponsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sponsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Sponser sponser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sponser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sponser);
        }

        // GET: Sponsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponser = await _context.Sponser.FindAsync(id);
            if (sponser == null)
            {
                return NotFound();
            }
            return View(sponser);
        }

        // POST: Sponsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Sponser sponser)
        {
            if (id != sponser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sponser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SponserExists(sponser.Id))
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
            return View(sponser);
        }

        // GET: Sponsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponser = await _context.Sponser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sponser == null)
            {
                return NotFound();
            }

            return View(sponser);
        }

        // POST: Sponsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sponser = await _context.Sponser.FindAsync(id);
            _context.Sponser.Remove(sponser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SponserExists(int id)
        {
            return _context.Sponser.Any(e => e.Id == id);
        }
    }
}
