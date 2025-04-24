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
    public class BeneficiariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeneficiariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Beneficiaries
                .Include(b => b.Barangay)
                .Include(b => b.BeneficiaryType);

            ViewBag.Barangays = _context.Barangays
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Barangays
                }).ToList();

            ViewBag.BeneficiaryTypes = _context.BeneficiaryTypes
                .Select(bt => new SelectListItem
                {
                    Value = bt.Id.ToString(),
                    Text = bt.BeneficiaryTypes // Assuming BeneficiaryType has a 'Type' field for display
                }).ToList();

            return View(await applicationDbContext.ToListAsync());
        }
        // GET: Beneficiaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiary = await _context.Beneficiaries
                .Include(b => b.Barangay)
                .Include(b => b.BeneficiaryType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beneficiary == null)
            {
                return NotFound();
            }

            return View(beneficiary);
        }

        // GET: Beneficiaries/Create
        public IActionResult Create()
        {
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Barangays");
            ViewData["BeneficiaryTypeId"] = new SelectList(_context.BeneficiaryTypes, "Id", "BeneficiaryTypes");
            return View();
        }

        // POST: Beneficiaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Beneficiary beneficiary)
        {
           
                _context.Add(beneficiary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Barangays", beneficiary.BarangayId);
            ViewData["BeneficiaryTypeId"] = new SelectList(_context.BeneficiaryTypes, "Id", "Id", beneficiary.BeneficiaryTypeId);
            return View(beneficiary);
        }

        // GET: Beneficiaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiary = await _context.Beneficiaries.FindAsync(id);
            if (beneficiary == null)
            {
                return NotFound();
            }
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Barangays", beneficiary.BarangayId);
            ViewData["BeneficiaryTypeId"] = new SelectList(_context.BeneficiaryTypes, "Id", "BeneficiaryTypes", beneficiary.BeneficiaryTypeId);
            return View(beneficiary);
        }

        // POST: Beneficiaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,First_Name,Middle_Name,Last_Name,ID_Number,Date_Of_Birth,Contact_Number,Address,BarangayId,Eligibility_Status,BeneficiaryTypeId")] Beneficiary beneficiary)
        {
            if (id != beneficiary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beneficiary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeneficiaryExists(beneficiary.Id))
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
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Barangays", beneficiary.BarangayId);
            ViewData["BeneficiaryTypeId"] = new SelectList(_context.BeneficiaryTypes, "Id", "BeneficiaryTypes", beneficiary.BeneficiaryTypeId);
            return View(beneficiary);
        }

        // GET: Beneficiaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiary = await _context.Beneficiaries
                .Include(b => b.Barangay)
                .Include(b => b.BeneficiaryType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beneficiary == null)
            {
                return NotFound();
            }

            return View(beneficiary);
        }

        // POST: Beneficiaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beneficiary = await _context.Beneficiaries.FindAsync(id);
            if (beneficiary != null)
            {
                _context.Beneficiaries.Remove(beneficiary);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeneficiaryExists(int id)
        {
            return _context.Beneficiaries.Any(e => e.Id == id);
        }
    }
}
