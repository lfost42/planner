using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Data;
using Planner.Models;
using Planner.Services.Interfaces;

namespace Planner.Services
{
    public class TeamInfoService : ITeamInfoService
    {
        private readonly ApplicationDbContext _context;
        public TeamInfoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<AppUser>> GetAllMembersAsync(int TeamId)
        {
            List<AppUser> result = new();
            result = await _context.Users.Where(u => u.TeamId == TeamId).ToListAsync();
            return result;
        }

        public async Task<List<Project>> GetAllProjectsAsync(int TeamId)
        {
            List<Project> result = new();
            result = await _context.Projects.Where(p => p.TeamId == TeamId)
                                            .Include(p=>p.Members)
                                            .Include(p=>p.Tickets)
                                                .ThenInclude(t=>t.Notes)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.Attachments)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.History)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.Notifications)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.DeveloperUser)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.OwnerUser)
                                            .Include(p=>p.Tickets)
                                                .ThenInclude(t=>t.TicketStatus)
                                            .Include(p=>p.Tickets)
                                                .ThenInclude(t=>t.TicketPriority)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.TicketType)
                                            .Include(p=>p.Priority)
                                            .ToListAsync();
            return result;
        }

        public async Task<List<Ticket>> GetAllTicketsAsync(int TeamId)
        {
            List<Ticket> result = new();
            List<Project> projects = new();

            projects = await GetAllProjectsAsync(TeamId);
            result = projects.SelectMany(p => p.Tickets).ToList();
            return result;
        }

        public async Task<Team> GetTeamInfoByIdAsync(int? TeamId)
        {
            Team result = new();
            if(TeamId != null)
            {
                result = await _context.Teams
                    .Include(c=>c.Members)
                    .Include(c=>c.Projects)
                    .Include(c=>c.Invites)
                    .FirstOrDefaultAsync(c => c.Id == TeamId);
                return result;

            }
            return result;
        }
    }
}
