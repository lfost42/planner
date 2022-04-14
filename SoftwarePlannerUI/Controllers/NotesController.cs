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
    public class NotesController : Controller
    {
        private readonly PlannerContext _context;

        public NotesController(PlannerContext context)
        {
            _context = context;
        }

        // GET: Notes
        public async Task<IActionResult> Index()
        {
            var plannerContext = _context.Notes.Include(n => n.CreatorModel).Include(n => n.PriorityModel).Include(n => n.ProjectModel).Include(n => n.RequirementModel).Include(n => n.StatusModel).Include(n => n.TaskModel).Include(n => n.TicketModel).Include(n => n.TypeModel);
            return View(await plannerContext.ToListAsync());
        }

        // GET: Notes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noteModel = await _context.Notes
                .Include(n => n.CreatorModel)
                .Include(n => n.PriorityModel)
                .Include(n => n.ProjectModel)
                .Include(n => n.RequirementModel)
                .Include(n => n.StatusModel)
                .Include(n => n.TaskModel)
                .Include(n => n.TicketModel)
                .Include(n => n.TypeModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noteModel == null)
            {
                return NotFound();
            }

            return View(noteModel);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id");
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id");
            ViewData["ProjectModelId"] = new SelectList(_context.Projects, "Id", "Description");
            ViewData["RequirementModelId"] = new SelectList(_context.Requirements, "Id", "AssignedUserlId");
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id");
            ViewData["TaskModelId"] = new SelectList(_context.Tasks, "Id", "AssignedUserlId");
            ViewData["TicketModelId"] = new SelectList(_context.Tickets, "Id", "AssignedUserlId");
            ViewData["TypeModelId"] = new SelectList(_context.Types, "Id", "Id");
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,DateCreated,CreatorModelId,ProjectModelId,RequirementModelId,TaskModelId,TicketModelId,TypeModelId,PriorityModelId,StatusModelId,Archived,AssignedUserlId,TeamModelId")] NoteModel noteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", noteModel.CreatorModelId);
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id", noteModel.PriorityModelId);
            ViewData["ProjectModelId"] = new SelectList(_context.Projects, "Id", "Description", noteModel.ProjectModelId);
            ViewData["RequirementModelId"] = new SelectList(_context.Requirements, "Id", "AssignedUserlId", noteModel.RequirementModelId);
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id", noteModel.StatusModelId);
            ViewData["TaskModelId"] = new SelectList(_context.Tasks, "Id", "AssignedUserlId", noteModel.TaskModelId);
            ViewData["TicketModelId"] = new SelectList(_context.Tickets, "Id", "AssignedUserlId", noteModel.TicketModelId);
            ViewData["TypeModelId"] = new SelectList(_context.Types, "Id", "Id", noteModel.TypeModelId);
            return View(noteModel);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noteModel = await _context.Notes.FindAsync(id);
            if (noteModel == null)
            {
                return NotFound();
            }
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", noteModel.CreatorModelId);
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id", noteModel.PriorityModelId);
            ViewData["ProjectModelId"] = new SelectList(_context.Projects, "Id", "Description", noteModel.ProjectModelId);
            ViewData["RequirementModelId"] = new SelectList(_context.Requirements, "Id", "AssignedUserlId", noteModel.RequirementModelId);
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id", noteModel.StatusModelId);
            ViewData["TaskModelId"] = new SelectList(_context.Tasks, "Id", "AssignedUserlId", noteModel.TaskModelId);
            ViewData["TicketModelId"] = new SelectList(_context.Tickets, "Id", "AssignedUserlId", noteModel.TicketModelId);
            ViewData["TypeModelId"] = new SelectList(_context.Types, "Id", "Id", noteModel.TypeModelId);
            return View(noteModel);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,DateCreated,CreatorModelId,ProjectModelId,RequirementModelId,TaskModelId,TicketModelId,TypeModelId,PriorityModelId,StatusModelId,Archived,AssignedUserlId,TeamModelId")] NoteModel noteModel)
        {
            if (id != noteModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteModelExists(noteModel.Id))
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
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", noteModel.CreatorModelId);
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id", noteModel.PriorityModelId);
            ViewData["ProjectModelId"] = new SelectList(_context.Projects, "Id", "Description", noteModel.ProjectModelId);
            ViewData["RequirementModelId"] = new SelectList(_context.Requirements, "Id", "AssignedUserlId", noteModel.RequirementModelId);
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id", noteModel.StatusModelId);
            ViewData["TaskModelId"] = new SelectList(_context.Tasks, "Id", "AssignedUserlId", noteModel.TaskModelId);
            ViewData["TicketModelId"] = new SelectList(_context.Tickets, "Id", "AssignedUserlId", noteModel.TicketModelId);
            ViewData["TypeModelId"] = new SelectList(_context.Types, "Id", "Id", noteModel.TypeModelId);
            return View(noteModel);
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noteModel = await _context.Notes
                .Include(n => n.CreatorModel)
                .Include(n => n.PriorityModel)
                .Include(n => n.ProjectModel)
                .Include(n => n.RequirementModel)
                .Include(n => n.StatusModel)
                .Include(n => n.TaskModel)
                .Include(n => n.TicketModel)
                .Include(n => n.TypeModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noteModel == null)
            {
                return NotFound();
            }

            return View(noteModel);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noteModel = await _context.Notes.FindAsync(id);
            _context.Notes.Remove(noteModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteModelExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }
    }
}
