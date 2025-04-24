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
    public class Program1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Program1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Program1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Programs.ToListAsync());
        }

        // GET: Program1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var program1 = await _context.Programs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (program1 == null)
            {
                return NotFound();
            }

            return View(program1);
        }

        // GET: Program1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Program1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Program_Name,Description,Eligibility_Criteria,Start_Date,End_Date")] Program1 program1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(program1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(program1);
        }

        // GET: Program1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var program1 = await _context.Programs.FindAsync(id);
            if (program1 == null)
            {
                return NotFound();
            }
            return View(program1);
        }

        // POST: Program1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Program_Name,Description,Eligibility_Criteria,Start_Date,End_Date")] Program1 program1)
        {
            if (id != program1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(program1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Program1Exists(program1.Id))
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
            return View(program1);
        }

        // GET: Program1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var program1 = await _context.Programs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (program1 == null)
            {
                return NotFound();
            }

            return View(program1);
        }

        // POST: Program1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var program1 = await _context.Programs.FindAsync(id);
            if (program1 != null)
            {
                _context.Programs.Remove(program1);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Program1Exists(int id)
        {
            return _context.Programs.Any(e => e.Id == id);
        }
    }
}
