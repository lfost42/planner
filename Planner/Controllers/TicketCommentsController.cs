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
    public class TicketNotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketNotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TicketNotes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TicketNotes.Include(b => b.Ticket).Include(b => b.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TicketNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TicketNote = await _context.TicketNotes
                .Include(b => b.Ticket)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (TicketNote == null)
            {
                return NotFound();
            }

            return View(TicketNote);
        }

        // GET: TicketNotes/Create
        public IActionResult Create()
        {
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TicketNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Note,Created,TicketId,UserId")] TicketNote TicketNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(TicketNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description", TicketNote.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", TicketNote.UserId);
            return View(TicketNote);
        }

        // GET: TicketNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TicketNote = await _context.TicketNotes.FindAsync(id);
            if (TicketNote == null)
            {
                return NotFound();
            }
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description", TicketNote.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", TicketNote.UserId);
            return View(TicketNote);
        }

        // POST: TicketNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Note,Created,TicketId,UserId")] TicketNote TicketNote)
        {
            if (id != TicketNote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(TicketNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketNoteExists(TicketNote.Id))
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
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description", TicketNote.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", TicketNote.UserId);
            return View(TicketNote);
        }

        // GET: TicketNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TicketNote = await _context.TicketNotes
                .Include(b => b.Ticket)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (TicketNote == null)
            {
                return NotFound();
            }

            return View(TicketNote);
        }

        // POST: TicketNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var TicketNote = await _context.TicketNotes.FindAsync(id);
            _context.TicketNotes.Remove(TicketNote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketNoteExists(int id)
        {
            return _context.TicketNotes.Any(e => e.Id == id);
        }
    }
}
