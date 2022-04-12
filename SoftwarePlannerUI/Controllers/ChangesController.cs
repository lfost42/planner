using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoftwarePlannerLibrary.DataAccess;
using SoftwarePlannerUI.Models;

namespace SoftwarePlannerUI.Controllers
{
    public class ChangesController : Controller
    {
        private readonly PlannerContext _context;

        public ChangesController(PlannerContext context)
        {
            _context = context;
        }

        // GET: Changes
        public async Task<IActionResult> Index()
        {
            var plannerContext = _context.Changes.Include(c => c.CreatorModel).Include(c => c.TicketModel);
            return View(await plannerContext.ToListAsync());
        }

        // GET: Changes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeModel = await _context.Changes
                .Include(c => c.CreatorModel)
                .Include(c => c.TicketModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (changeModel == null)
            {
                return NotFound();
            }

            return View(changeModel);
        }

        // GET: Changes/Create
        public IActionResult Create()
        {
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id");
            ViewData["TicketModelId"] = new SelectList(_context.Tickets, "Id", "AssignedUserlId");
            return View();
        }

        // POST: Changes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TicketModelId,UpdatedItem,Description,PreviousValue,CurrentValue,DateModified,CreatorModelId")] ChangeModel changeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(changeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", changeModel.CreatorModelId);
            ViewData["TicketModelId"] = new SelectList(_context.Tickets, "Id", "AssignedUserlId", changeModel.TicketModelId);
            return View(changeModel);
        }

        // GET: Changes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeModel = await _context.Changes.FindAsync(id);
            if (changeModel == null)
            {
                return NotFound();
            }
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", changeModel.CreatorModelId);
            ViewData["TicketModelId"] = new SelectList(_context.Tickets, "Id", "AssignedUserlId", changeModel.TicketModelId);
            return View(changeModel);
        }

        // POST: Changes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TicketModelId,UpdatedItem,Description,PreviousValue,CurrentValue,DateModified,CreatorModelId")] ChangeModel changeModel)
        {
            if (id != changeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(changeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChangeModelExists(changeModel.Id))
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
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", changeModel.CreatorModelId);
            ViewData["TicketModelId"] = new SelectList(_context.Tickets, "Id", "AssignedUserlId", changeModel.TicketModelId);
            return View(changeModel);
        }

        // GET: Changes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeModel = await _context.Changes
                .Include(c => c.CreatorModel)
                .Include(c => c.TicketModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (changeModel == null)
            {
                return NotFound();
            }

            return View(changeModel);
        }

        // POST: Changes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var changeModel = await _context.Changes.FindAsync(id);
            _context.Changes.Remove(changeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChangeModelExists(int id)
        {
            return _context.Changes.Any(e => e.Id == id);
        }
    }
}
