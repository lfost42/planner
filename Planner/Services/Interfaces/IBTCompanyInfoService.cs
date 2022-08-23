using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Models;

namespace Planner.Services.Interfaces
{
    public interface ITeamInfoService
    {
        public Task<Team> GetTeamInfoByIdAsync(int? TeamId);
        public Task<List<AppUser>> GetAllMembersAsync(int TeamId);
        public Task<List<Project>> GetAllProjectsAsync(int TeamId);
        public Task<List<Ticket>> GetAllTicketsAsync(int TeamId);

    }
}
