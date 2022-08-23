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
    public class AttachmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttachmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Attachments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Attachments.Include(b => b.Ticket).Include(b => b.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Attachments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TicketAttachment = await _context.Attachments
                .Include(b => b.Ticket)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (TicketAttachment == null)
            {
                return NotFound();
            }

            return View(TicketAttachment);
        }

        // GET: Attachments/Create
        public IActionResult Create()
        {
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Attachments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TicketId,Created,UserId,Description,FileName,FileData,FileContentType")] TicketAttachment TicketAttachment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(TicketAttachment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description", TicketAttachment.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", TicketAttachment.UserId);
            return View(TicketAttachment);
        }

        // GET: Attachments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TicketAttachment = await _context.Attachments.FindAsync(id);
            if (TicketAttachment == null)
            {
                return NotFound();
            }
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description", TicketAttachment.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", TicketAttachment.UserId);
            return View(TicketAttachment);
        }

        // POST: Attachments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TicketId,Created,UserId,Description,FileName,FileData,FileContentType")] TicketAttachment TicketAttachment)
        {
            if (id != TicketAttachment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(TicketAttachment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketAttachmentExists(TicketAttachment.Id))
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
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Description", TicketAttachment.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", TicketAttachment.UserId);
            return View(TicketAttachment);
        }

        // GET: Attachments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TicketAttachment = await _context.Attachments
                .Include(b => b.Ticket)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (TicketAttachment == null)
            {
                return NotFound();
            }

            return View(TicketAttachment);
        }

        // POST: Attachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var TicketAttachment = await _context.Attachments.FindAsync(id);
            _context.Attachments.Remove(TicketAttachment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketAttachmentExists(int id)
        {
            return _context.Attachments.Any(e => e.Id == id);
        }
    }
}
