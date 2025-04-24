using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocialWelfarre.Models;
using SocialWelfarre.Data;

namespace SocialWelfarre.Controllers
{
    public class BarangaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BarangaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Barangays
        public async Task<IActionResult> Index()
        {
            return View(await _context.Barangays.ToListAsync());
        }

        // GET: Barangays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barangay = await _context.Barangays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barangay == null)
            {
                return NotFound();
            }

            return View(barangay);
        }

        // GET: Barangays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Barangays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Barangays")] Barangay barangay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barangay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(barangay);
        }

        // GET: Barangays/Edit/5
        // GET: Barangays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barangay = await _context.Barangays.FindAsync(id);
            if (barangay == null)
            {
                return NotFound();
            }
            return View(barangay);
        }


        // POST: Barangays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Barangays")] Barangay barangay)
        {
            if (id != barangay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barangay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarangayExists(barangay.Id))
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
            return View(barangay);
        }

        // GET: Barangays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barangay = await _context.Barangays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barangay == null)
            {
                return NotFound();
            }

            return View(barangay);
        }

        // POST: Barangays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barangay = await _context.Barangays.FindAsync(id);
            if (barangay != null)
            {
                _context.Barangays.Remove(barangay);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarangayExists(int id)
        {
            return _context.Barangays.Any(e => e.Id == id);
        }
    }
}
