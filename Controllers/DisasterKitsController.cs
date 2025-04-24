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
    public class DisasterKitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisasterKitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DisasterKits
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DisasterKits
                .Include(c => c.Barangay);

            ViewBag.Barangays = _context.Barangays
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Barangays
                }).ToList();

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DisasterKits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disasterKit = await _context.DisasterKits
                .Include(d => d.Barangay)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disasterKit == null)
            {
                return NotFound();
            }

            return View(disasterKit);
        }

        // GET: DisasterKits/Create
        public IActionResult Create()
        {
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Barangays");
            return View();
        }

        // POST: DisasterKits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( DisasterKit disasterKit)
        {
           
                _context.Add(disasterKit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Id", disasterKit.BarangayId);
            return View(disasterKit);
        }

        // GET: DisasterKits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disasterKit = await _context.DisasterKits.FindAsync(id);
            if (disasterKit == null)
            {
                return NotFound();
            }
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Barangays", disasterKit.BarangayId);
            return View(disasterKit);
        }

        // POST: DisasterKits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,First_Name,Middle_Name,Last_Name,BarangayId,Date_Issued,Validate")] DisasterKit disasterKit)
        {
            if (id != disasterKit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disasterKit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisasterKitExists(disasterKit.Id))
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
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Barangays", disasterKit.BarangayId);
            return View(disasterKit);
        }

        // GET: DisasterKits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disasterKit = await _context.DisasterKits
                .Include(d => d.Barangay)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disasterKit == null)
            {
                return NotFound();
            }

            return View(disasterKit);
        }

        // POST: DisasterKits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disasterKit = await _context.DisasterKits.FindAsync(id);
            if (disasterKit != null)
            {
                _context.DisasterKits.Remove(disasterKit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisasterKitExists(int id)
        {
            return _context.DisasterKits.Any(e => e.Id == id);
        }
    }
}
