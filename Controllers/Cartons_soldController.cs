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
    public class Cartons_soldController : Controller
    {
        private readonly Database_Context _context;

        public Cartons_soldController(Database_Context context)
        {
            _context = context;
        }

        // GET: Cartons_sold
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cartons_sold.ToListAsync());
        }

        // GET: Cartons_sold/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartons_sold = await _context.Cartons_sold
                .FirstOrDefaultAsync(m => m.id == id);
            if (cartons_sold == null)
            {
                return NotFound();
            }

            return View(cartons_sold);
        }

        // GET: Cartons_sold/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cartons_sold/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Carton_category,Cartons_sold_,Total,Date")] Cartons_sold cartons_sold)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartons_sold);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartons_sold);
        }

        // GET: Cartons_sold/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartons_sold = await _context.Cartons_sold.FindAsync(id);
            if (cartons_sold == null)
            {
                return NotFound();
            }
            return View(cartons_sold);
        }

        // POST: Cartons_sold/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Carton_category,Cartons_sold_,Total,Date")] Cartons_sold cartons_sold)
        {
            if (id != cartons_sold.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartons_sold);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cartons_soldExists(cartons_sold.id))
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
            return View(cartons_sold);
        }

        // GET: Cartons_sold/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartons_sold = await _context.Cartons_sold
                .FirstOrDefaultAsync(m => m.id == id);
            if (cartons_sold == null)
            {
                return NotFound();
            }

            return View(cartons_sold);
        }

        // POST: Cartons_sold/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartons_sold = await _context.Cartons_sold.FindAsync(id);
            _context.Cartons_sold.Remove(cartons_sold);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cartons_soldExists(int id)
        {
            return _context.Cartons_sold.Any(e => e.id == id);
        }
    }
}
