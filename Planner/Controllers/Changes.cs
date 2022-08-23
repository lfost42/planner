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
    public class ChangesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChangesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Changes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Changes.Include(b => b.Ticket).Include(b => b.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Changes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TicketHistory = await _context.Changes
                .Include(b => b.Ticket)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (TicketHistory == null)
            {
                return NotFound();
            }

            return View(TicketHistory);
        }

        // GET: Changes/Create
        public IActionResult Create()
        {
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Changes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TicketId,Property,OldValue,NewValue,Created,Description,UserId")] TicketHistory TicketHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(TicketHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description", TicketHistory.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", TicketHistory.UserId);
            return View(TicketHistory);
        }

        // GET: Changes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TicketHistory = await _context.Changes.FindAsync(id);
            if (TicketHistory == null)
            {
                return NotFound();
            }
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description", TicketHistory.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", TicketHistory.UserId);
            return View(TicketHistory);
        }

        // POST: Changes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TicketId,Property,OldValue,NewValue,Created,Description,UserId")] TicketHistory TicketHistory)
        {
            if (id != TicketHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(TicketHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketHistoryExists(TicketHistory.Id))
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
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description", TicketHistory.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", TicketHistory.UserId);
            return View(TicketHistory);
        }

        // GET: Changes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TicketHistory = await _context.Changes
                .Include(b => b.Ticket)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (TicketHistory == null)
            {
                return NotFound();
            }

            return View(TicketHistory);
        }

        // POST: Changes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var TicketHistory = await _context.Changes.FindAsync(id);
            _context.Changes.Remove(TicketHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketHistoryExists(int id)
        {
            return _context.Changes.Any(e => e.Id == id);
        }
    }
}
