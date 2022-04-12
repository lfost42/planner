using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoftwarePlannerUI.Data;
using SoftwarePlannerUI.Models;

namespace SoftwarePlannerUI.Controllers
{
    public class RequirementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequirementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Requirement
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Requirements.Include(r => r.Creator).Include(r => r.Photo).Include(r => r.PriorityModel).Include(r => r.StatusModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Requirement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirementModel = await _context.Requirements
                .Include(r => r.Creator)
                .Include(r => r.Photo)
                .Include(r => r.PriorityModel)
                .Include(r => r.StatusModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requirementModel == null)
            {
                return NotFound();
            }

            return View(requirementModel);
        }

        // GET: Requirement/Create
        public IActionResult Create()
        {
            ViewData["CreatorId"] = new SelectList(_context.Set<CreatorModel>(), "Id", "Id");
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id");
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id");
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id");
            return View();
        }

        // POST: Requirement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RequirementName,Description,CreatorId,DateCreated,DueDate,ClosedDate,PriorityModelId,StatusModelId,Archived,AssignedUserlId,TeamModelId,PhotoId")] RequirementModel requirementModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requirementModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorId"] = new SelectList(_context.Set<CreatorModel>(), "Id", "Id", requirementModel.CreatorId);
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id", requirementModel.PhotoId);
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id", requirementModel.PriorityModelId);
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id", requirementModel.StatusModelId);
            return View(requirementModel);
        }

        // GET: Requirement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirementModel = await _context.Requirements.FindAsync(id);
            if (requirementModel == null)
            {
                return NotFound();
            }
            ViewData["CreatorId"] = new SelectList(_context.Set<CreatorModel>(), "Id", "Id", requirementModel.CreatorId);
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id", requirementModel.PhotoId);
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id", requirementModel.PriorityModelId);
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id", requirementModel.StatusModelId);
            return View(requirementModel);
        }

        // POST: Requirement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RequirementName,Description,CreatorId,DateCreated,DueDate,ClosedDate,PriorityModelId,StatusModelId,Archived,AssignedUserlId,TeamModelId,PhotoId")] RequirementModel requirementModel)
        {
            if (id != requirementModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requirementModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequirementModelExists(requirementModel.Id))
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
            ViewData["CreatorId"] = new SelectList(_context.Set<CreatorModel>(), "Id", "Id", requirementModel.CreatorId);
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id", requirementModel.PhotoId);
            ViewData["PriorityModelId"] = new SelectList(_context.Priorities, "Id", "Id", requirementModel.PriorityModelId);
            ViewData["StatusModelId"] = new SelectList(_context.Status, "Id", "Id", requirementModel.StatusModelId);
            return View(requirementModel);
        }

        // GET: Requirement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirementModel = await _context.Requirements
                .Include(r => r.Creator)
                .Include(r => r.Photo)
                .Include(r => r.PriorityModel)
                .Include(r => r.StatusModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requirementModel == null)
            {
                return NotFound();
            }

            return View(requirementModel);
        }

        // POST: Requirement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requirementModel = await _context.Requirements.FindAsync(id);
            _context.Requirements.Remove(requirementModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequirementModelExists(int id)
        {
            return _context.Requirements.Any(e => e.Id == id);
        }
    }
}
