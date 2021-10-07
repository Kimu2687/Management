using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Attendant_check.Models;
using TASK;
using TASK.Base_controller;

namespace Attendant_check.Controllers
{
    public class CartonsController : BaseController
    {
        private readonly Database_Context _context;

        public CartonsController(Database_Context context)
        {
            _context = context;
        }

        // GET: Cartons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cartons.ToListAsync());
        }

        // GET: Cartons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartons = await _context.Cartons
                .FirstOrDefaultAsync(m => m.id == id);
            if (cartons == null)
            {
                return NotFound();
            }

            return View(cartons);
        }

        // GET: Cartons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cartons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Carton_category,Buying_price,Selling_price,No_of_bottle,bottle_per_carton")] Cartons cartons)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartons);
                await _context.SaveChangesAsync();
                swal("Success!", "Cartons category recorded successfully", "success");
                return Redirect("~/home/Dashboard");
            }
            return View(cartons);
        }

        // GET: Cartons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartons = await _context.Cartons.FindAsync(id);
            if (cartons == null)
            {
                return NotFound();
            }
            return View(cartons);
        }

        // POST: Cartons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Carton_category,Buying_price,Selling_price,No_of_bottle,bottle_per_carton")] Cartons cartons)
        {
            if (id != cartons.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartonsExists(cartons.id))
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
            return View(cartons);
        }

        // GET: Cartons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartons = await _context.Cartons
                .FirstOrDefaultAsync(m => m.id == id);
            if (cartons == null)
            {
                return NotFound();
            }

            return View(cartons);
        }

        // POST: Cartons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartons = await _context.Cartons.FindAsync(id);
            _context.Cartons.Remove(cartons);
            await _context.SaveChangesAsync();
            swal("Success", "Record deleted successfullY", "success");
            return Redirect("~/home/Dashboard");
        }

        private bool CartonsExists(int id)
        {
            return _context.Cartons.Any(e => e.id == id);
        }
    }
}
