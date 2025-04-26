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
    public class DisasterKitTransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisasterKitTransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DisasterKitTransactions
        public async Task<IActionResult> Index()
        {
            return View(await _context.DisasterKitTransactions.ToListAsync());
        }

        // GET: DisasterKitTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disasterKitTransaction = await _context.DisasterKitTransactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disasterKitTransaction == null)
            {
                return NotFound();
            }

            return View(disasterKitTransaction);
        }

        // GET: DisasterKitTransactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DisasterKitTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Barangay,Reason,TransactionDate,TransactionTime,NumberOfPacks")] DisasterKitTransaction disasterKitTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disasterKitTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disasterKitTransaction);
        }

        // GET: DisasterKitTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disasterKitTransaction = await _context.DisasterKitTransactions.FindAsync(id);
            if (disasterKitTransaction == null)
            {
                return NotFound();
            }
            return View(disasterKitTransaction);
        }

        // POST: DisasterKitTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Barangay,Reason,TransactionDate,TransactionTime,NumberOfPacks")] DisasterKitTransaction disasterKitTransaction)
        {
            if (id != disasterKitTransaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disasterKitTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisasterKitTransactionExists(disasterKitTransaction.Id))
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
            return View(disasterKitTransaction);
        }

        // GET: DisasterKitTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disasterKitTransaction = await _context.DisasterKitTransactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disasterKitTransaction == null)
            {
                return NotFound();
            }

            return View(disasterKitTransaction);
        }

        // POST: DisasterKitTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disasterKitTransaction = await _context.DisasterKitTransactions.FindAsync(id);
            if (disasterKitTransaction != null)
            {
                _context.DisasterKitTransactions.Remove(disasterKitTransaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisasterKitTransactionExists(int id)
        {
            return _context.DisasterKitTransactions.Any(e => e.Id == id);
        }
    }
}
