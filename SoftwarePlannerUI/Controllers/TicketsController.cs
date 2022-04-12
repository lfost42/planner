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
    public class TicketsController : Controller
    {
        private readonly PlannerContext _context;

        public TicketsController(PlannerContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var plannerContext = _context.Tickets.Include(t => t.CreatorModel).Include(t => t.PriorityModel).Include(t => t.ProjectModel).Include(t => t.StatusModel).Include(t => t.TaskModel).Include(t => t.TeamModel).Include(t => t.TypeModel);
            return View(await plannerContext.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketModel = await _context.Tickets
                .Include(t => t.CreatorModel)
                .Include(t => t.PriorityModel)
                .Include(t => t.ProjectModel)
                .Include(t => t.StatusModel)
                .Include(t => t.TaskModel)
                .Include(t => t.TeamModel)
                .Include(t => t.TypeModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketModel == null)
            {
                return NotFound();
            }

            return View(ticketModel);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id");
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id");
            ViewData["ProjectModelId"] = new SelectList(_context.Projects, "Id", "AssignedUserlId");
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id");
            ViewData["TaskModelId"] = new SelectList(_context.Tasks, "Id", "AssignedUserlId");
            ViewData["TeamModelId"] = new SelectList(_context.Teams, "Id", "Id");
            ViewData["TypeModelId"] = new SelectList(_context.Types, "Id", "Id");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TicketName,TicketDescription,DateCreated,DueDate,ClosedDate,CreatorModelId,ProjectModelId,TaskModelId,TypeModelId,PriorityModelId,StatusModelId,Archived,AssignedUserlId,TeamModelId")] TicketModel ticketModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", ticketModel.CreatorModelId);
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id", ticketModel.PriorityModelId);
            ViewData["ProjectModelId"] = new SelectList(_context.Projects, "Id", "AssignedUserlId", ticketModel.ProjectModelId);
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id", ticketModel.StatusModelId);
            ViewData["TaskModelId"] = new SelectList(_context.Tasks, "Id", "AssignedUserlId", ticketModel.TaskModelId);
            ViewData["TeamModelId"] = new SelectList(_context.Teams, "Id", "Id", ticketModel.TeamModelId);
            ViewData["TypeModelId"] = new SelectList(_context.Types, "Id", "Id", ticketModel.TypeModelId);
            return View(ticketModel);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketModel = await _context.Tickets.FindAsync(id);
            if (ticketModel == null)
            {
                return NotFound();
            }
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", ticketModel.CreatorModelId);
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id", ticketModel.PriorityModelId);
            ViewData["ProjectModelId"] = new SelectList(_context.Projects, "Id", "AssignedUserlId", ticketModel.ProjectModelId);
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id", ticketModel.StatusModelId);
            ViewData["TaskModelId"] = new SelectList(_context.Tasks, "Id", "AssignedUserlId", ticketModel.TaskModelId);
            ViewData["TeamModelId"] = new SelectList(_context.Teams, "Id", "Id", ticketModel.TeamModelId);
            ViewData["TypeModelId"] = new SelectList(_context.Types, "Id", "Id", ticketModel.TypeModelId);
            return View(ticketModel);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TicketName,TicketDescription,DateCreated,DueDate,ClosedDate,CreatorModelId,ProjectModelId,TaskModelId,TypeModelId,PriorityModelId,StatusModelId,Archived,AssignedUserlId,TeamModelId")] TicketModel ticketModel)
        {
            if (id != ticketModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketModelExists(ticketModel.Id))
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
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", ticketModel.CreatorModelId);
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id", ticketModel.PriorityModelId);
            ViewData["ProjectModelId"] = new SelectList(_context.Projects, "Id", "AssignedUserlId", ticketModel.ProjectModelId);
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id", ticketModel.StatusModelId);
            ViewData["TaskModelId"] = new SelectList(_context.Tasks, "Id", "AssignedUserlId", ticketModel.TaskModelId);
            ViewData["TeamModelId"] = new SelectList(_context.Teams, "Id", "Id", ticketModel.TeamModelId);
            ViewData["TypeModelId"] = new SelectList(_context.Types, "Id", "Id", ticketModel.TypeModelId);
            return View(ticketModel);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketModel = await _context.Tickets
                .Include(t => t.CreatorModel)
                .Include(t => t.PriorityModel)
                .Include(t => t.ProjectModel)
                .Include(t => t.StatusModel)
                .Include(t => t.TaskModel)
                .Include(t => t.TeamModel)
                .Include(t => t.TypeModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketModel == null)
            {
                return NotFound();
            }

            return View(ticketModel);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketModel = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(ticketModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketModelExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
