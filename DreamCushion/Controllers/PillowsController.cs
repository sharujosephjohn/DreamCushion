using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DreamCushion.Data;
using DreamCushion.Models;
using Microsoft.AspNetCore.Authorization;

namespace DreamCushion.Controllers
{
    public class PillowsController : Controller
    {
        private readonly DreamCushionContext _context;

        public PillowsController(DreamCushionContext context)
        {
            _context = context;
        }

        // GET: Pillows
        [Authorize]
        public async Task<IActionResult> Index(string pillowMaterial, string searchString)
        {
            if (_context.Pillow == null)
            {
                return Problem("Entity set 'DreamCushionContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Pillow
                                            orderby m.Material
                                            select m.Material;

            var pillow = from m in _context.Pillow
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                pillow = pillow.Where(s => s.Name!.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(pillowMaterial))
            {
                pillow = pillow.Where(x => x.Material == pillowMaterial);
            }

            var pillowMaterialVM = new PillowMaterialViewModel
            {
                Material = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Pillows = await pillow.ToListAsync()
            };

            return View(pillowMaterialVM);
        }

        // GET: Pillows/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pillow = await _context.Pillow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pillow == null)
            {
                return NotFound();
            }

            return View(pillow);
        }

        // GET: Pillows/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pillows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,Name,Material,Size,Price,Rating")] Pillow pillow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pillow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pillow);
        }

        // GET: Pillows/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pillow = await _context.Pillow.FindAsync(id);
            if (pillow == null)
            {
                return NotFound();
            }
            return View(pillow);
        }

        // POST: Pillows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Material,Size,Price,Rating")] Pillow pillow)
        {
            if (id != pillow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pillow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PillowExists(pillow.Id))
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
            return View(pillow);
        }

        // GET: Pillows/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pillow = await _context.Pillow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pillow == null)
            {
                return NotFound();
            }

            return View(pillow);
        }

        // POST: Pillows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pillow = await _context.Pillow.FindAsync(id);
            if (pillow != null)
            {
                _context.Pillow.Remove(pillow);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PillowExists(int id)
        {
            return _context.Pillow.Any(e => e.Id == id);
        }
    }
}
