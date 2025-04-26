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
    public class FoodPackFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodPackFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FoodPackForms
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodPackForms.ToListAsync());
        }

        // GET: FoodPackForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodPackForm = await _context.FoodPackForms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodPackForm == null)
            {
                return NotFound();
            }

            return View(foodPackForm);
        }

        // GET: FoodPackForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodPackForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,Age,DateOfBirth,ContactNumber,Barangay,Address,Status")] FoodPackForm foodPackForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodPackForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodPackForm);
        }

        // GET: FoodPackForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodPackForm = await _context.FoodPackForms.FindAsync(id);
            if (foodPackForm == null)
            {
                return NotFound();
            }
            return View(foodPackForm);
        }

        // POST: FoodPackForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,Age,DateOfBirth,ContactNumber,Barangay,Address,Status")] FoodPackForm foodPackForm)
        {
            if (id != foodPackForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodPackForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodPackFormExists(foodPackForm.Id))
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
            return View(foodPackForm);
        }

        // GET: FoodPackForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodPackForm = await _context.FoodPackForms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodPackForm == null)
            {
                return NotFound();
            }

            return View(foodPackForm);
        }

        // POST: FoodPackForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodPackForm = await _context.FoodPackForms.FindAsync(id);
            if (foodPackForm != null)
            {
                _context.FoodPackForms.Remove(foodPackForm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodPackFormExists(int id)
        {
            return _context.FoodPackForms.Any(e => e.Id == id);
        }
    }
}
