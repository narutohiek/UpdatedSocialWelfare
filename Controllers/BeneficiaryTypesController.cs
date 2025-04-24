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
    public class BeneficiaryTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeneficiaryTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BeneficiaryTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.BeneficiaryTypes.ToListAsync());
        }

        // GET: BeneficiaryTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiaryType = await _context.BeneficiaryTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beneficiaryType == null)
            {
                return NotFound();
            }

            return View(beneficiaryType);
        }

        // GET: BeneficiaryTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BeneficiaryTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BeneficiaryTypes")] BeneficiaryType beneficiaryType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beneficiaryType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beneficiaryType);
        }

        // GET: BeneficiaryTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiaryType = await _context.BeneficiaryTypes.FindAsync(id);
            if (beneficiaryType == null)
            {
                return NotFound();
            }
            return View(beneficiaryType);
        }

        // POST: BeneficiaryTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BeneficiaryTypes")] BeneficiaryType beneficiaryType)
        {
            if (id != beneficiaryType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beneficiaryType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeneficiaryTypeExists(beneficiaryType.Id))
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
            return View(beneficiaryType);
        }

        // GET: BeneficiaryTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiaryType = await _context.BeneficiaryTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beneficiaryType == null)
            {
                return NotFound();
            }

            return View(beneficiaryType);
        }

        // POST: BeneficiaryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beneficiaryType = await _context.BeneficiaryTypes.FindAsync(id);
            if (beneficiaryType != null)
            {
                _context.BeneficiaryTypes.Remove(beneficiaryType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeneficiaryTypeExists(int id)
        {
            return _context.BeneficiaryTypes.Any(e => e.Id == id);
        }
    }
}
