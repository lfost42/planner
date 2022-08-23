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
    public class InviteService : IInviteService
    {
        private readonly ApplicationDbContext _context;

        // Dependency Injection
        public InviteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AcceptInviteAsync(Guid? token, string userId, int TeamId)
        {
            Invite invite = await _context.Invites.FirstOrDefaultAsync(i => i.TeamToken == token);
            if (invite == null)
            {
                return false;
            }
            
            try
            {
                invite.IsValid = false;
                invite.InviteeId = userId;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task AddNewInviteAsync(Invite invite)
        {
            try
            {
                await _context.Invites.AddAsync(invite);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> AnyInviteAsync(Guid token, string email, int TeamId)
        {
            try
            {
                bool result = await _context.Invites.Where(i => i.TeamId == TeamId)
                                                    .AnyAsync(i => i.TeamToken == token && i.InviteeEmail == email);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Invite> GetInviteAsync(int inviteId, int TeamId)
        {
            try
            {
                Invite invite = await _context.Invites.Where(i => i.TeamId == TeamId)
                                                        .Include(i => i.Team)
                                                        .Include(i => i.Project)
                                                        .Include(i => i.Invitor)
                                                        .FirstOrDefaultAsync(i => i.Id == inviteId);

                return invite;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Invite> GetInviteASync(Guid token, string email, int TeamId)
        {
            try
            {
                Invite invite = await _context.Invites.Where(i => i.TeamId == TeamId)
                                                        .Include(i => i.Team)
                                                        .Include(i => i.Project)
                                                        .Include(i => i.Invitor)
                                                        .FirstOrDefaultAsync(i => i.TeamToken == token && i.InviteeEmail == email);

                return invite;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> ValidateInviteCodeAsync(Guid? token)
        {
            if (token == null)
            {
                return false;
            }
            bool result = false;

            Invite invite = await _context.Invites.FirstOrDefaultAsync(i => i.TeamToken == token);

            if (invite != null)
            {
                // Determine invite Date
                DateTime inviteDate = invite.InviteDate.DateTime;

                bool validDate = (DateTime.Now - inviteDate).TotalDays <= 7;

                if (validDate)
                {
                    result = invite.IsValid;
                }
            }
            return result;
        }
    }
}
