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
    public class CertificateOfIndigenciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CertificateOfIndigenciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CertificateOfIndigencies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CertificateOfIndigencies
                .Include(c => c.Barangay);

            ViewBag.Barangays = _context.Barangays
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Barangays
                }).ToList();

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CertificateOfIndigencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateOfIndigency = await _context.CertificateOfIndigencies
                .Include(c => c.Barangay)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificateOfIndigency == null)
            {
                return NotFound();
            }

            return View(certificateOfIndigency);
        }

        // GET: CertificateOfIndigencies/Create
        public IActionResult Create()
        {
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Barangays");
            return View();
        }

        // POST: CertificateOfIndigencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CertificateOfIndigency certificateOfIndigency)
        {
           
                _context.Add(certificateOfIndigency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Barangays", certificateOfIndigency.BarangayId);
            return View(certificateOfIndigency);
        }

        // GET: CertificateOfIndigencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateOfIndigency = await _context.CertificateOfIndigencies.FindAsync(id);
            if (certificateOfIndigency == null)
            {
                return NotFound();
            }
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Barangays", certificateOfIndigency.BarangayId);
            return View(certificateOfIndigency);
        }

        // POST: CertificateOfIndigencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,First_Name,Middle_Name,Last_Name,BarangayId,Date_Issued,Validate")] CertificateOfIndigency certificateOfIndigency)
        {
            if (id != certificateOfIndigency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificateOfIndigency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificateOfIndigencyExists(certificateOfIndigency.Id))
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
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Barangays", certificateOfIndigency.BarangayId);
            return View(certificateOfIndigency);
        }

        // GET: CertificateOfIndigencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateOfIndigency = await _context.CertificateOfIndigencies
                .Include(c => c.Barangay)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificateOfIndigency == null)
            {
                return NotFound();
            }

            return View(certificateOfIndigency);
        }

        // POST: CertificateOfIndigencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certificateOfIndigency = await _context.CertificateOfIndigencies.FindAsync(id);
            if (certificateOfIndigency != null)
            {
                _context.CertificateOfIndigencies.Remove(certificateOfIndigency);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificateOfIndigencyExists(int id)
        {
            return _context.CertificateOfIndigencies.Any(e => e.Id == id);
        }
    }
}
