using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoftwarePlannerLibrary.DataAccess;
using SoftwarePlannerLibrary.Models;

namespace SoftwarePlannerUI.Controllers
{
    public class PriorityController : Controller
    {
        private readonly PlannerContext _context;

        public PriorityController(PlannerContext context)
        {
            _context = context;
        }

        // GET: PriorityModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Priorities.ToListAsync());
        }

        // GET: PriorityModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priorityModel = await _context.Priorities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priorityModel == null)
            {
                return NotFound();
            }

            return View(priorityModel);
        }

        // GET: PriorityModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PriorityModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PriorityLevel")] PriorityModel priorityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(priorityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(priorityModel);
        }

        // GET: PriorityModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priorityModel = await _context.Priorities.FindAsync(id);
            if (priorityModel == null)
            {
                return NotFound();
            }
            return View(priorityModel);
        }

        // POST: PriorityModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PriorityLevel")] PriorityModel priorityModel)
        {
            if (id != priorityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priorityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriorityModelExists(priorityModel.Id))
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
            return View(priorityModel);
        }

        // GET: PriorityModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priorityModel = await _context.Priorities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priorityModel == null)
            {
                return NotFound();
            }

            return View(priorityModel);
        }

        // POST: PriorityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var priorityModel = await _context.Priorities.FindAsync(id);
            _context.Priorities.Remove(priorityModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PriorityModelExists(int id)
        {
            return _context.Priorities.Any(e => e.Id == id);
        }
    }
}
