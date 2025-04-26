using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocialWelfarre.Data;
using SocialWelfarre.Models;

namespace SocialWelfarre.Controllers
{
    public class Certificate_Of_IndigencyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Certificate_Of_IndigencyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Certificate_Of_Indigency
        public async Task<IActionResult> Index()
        {
            return View(await _context.Certificate_Of_Indigencies.ToListAsync());
        }

        // GET: Certificate_Of_Indigency/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate_Of_Indigency = await _context.Certificate_Of_Indigencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificate_Of_Indigency == null)
            {
                return NotFound();
            }

            return View(certificate_Of_Indigency);
        }

        // GET: Certificate_Of_Indigency/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Certificate_Of_Indigency/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,Age,Barangay,Address,ContactNumber,Brgy_Cert,Valid_ID,Reason,Status")] Certificate_Of_Indigency certificate_Of_Indigency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certificate_Of_Indigency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(certificate_Of_Indigency);
        }

        // GET: Certificate_Of_Indigency/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate_Of_Indigency = await _context.Certificate_Of_Indigencies.FindAsync(id);
            if (certificate_Of_Indigency == null)
            {
                return NotFound();
            }
            return View(certificate_Of_Indigency);
        }

        // POST: Certificate_Of_Indigency/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,Age,Barangay,Address,ContactNumber,Brgy_Cert,Valid_ID,Reason,Status")] Certificate_Of_Indigency certificate_Of_Indigency)
        {
            if (id != certificate_Of_Indigency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificate_Of_Indigency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Certificate_Of_IndigencyExists(certificate_Of_Indigency.Id))
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
            return View(certificate_Of_Indigency);
        }

        // GET: Certificate_Of_Indigency/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate_Of_Indigency = await _context.Certificate_Of_Indigencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificate_Of_Indigency == null)
            {
                return NotFound();
            }

            return View(certificate_Of_Indigency);
        }

        // POST: Certificate_Of_Indigency/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certificate_Of_Indigency = await _context.Certificate_Of_Indigencies.FindAsync(id);
            if (certificate_Of_Indigency != null)
            {
                _context.Certificate_Of_Indigencies.Remove(certificate_Of_Indigency);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Certificate_Of_IndigencyExists(int id)
        {
            return _context.Certificate_Of_Indigencies.Any(e => e.Id == id);
        }
    }
}
