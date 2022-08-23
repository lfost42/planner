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
    public class NotificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Notifications.Include(b => b.Recipient).Include(b => b.Sender).Include(b => b.Ticket);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Notifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Notification = await _context.Notifications
                .Include(b => b.Recipient)
                .Include(b => b.Sender)
                .Include(b => b.Ticket)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Notification == null)
            {
                return NotFound();
            }

            return View(Notification);
        }

        // GET: Notifications/Create
        public IActionResult Create()
        {
            ViewData["RecipientId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["SenderId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description");
            return View();
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TicketId,Title,Message,Created,RecipientId,SenderId,Viewed")] Notification Notification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Notification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipientId"] = new SelectList(_context.Users, "Id", "Id", Notification.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Users, "Id", "Id", Notification.SenderId);
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description", Notification.TicketId);
            return View(Notification);
        }

        // GET: Notifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Notification = await _context.Notifications.FindAsync(id);
            if (Notification == null)
            {
                return NotFound();
            }
            ViewData["RecipientId"] = new SelectList(_context.Users, "Id", "Id", Notification.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Users, "Id", "Id", Notification.SenderId);
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description", Notification.TicketId);
            return View(Notification);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TicketId,Title,Message,Created,RecipientId,SenderId,Viewed")] Notification Notification)
        {
            if (id != Notification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Notification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationExists(Notification.Id))
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
            ViewData["RecipientId"] = new SelectList(_context.Users, "Id", "Id", Notification.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Users, "Id", "Id", Notification.SenderId);
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description", Notification.TicketId);
            return View(Notification);
        }

        // GET: Notifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Notification = await _context.Notifications
                .Include(b => b.Recipient)
                .Include(b => b.Sender)
                .Include(b => b.Ticket)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Notification == null)
            {
                return NotFound();
            }

            return View(Notification);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Notification = await _context.Notifications.FindAsync(id);
            _context.Notifications.Remove(Notification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationExists(int id)
        {
            return _context.Notifications.Any(e => e.Id == id);
        }
    }
}
