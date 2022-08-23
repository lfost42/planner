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
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tickets.Include(b => b.DeveloperUser).Include(b => b.OwnerUser).Include(b => b.Project).Include(b => b.TicketPriority).Include(b => b.TicketStatus).Include(b => b.TicketType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Ticket = await _context.Tickets
                .Include(b => b.DeveloperUser)
                .Include(b => b.OwnerUser)
                .Include(b => b.Project)
                .Include(b => b.TicketPriority)
                .Include(b => b.TicketStatus)
                .Include(b => b.TicketType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Ticket == null)
            {
                return NotFound();
            }

            return View(Ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            ViewData["DeveloperUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["OwnerUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ProjectID"] = new SelectList(_context.Projects, "Id", "Name");
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriorities, "Id", "Id");
            ViewData["TicketStatusId"] = new SelectList(_context.TicketStatuses, "Id", "Id");
            ViewData["TicketTypeId"] = new SelectList(_context.TicketTypes, "Id", "Id");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Created,Updated,Archived,ProjectID,TicketTypeId,TicketPriorityId,TicketStatusId,OwnerUserId,DeveloperUserId")] Ticket Ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeveloperUserId"] = new SelectList(_context.Users, "Id", "Id", Ticket.DeveloperUserId);
            ViewData["OwnerUserId"] = new SelectList(_context.Users, "Id", "Id", Ticket.OwnerUserId);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "Id", "Name", Ticket.ProjectID);
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriorities, "Id", "Id", Ticket.TicketPriorityId);
            ViewData["TicketStatusId"] = new SelectList(_context.TicketStatuses, "Id", "Id", Ticket.TicketStatusId);
            ViewData["TicketTypeId"] = new SelectList(_context.TicketTypes, "Id", "Id", Ticket.TicketTypeId);
            return View(Ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Ticket = await _context.Tickets.FindAsync(id);
            if (Ticket == null)
            {
                return NotFound();
            }
            ViewData["DeveloperUserId"] = new SelectList(_context.Users, "Id", "Id", Ticket.DeveloperUserId);
            ViewData["OwnerUserId"] = new SelectList(_context.Users, "Id", "Id", Ticket.OwnerUserId);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "Id", "Name", Ticket.ProjectID);
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriorities, "Id", "Id", Ticket.TicketPriorityId);
            ViewData["TicketStatusId"] = new SelectList(_context.TicketStatuses, "Id", "Id", Ticket.TicketStatusId);
            ViewData["TicketTypeId"] = new SelectList(_context.TicketTypes, "Id", "Id", Ticket.TicketTypeId);
            return View(Ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Created,Updated,Archived,ProjectID,TicketTypeId,TicketPriorityId,TicketStatusId,OwnerUserId,DeveloperUserId")] Ticket Ticket)
        {
            if (id != Ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(Ticket.Id))
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
            ViewData["DeveloperUserId"] = new SelectList(_context.Users, "Id", "Id", Ticket.DeveloperUserId);
            ViewData["OwnerUserId"] = new SelectList(_context.Users, "Id", "Id", Ticket.OwnerUserId);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "Id", "Name", Ticket.ProjectID);
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriorities, "Id", "Id", Ticket.TicketPriorityId);
            ViewData["TicketStatusId"] = new SelectList(_context.TicketStatuses, "Id", "Id", Ticket.TicketStatusId);
            ViewData["TicketTypeId"] = new SelectList(_context.TicketTypes, "Id", "Id", Ticket.TicketTypeId);
            return View(Ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Ticket = await _context.Tickets
                .Include(b => b.DeveloperUser)
                .Include(b => b.OwnerUser)
                .Include(b => b.Project)
                .Include(b => b.TicketPriority)
                .Include(b => b.TicketStatus)
                .Include(b => b.TicketType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Ticket == null)
            {
                return NotFound();
            }

            return View(Ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Ticket = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(Ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
