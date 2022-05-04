using Planner.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Databases.Interfaces
{
    public interface ITeamsControl
    {
        Task<List<ListModel>> GetAllTeamListsAsync(int teamId);
        Task<List<ProjectModel>> GetAllTeamProjectsAsync(int teamId);
        Task<List<TicketModel>> GetAllTeamTicketsAsync(int teamId);
        Task<TeamModel> GetTeamInfoByIdAsync(int? teamId);
    }
}