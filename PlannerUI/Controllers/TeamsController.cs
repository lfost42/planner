using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlannerLibrary.Data;
using PlannerLibrary.Models;

namespace PlannerUI.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            var plannerContext = _context.Teams.Include(t => t.CreatorModel).Include(t => t.Photo);
            return View(await plannerContext.ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamModel = await _context.Teams
                .Include(t => t.CreatorModel)
                .Include(t => t.Photo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamModel == null)
            {
                return NotFound();
            }

            return View(teamModel);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id");
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id");
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamName,CreatorModelId,PhotoId")] TeamModel teamModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teamModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", teamModel.CreatorModelId);
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id", teamModel.PhotoId);
            return View(teamModel);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamModel = await _context.Teams.FindAsync(id);
            if (teamModel == null)
            {
                return NotFound();
            }
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", teamModel.CreatorModelId);
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id", teamModel.PhotoId);
            return View(teamModel);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamName,CreatorModelId,PhotoId")] TeamModel teamModel)
        {
            if (id != teamModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamModelExists(teamModel.Id))
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
            ViewData["CreatorModelId"] = new SelectList(_context.Creators, "Id", "Id", teamModel.CreatorModelId);
            ViewData["PhotoId"] = new SelectList(_context.Files, "Id", "Id", teamModel.PhotoId);
            return View(teamModel);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamModel = await _context.Teams
                .Include(t => t.CreatorModel)
                .Include(t => t.Photo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamModel == null)
            {
                return NotFound();
            }

            return View(teamModel);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamModel = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(teamModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamModelExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
