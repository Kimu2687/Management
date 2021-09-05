using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Attendant_check.Models;
using TASK;

namespace Attendant_check.Controllers
{
    public class Monthly_salesController : Controller
    {
        private readonly Database_Context _context;

        public Monthly_salesController(Database_Context context)
        {
            _context = context;
        }

        // GET: Monthly_sales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Monthly_sales.ToListAsync());
        }

        // GET: Monthly_sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthly_sales = await _context.Monthly_sales
                .FirstOrDefaultAsync(m => m.id == id);
            if (monthly_sales == null)
            {
                return NotFound();
            }

            return View(monthly_sales);
        }

        // GET: Monthly_sales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monthly_sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Electricity_bill,water_bill,Revenue,Transport,Salary,Buying_expenses,Gross_income,Date")] Monthly_sales monthly_sales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monthly_sales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monthly_sales);
        }

        // GET: Monthly_sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthly_sales = await _context.Monthly_sales.FindAsync(id);
            if (monthly_sales == null)
            {
                return NotFound();
            }
            return View(monthly_sales);
        }

        // POST: Monthly_sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Electricity_bill,water_bill,Revenue,Transport,Salary,Buying_expenses,Gross_income,Date")] Monthly_sales monthly_sales)
        {
            if (id != monthly_sales.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monthly_sales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Monthly_salesExists(monthly_sales.id))
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
            return View(monthly_sales);
        }

        // GET: Monthly_sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthly_sales = await _context.Monthly_sales
                .FirstOrDefaultAsync(m => m.id == id);
            if (monthly_sales == null)
            {
                return NotFound();
            }

            return View(monthly_sales);
        }

        // POST: Monthly_sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monthly_sales = await _context.Monthly_sales.FindAsync(id);
            _context.Monthly_sales.Remove(monthly_sales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Monthly_salesExists(int id)
        {
            return _context.Monthly_sales.Any(e => e.id == id);
        }
    }
}
