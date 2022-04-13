using SoftwarePlannerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwarePlannerUI.Services.Interfaces
{
    public interface ITeamsService
    {
        public Task<TeamModel> GetTeamInfoByIdAsync(int? teamId);

        public Task<List<ProjectModel>> GetAllProjectsAsync(int teamId);

        public Task<List<TicketModel>> GetAllTicketsAsync(int teamId);
    }
}
