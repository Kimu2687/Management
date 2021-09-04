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
    public class System_UsersController : Controller
    {
        private readonly Database_Context _context;

        public System_UsersController(Database_Context context)
        {
            _context = context;
        }

        // GET: System_Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.System_Users.ToListAsync());
        }

        // GET: System_Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var system_Users = await _context.System_Users
                .FirstOrDefaultAsync(m => m.id == id);
            if (system_Users == null)
            {
                return NotFound();
            }

            return View(system_Users);
        }

        // GET: System_Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: System_Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Full_names,Staff_no,Password,Date,Roles")] System_Users system_Users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(system_Users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(system_Users);
        }

        // GET: System_Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var system_Users = await _context.System_Users.FindAsync(id);
            if (system_Users == null)
            {
                return NotFound();
            }
            return View(system_Users);
        }

        // POST: System_Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Full_names,Staff_no,Password,Date,Roles")] System_Users system_Users)
        {
            if (id != system_Users.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(system_Users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!System_UsersExists(system_Users.id))
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
            return View(system_Users);
        }

        // GET: System_Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var system_Users = await _context.System_Users
                .FirstOrDefaultAsync(m => m.id == id);
            if (system_Users == null)
            {
                return NotFound();
            }

            return View(system_Users);
        }

        // POST: System_Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var system_Users = await _context.System_Users.FindAsync(id);
            _context.System_Users.Remove(system_Users);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool System_UsersExists(int id)
        {
            return _context.System_Users.Any(e => e.id == id);
        }
    }
}
