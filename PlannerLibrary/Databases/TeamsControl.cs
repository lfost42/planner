using Microsoft.EntityFrameworkCore;
using PlannerLibrary.Data;
using PlannerLibrary.Databases.Interfaces;
using PlannerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerLibrary.Databases
{
    public class TeamsControl : ITeamsControl
    {

        private readonly ApplicationDbContext _context;

        public TeamsControl(ApplicationDbContext context)
        {
            _context = context;

        }


        public async Task<TeamModel> GetTeamInfoByIdAsync(int? teamId)
        {
            TeamModel result = new();

            if (teamId != null)
            {
                result = await _context.Teams
                    .Include(t => t.Projects)
                    .Include(t => t.Projects).ThenInclude(p => p.Requirements)
                    .Include(t => t.Projects).ThenInclude(p => p.Requirements).ThenInclude(p => p.Tasks)
                    .Include(t => t.Notes)
                    .Include(t => t.Tickets)
                    .Include(t => t.Tickets).ThenInclude(t => t.Notes)
                    .FirstOrDefaultAsync(t => t.Id == teamId);
            }

            return result;

        }

        public async Task<List<ProjectModel>> GetAllTeamProjectsAsync(int teamId)
        {
            List<ProjectModel> projects = new();

            projects = await _context.Projects.Where(p => p.Teams.Equals(teamId) && p.Archived == false)
                        .Include(p => p.Requirements)
                        .Include(p => p.Requirements).ThenInclude(p => p.Tasks)
                        .Include(p => p.Photo)
                        .Include(p => p.PriorityModel)
                        .Include(p => p.StatusModel)
                        .Include(p => p.Notes)
                        .Include(p => p.Tickets)
                        .Include(p => p.Tickets).ThenInclude(t => t.Notes)
                        .ToListAsync();
            return projects;

        }

        public async Task<List<TicketModel>> GetAllTeamTicketsAsync(int teamId)
        {
            List<TicketModel> result = new();
            List<ProjectModel> projects = new();
            projects = await GetAllTeamProjectsAsync(teamId);
            return projects.SelectMany(p => p.Tickets).ToList();

        }

        public async Task<List<NoteModel>> GetAllTeamNotesAsync(int teamId)
        {
            List<NoteModel> result = new();
            List<ProjectModel> projects = new();
            projects = await GetAllTeamProjectsAsync(teamId);
            return projects.SelectMany(p => p.Notes).ToList();

        }

    }
}


