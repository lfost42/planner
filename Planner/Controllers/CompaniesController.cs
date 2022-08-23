using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Models;

namespace Planner.Controllers
{
    public class BTCompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BTCompaniesController(ApplicationDbContext context) // Dependency Injection
        {
            _context = context;
        }

        // GET: BTCompanies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }

        // GET: BTCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Company == null)
            {
                return NotFound();
            }

            return View(Company);
        }

        // GET: BTCompanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BTCompanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Company Company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Company);
        }

        // GET: BTCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company Company = await _context.Companies.FindAsync(id); // Switching from "var" to Company makes this more explicit
            if (Company == null)
            {
                return NotFound();
            }
            return View(Company);
        }

        // POST: BTCompanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Company Company)
        {
            if (id != Company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(Company.Id))
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
            return View(Company);
        }

        // GET: BTCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Company == null)
            {
                return NotFound();
            }

            return View(Company);
        }

        // POST: BTCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Company = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(Company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
