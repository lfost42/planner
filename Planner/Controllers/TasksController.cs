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
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var plannerContext = _context.Tasks.Include(t => t.Creator).Include(t => t.Photo).Include(t => t.PriorityModel).Include(t => t.StatusModel);
            return View(await plannerContext.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = await _context.Tasks
                .Include(t => t.Creator)
                .Include(t => t.Photo)
                .Include(t => t.PriorityModel)
                .Include(t => t.StatusModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return View(taskModel);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["CreatorId"] = new SelectList(_context.Creators, "Id", "Id");
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id");
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id");
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskName,Description,CreatorId,DateCreated,DueDate,ClosedDate,PriorityModelId,StatusModelId,Archived,AssignedUserlId,TeamModelId,PhotoId")] TaskModel taskModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorId"] = new SelectList(_context.Creators, "Id", "Id", taskModel.CreatorId);
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id", taskModel.PhotoId);
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id", taskModel.PriorityModelId);
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id", taskModel.StatusModelId);
            return View(taskModel);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = await _context.Tasks.FindAsync(id);
            if (taskModel == null)
            {
                return NotFound();
            }
            ViewData["CreatorId"] = new SelectList(_context.Creators, "Id", "Id", taskModel.CreatorId);
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id", taskModel.PhotoId);
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id", taskModel.PriorityModelId);
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id", taskModel.StatusModelId);
            return View(taskModel);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskName,Description,CreatorId,DateCreated,DueDate,ClosedDate,PriorityModelId,StatusModelId,Archived,AssignedUserlId,TeamModelId,PhotoId")] TaskModel taskModel)
        {
            if (id != taskModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskModelExists(taskModel.Id))
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
            ViewData["CreatorId"] = new SelectList(_context.Creators, "Id", "Id", taskModel.CreatorId);
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id", taskModel.PhotoId);
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id", taskModel.PriorityModelId);
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id", taskModel.StatusModelId);
            return View(taskModel);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = await _context.Tasks
                .Include(t => t.Creator)
                .Include(t => t.Photo)
                .Include(t => t.PriorityModel)
                .Include(t => t.StatusModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return View(taskModel);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskModel = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(taskModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskModelExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
