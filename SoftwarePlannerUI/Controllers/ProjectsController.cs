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
    public class ProjectsController : Controller
    {
        private readonly PlannerContext _context;

        public ProjectsController(PlannerContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var plannerContext = _context.Projects.Include(p => p.CreatorModel).Include(p => p.Photo).Include(p => p.PriorityModel).Include(p => p.StatusModel).Include(p => p.TeamModel);
            return View(await plannerContext.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectModel = await _context.Projects
                .Include(p => p.CreatorModel)
                .Include(p => p.Photo)
                .Include(p => p.PriorityModel)
                .Include(p => p.StatusModel)
                .Include(p => p.TeamModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectModel == null)
            {
                return NotFound();
            }

            return View(projectModel);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id");
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id");
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id");
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id");
            ViewData["TeamModelId"] = new SelectList(_context.Teams, "Id", "Id");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectName,Description,CreatorModelId,DateCreated,DueDate,ClosedDate,PriorityModelId,StatusModelId,Archived,AssignedUserlId,TeamModelId,PhotoId")] ProjectModel projectModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", projectModel.CreatorModelId);
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id", projectModel.PhotoId);
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id", projectModel.PriorityModelId);
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id", projectModel.StatusModelId);
            ViewData["TeamModelId"] = new SelectList(_context.Teams, "Id", "Id", projectModel.TeamModelId);
            return View(projectModel);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectModel = await _context.Projects.FindAsync(id);
            if (projectModel == null)
            {
                return NotFound();
            }
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", projectModel.CreatorModelId);
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id", projectModel.PhotoId);
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id", projectModel.PriorityModelId);
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id", projectModel.StatusModelId);
            ViewData["TeamModelId"] = new SelectList(_context.Teams, "Id", "Id", projectModel.TeamModelId);
            return View(projectModel);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectName,Description,CreatorModelId,DateCreated,DueDate,ClosedDate,PriorityModelId,StatusModelId,Archived,AssignedUserlId,TeamModelId,PhotoId")] ProjectModel projectModel)
        {
            if (id != projectModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectModelExists(projectModel.Id))
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
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", projectModel.CreatorModelId);
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id", projectModel.PhotoId);
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id", projectModel.PriorityModelId);
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id", projectModel.StatusModelId);
            ViewData["TeamModelId"] = new SelectList(_context.Teams, "Id", "Id", projectModel.TeamModelId);
            return View(projectModel);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectModel = await _context.Projects
                .Include(p => p.CreatorModel)
                .Include(p => p.Photo)
                .Include(p => p.PriorityModel)
                .Include(p => p.StatusModel)
                .Include(p => p.TeamModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectModel == null)
            {
                return NotFound();
            }

            return View(projectModel);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectModel = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(projectModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectModelExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
