using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Models;

namespace Planner.Services.Interfaces
{
    public interface ITicketHistoryService
    {
        Task AddHistoryAsync(Ticket oldTicket, Ticket newTicket, string userId);
        Task<List<TicketHistory>> GetProjectChangesAsync(int projectId, int TeamId);
        Task<List<TicketHistory>> GetTeamTicketsHistoriesAsync(int TeamId);
    }
}
