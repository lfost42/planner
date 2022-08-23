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
    public class InvitesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvitesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Invites
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Invites.Include(b => b.Company).Include(b => b.Invitee).Include(b => b.Invitor).Include(b => b.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Invites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Invite = await _context.Invites
                .Include(b => b.Company)
                .Include(b => b.Invitee)
                .Include(b => b.Invitor)
                .Include(b => b.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Invite == null)
            {
                return NotFound();
            }

            return View(Invite);
        }

        // GET: Invites/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["InviteeId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["InvitorId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            return View();
        }

        // POST: Invites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InviteDate,JoinDate,CompanyToken,CompanyId,ProjectId,InvitorId,InviteeId,InviteeEmail,InviteeFirstName,InviteeLastName,IsValid")] Invite Invite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Invite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", Invite.CompanyId);
            ViewData["InviteeId"] = new SelectList(_context.Users, "Id", "Id", Invite.InviteeId);
            ViewData["InvitorId"] = new SelectList(_context.Users, "Id", "Id", Invite.InvitorId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", Invite.ProjectId);
            return View(Invite);
        }

        // GET: Invites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Invite = await _context.Invites.FindAsync(id);
            if (Invite == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", Invite.CompanyId);
            ViewData["InviteeId"] = new SelectList(_context.Users, "Id", "Id", Invite.InviteeId);
            ViewData["InvitorId"] = new SelectList(_context.Users, "Id", "Id", Invite.InvitorId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", Invite.ProjectId);
            return View(Invite);
        }

        // POST: Invites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InviteDate,JoinDate,CompanyToken,CompanyId,ProjectId,InvitorId,InviteeId,InviteeEmail,InviteeFirstName,InviteeLastName,IsValid")] Invite Invite)
        {
            if (id != Invite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Invite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InviteExists(Invite.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", Invite.CompanyId);
            ViewData["InviteeId"] = new SelectList(_context.Users, "Id", "Id", Invite.InviteeId);
            ViewData["InvitorId"] = new SelectList(_context.Users, "Id", "Id", Invite.InvitorId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", Invite.ProjectId);
            return View(Invite);
        }

        // GET: Invites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Invite = await _context.Invites
                .Include(b => b.Company)
                .Include(b => b.Invitee)
                .Include(b => b.Invitor)
                .Include(b => b.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Invite == null)
            {
                return NotFound();
            }

            return View(Invite);
        }

        // POST: Invites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Invite = await _context.Invites.FindAsync(id);
            _context.Invites.Remove(Invite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InviteExists(int id)
        {
            return _context.Invites.Any(e => e.Id == id);
        }
    }
}
