using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Planner.Data.Data;
using Planner.Data.Models;

namespace PlannerUI.Controllers
{
    public class AlertsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlertsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alerts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Alerts.Include(a => a.CreatorModel).Include(a => a.Note).Include(a => a.Recipient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Alerts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alertModel = await _context.Alerts
                .Include(a => a.CreatorModel)
                .Include(a => a.Note)
                .Include(a => a.Recipient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alertModel == null)
            {
                return NotFound();
            }

            return View(alertModel);
        }

        // GET: Alerts/Create
        public IActionResult Create()
        {
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id");
            ViewData["NoteId"] = new SelectList(_context.Notes, "Id", "AssignedUserlId");
            ViewData["RecipientId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Alerts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateCreated,RecipientId,CreatorModelId,Read,NoteId,Subject,Message")] AlertModel alertModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alertModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", alertModel.CreatorModelId);
            ViewData["NoteId"] = new SelectList(_context.Notes, "Id", "AssignedUserlId", alertModel.NoteId);
            ViewData["RecipientId"] = new SelectList(_context.Users, "Id", "Id", alertModel.RecipientId);
            return View(alertModel);
        }

        // GET: Alerts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alertModel = await _context.Alerts.FindAsync(id);
            if (alertModel == null)
            {
                return NotFound();
            }
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", alertModel.CreatorModelId);
            ViewData["NoteId"] = new SelectList(_context.Notes, "Id", "AssignedUserlId", alertModel.NoteId);
            ViewData["RecipientId"] = new SelectList(_context.Users, "Id", "Id", alertModel.RecipientId);
            return View(alertModel);
        }

        // POST: Alerts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateCreated,RecipientId,CreatorModelId,Read,NoteId,Subject,Message")] AlertModel alertModel)
        {
            if (id != alertModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alertModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlertModelExists(alertModel.Id))
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
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", alertModel.CreatorModelId);
            ViewData["NoteId"] = new SelectList(_context.Notes, "Id", "AssignedUserlId", alertModel.NoteId);
            ViewData["RecipientId"] = new SelectList(_context.Users, "Id", "Id", alertModel.RecipientId);
            return View(alertModel);
        }

        // GET: Alerts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alertModel = await _context.Alerts
                .Include(a => a.CreatorModel)
                .Include(a => a.Note)
                .Include(a => a.Recipient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alertModel == null)
            {
                return NotFound();
            }

            return View(alertModel);
        }

        // POST: Alerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alertModel = await _context.Alerts.FindAsync(id);
            _context.Alerts.Remove(alertModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlertModelExists(int id)
        {
            return _context.Alerts.Any(e => e.Id == id);
        }
    }
}
