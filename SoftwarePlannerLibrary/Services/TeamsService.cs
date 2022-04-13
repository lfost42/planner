using Microsoft.EntityFrameworkCore;
using SoftwarePlannerLibrary.DataAccess;
using SoftwarePlannerLibrary.Models;
using SoftwarePlannerUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwarePlannerUI.Services
{
    public class TeamsService : ITeamsService
    {

        private readonly PlannerContext _context;

        public TeamsService(PlannerContext context)
        {
            _context = context;

        }

        public async Task<List<ProjectModel>> GetAllProjectsAsync(int teamId)
        {
            List<ProjectModel> projects = new();
            projects = await _context.Projects.Where(p => p.TeamModelId == teamId)
                        .Include(p => p.Changes)
                        .Include(p => p.Tickets).ThenInclude(p => p.CreatorModel)
                        .Include(p => p.Tickets).ThenInclude(p => p.Notes)
                        .Include(p => p.Tickets).ThenInclude(p => p.TypeModel)
                        .Include(p => p.Tickets).ThenInclude(p => p.PriorityModel)
                        .Include(p => p.Tickets).ThenInclude(p => p.StatusModel)
                        .ToListAsync();
            return projects;

        }

        public async Task<List<TicketModel>> GetAllTicketsAsync(int teamId)
        {

            List<TicketModel> result = new();
            List<ProjectModel> projects = new();
            projects = await GetAllProjectsAsync(teamId);
            return projects.SelectMany(p => p.Tickets).ToList();

        }

        public async Task<TeamModel> GetTeamInfoByIdAsync(int? teamId)
        {
            TeamModel result = new();

            if (teamId != null)
            {
                result = await _context.Teams
                    .Include(t => t.Projects)
                    .Include(t => t.Requirements)
                    .Include(t => t.Tasks)
                    .Include(t => t.Notes)
                    .Include(t => t.Tickets).ThenInclude(t => t.Notes)
                    .FirstOrDefaultAsync(t => t.Id == teamId);
            }
            
            return result;

        }
    }
}
