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
    public class FoodPacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodPacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FoodPacks
        
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FoodPacks
                .Include(f => f.Barangay);

            ViewBag.Barangays = _context.Barangays
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Barangays
                }).ToList();

            return View(await applicationDbContext.ToListAsync());
        }


        // GET: FoodPacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodPack = await _context.FoodPacks
                .Include(f => f.Barangay)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodPack == null)
            {
                return NotFound();
            }

            return View(foodPack);
        }

        // GET: FoodPacks/Create
        public IActionResult Create()
        {
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Barangays");
            return View();
        }

        // POST: FoodPacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( FoodPack foodPack)
        {
            
                _context.Add(foodPack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Id", foodPack.BarangayId);
            return View(foodPack);
        }

        // GET: FoodPacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodPack = await _context.FoodPacks.FindAsync(id);
            if (foodPack == null)
            {
                return NotFound();
            }
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Barangays", foodPack.BarangayId);
            return View(foodPack);
        }

        // POST: FoodPacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,First_Name,Middle_Name,Last_Name,BarangayId,Date_Issued,Validate")] FoodPack foodPack)
        {
            if (id != foodPack.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodPack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodPackExists(foodPack.Id))
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
            ViewData["BarangayId"] = new SelectList(_context.Barangays, "Id", "Barangays", foodPack.BarangayId);
            return View(foodPack);
        }

        // GET: FoodPacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodPack = await _context.FoodPacks
                .Include(f => f.Barangay)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodPack == null)
            {
                return NotFound();
            }

            return View(foodPack);
        }

        // POST: FoodPacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodPack = await _context.FoodPacks.FindAsync(id);
            if (foodPack != null)
            {
                _context.FoodPacks.Remove(foodPack);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodPackExists(int id)
        {
            return _context.FoodPacks.Any(e => e.Id == id);
        }
    }
}
