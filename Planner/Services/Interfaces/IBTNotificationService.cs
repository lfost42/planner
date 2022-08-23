using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Models;

namespace Planner.Services.Interfaces
{
    public interface INotificationService
    {
        public Task AddNotificationAsync(Notification notification);
        public Task<List<Notification>> GetRecievedNotificationsAsync(string userId);
        public Task<List<Notification>> GetSentNotificationsAsync(string userId);
        public Task SendEmailNotificationsByRoleAsync(Notification notification, int TeamId, string role);
        public Task SendMembersEmailNotificationAsync(Notification notification, List<AppUser> members);
        public Task<bool> SendEmailNotificationAsync(Notification notification, string emailSubject);

    }
}
