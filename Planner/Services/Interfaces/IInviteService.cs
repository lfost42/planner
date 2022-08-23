using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Models;

namespace Planner.Services.Interfaces
{
    public interface IInviteService
    {
        public Task<bool> AcceptInviteAsync(Guid? token, string userId, int TeamId);
        public Task AddNewInviteAsync(Invite invite);
        public Task<bool> AnyInviteAsync(Guid token, string email, int TeamId);
        public Task<Invite> GetInviteAsync(int inviteId, int TeamId);
        public Task<Invite> GetInviteASync(Guid token, string email, int TeamId);
        public Task<bool> ValidateInviteCodeAsync(Guid? token);
    }
}
