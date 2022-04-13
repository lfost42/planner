using Microsoft.EntityFrameworkCore;
using SoftwarePlannerLibrary.DataAccess;
using SoftwarePlannerLibrary.Datases.Interfaces;
using SoftwarePlannerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwarePlannerLibrary.Datases
{
    public class TeamsControl
    {

        private readonly PlannerContext _context;

        public TeamsControl(PlannerContext context)
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
                    .Include(t => t.Requirements)
                    .Include(t => t.Tasks)
                    .Include(t => t.Notes)
                    .Include(t => t.Tickets).ThenInclude(t => t.Notes)
                    .FirstOrDefaultAsync(t => t.Id == teamId);
            }

            return result;

        }


        //.Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
        //    .ThenInclude(t => t.CreatorModel)
        //.Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
        //    .ThenInclude(t => t.TypeModel)
        //.Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
        //    .ThenInclude(t => t.PriorityModel)
        //.Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
        //    .ThenInclude(t => t.StatusModel)
        //.Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
        //    .ThenInclude(t => t.Notes)
        //.Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
        //    .ThenInclude(t => t.Notes).ThenInclude(n => n.StatusModel)
        //.FirstOrDefaultAsync(u => u.Id == userId)).ProjectModels.ToList();

        //public async Task<List<ProjectModel>> GetAllTeamProjectsAsync(int teamId)
        //{
        //    List<ProjectModel> projects = new();

            //Projects have a list of teams. Need to get many-to-many relationship working. 
            //projects = await _context.Projects.Where(p => p.Teams.FirstOrDefault(t => t.Id == teamId);
            //            .Include(p => p.Users)
            //            .Include(p => p.Changes)
            //            .Include(p => p.Tickets).ThenInclude(p => p.CreatorModel)
            //            .Include(p => p.Tickets).ThenInclude(p => p.Notes)
            //            .Include(p => p.Tickets).ThenInclude(p => p.TypeModel)
            //            .Include(p => p.Tickets).ThenInclude(p => p.PriorityModel)
            //            .Include(p => p.Tickets).ThenInclude(p => p.StatusModel)
            //            .ToListAsync();
        //    return projects;

        //}

        //public async Task<List<TicketModel>> GetAllTeamTicketsAsync(int teamId)
        //{
        //    List<TicketModel> result = new();
        //    List<ProjectModel> projects = new();
        //    projects = await GetAllTeamProjectsAsync(teamId);
        //    return projects.SelectMany(p => p.Tickets).ToList();

        //}

    }
}


