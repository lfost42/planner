using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Models;

namespace Planner.Services.Interfaces
{
    public interface ITicketService
    {
        // CRUD Methods
        public Task AddNewTicketAsync(Ticket ticket);
        public Task UpdateTicketAsync(Ticket ticket);
        public Task<Ticket> GetTicketByIdAsync(int ticketId);
        public Task ArchiveTicketAsync(Ticket ticket);

        public Task AssignTicketAsync(int ticketId, string userId);

        // "GET" Methods
        public Task<List<Ticket>> GetArchivedTicketsAsync(int TeamId);
        public Task<List<Ticket>> GetAllTicketsByTeamAsync(int TeamId);
        public Task<List<Ticket>> GetAllTicketsByPriorityAsync(int TeamId, string priorityName);
        public Task<List<Ticket>> GetAllTicketsByStatusAsync(int TeamId, string statusName);
        public Task<List<Ticket>> GetAllTicketsByTypeAsync(int TeamId, string typeName);
        public Task<AppUser> GetTicketDeveloperAsync(int ticketId, int TeamId); // **** UPDATED **** added "int TeamId" 
        public Task<List<Ticket>> GetTicketsByRoleAsync(string role, string userId, int TeamId);
        public Task<List<Ticket>> GetTicketsByUserIdAsync(string userId, int TeamId);
        public Task<List<Ticket>> GetProjectTicketsByRoleAsync(string role, string userId, int projectId, int TeamId);
        public Task<List<Ticket>> GetProjectTicketsByStatusAsync(string statusName, int TeamId, int projectId);
        public Task<List<Ticket>> GetProjectTicketsByPriorityAsync(string priorityName, int TeamId, int projectId);
        public Task<List<Ticket>> GetProjectTicketsByTypeAsync(string typeName, int TeamId, int projectId);

        // "Lookup" Methods 
        public Task<int?> LookupTicketPriorityIdAsync(string priorityName);
        public Task<int?> LookupTicketStatusIdAsync(string statusName);
        public Task<int?> LookupTicketTypeIdAsync(string typeName);
    }
}
