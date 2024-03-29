﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Data;
using Planner.Models;
using Planner.Services.Interfaces;

namespace Planner.Services
{
    public class TicketHistoryService : ITicketHistoryService
    {

        private readonly ApplicationDbContext _context;

        public TicketHistoryService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task AddHistoryAsync(Ticket oldTicket, Ticket newTicket, string userId)
        {
            if(oldTicket == null && newTicket != null)
            {
                TicketHistory history = new()
                {
                    TicketId = newTicket.Id,
                    Property = "",
                    OldValue = "",
                    NewValue = "",
                    Created = DateTimeOffset.Now,
                    UserId = userId,
                    Description = "New Ticket Created"

                };

                try
                {
                    await _context.Changes.AddAsync(history);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                if (oldTicket.Title != newTicket.Title)
                {
                    TicketHistory history = new()
                    {
                        TicketId = newTicket.Id,
                        Property = "Title",
                        OldValue = oldTicket.Title,
                        NewValue = newTicket.Title,
                        Created = DateTimeOffset.Now,
                        UserId = userId,
                        Description = $"New Ticket Title: {newTicket.Title}"

                    };

                    await _context.Changes.AddAsync(history);
                }

                if (oldTicket.Description != newTicket.Description)
                {
                    TicketHistory history = new()
                    {
                        TicketId = newTicket.Id,
                        Property = "Description",
                        OldValue = oldTicket.Description,
                        NewValue = newTicket.Description,
                        Created = DateTimeOffset.Now,
                        UserId = userId,
                        Description = $"New Ticket Description: {newTicket.Description}"

                    };

                    await _context.Changes.AddAsync(history);
                }

                if (oldTicket.TicketPriorityId != newTicket.TicketPriorityId)
                {
                    TicketHistory history = new()
                    {
                        TicketId = newTicket.Id,
                        Property = "TicketPriority",
                        OldValue = oldTicket.TicketPriority.Name,
                        NewValue = newTicket.TicketPriority.Name,
                        Created = DateTimeOffset.Now,
                        UserId = userId,
                        Description = $"New Ticket Priority: {newTicket.TicketPriority.Name}"

                    };

                    await _context.Changes.AddAsync(history);
                }
                
                if (oldTicket.TicketStatusId != newTicket.TicketStatusId)
                {
                    TicketHistory history = new()
                    {
                        TicketId = newTicket.Id,
                        Property = "TicketStatus",
                        OldValue = oldTicket.TicketStatus.Name,
                        NewValue = newTicket.TicketStatus.Name,
                        Created = DateTimeOffset.Now,
                        UserId = userId,
                        Description = $"New Ticket Status: {newTicket.TicketStatus.Name}"
                    };

                    await _context.Changes.AddAsync(history);
                }

                if (oldTicket.TicketTypeId != newTicket.TicketTypeId)
                {
                    TicketHistory history = new()
                    {
                        TicketId = newTicket.Id,
                        Property = "TicketType",
                        OldValue = oldTicket.TicketType.Name,
                        NewValue = newTicket.TicketType.Name,
                        Created = DateTimeOffset.Now,
                        UserId = userId,
                        Description = $"New Ticket Type: {newTicket.TicketType.Name}"

                    };

                    await _context.Changes.AddAsync(history);
                }

                if (oldTicket.DeveloperUserId != newTicket.DeveloperUserId)
                {
                    TicketHistory history = new()
                    {
                        TicketId = newTicket.Id,
                        Property = "Title",
                        OldValue = oldTicket.DeveloperUser?.FullName ?? "Not Assigned",
                        NewValue = newTicket.DeveloperUser?.FullName,
                        Created = DateTimeOffset.Now,
                        UserId = userId,
                        Description = $"New Ticket Title: {newTicket.Title}"

                    };

                    await _context.Changes.AddAsync(history);
                }
                
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            
        }

        public async Task<List<TicketHistory>> GetTeamTicketsHistoriesAsync(int TeamId)
        {
            try
            {
                List<Project> projects = (await _context.Teams
                                                         .Include(c => c.Projects)
                                                            .ThenInclude(p => p.Tickets)
                                                                .ThenInclude(t => t.History)
                                                                    .ThenInclude(h => h.User)
                                                         .FirstOrDefaultAsync(c => c.Id == TeamId)).Projects.ToList();
                
                List<Ticket> tickets = projects.SelectMany(p => p.Tickets).ToList();

                List<TicketHistory> Changes = tickets.SelectMany(t => t.History).ToList();
                return Changes;

                                                         
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TicketHistory>> GetProjectChangesAsync(int projectId, int TeamId)
        {
            try
            {
                Project project = await _context.Projects.Where(p => p.TeamId == TeamId)
                                                           .Include(p => p.Tickets)
                                                            .ThenInclude(t => t.History)
                                                                .ThenInclude(h => h.User)
                                                           .FirstOrDefaultAsync(p => p.Id == projectId);

                List<TicketHistory> ticketHistory = project.Tickets.SelectMany(t => t.History).ToList();
                return ticketHistory;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
