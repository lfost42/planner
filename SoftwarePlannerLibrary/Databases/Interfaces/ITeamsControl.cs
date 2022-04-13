using System.Collections.Generic;
using System.Threading.Tasks;
using SoftwarePlannerLibrary.Models;

namespace SoftwarePlannerLibrary.Datases.Interfaces
{
    public interface ITeamsControl
    {
        Task<List<ProjectModel>> GetAllProjectsAsync(int teamId);
        Task<List<TicketModel>> GetAllTicketsAsync(int teamId);
        Task<TeamModel> GetTeamInfoByIdAsync(int? teamId);
    }
}