using Microsoft.AspNetCore.Identity.UI.Services;
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
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly IBTRolesService _rolesService;

        // Constructor
        public NotificationService(ApplicationDbContext context,
                                     IEmailSender emailSender,
                                     IBTRolesService rolesService)
        {
            _context = context;
            _emailSender = emailSender;
            _rolesService = rolesService;
        }

        public async Task AddNotificationAsync(Notification notification)
        {
            try
            {
                await _context.AddAsync(notification);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Notification>> GetRecievedNotificationsAsync(string userId)
        {
            try
            {
                List<Notification> notifications = await _context.Notifications
                                                                   .Include(n => n.Recipient)
                                                                   .Include(n => n.Sender)
                                                                   .Include(n => n.Ticket)
                                                                        .ThenInclude(t => t.Project)
                                                                   .Where(n => n.RecipientId == userId).ToListAsync();

                return notifications;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Notification>> GetSentNotificationsAsync(string userId)
        {
            try
            {
                List<Notification> notifications = await _context.Notifications
                                                                   .Include(n => n.Recipient)
                                                                   .Include(n => n.Sender)
                                                                   .Include(n => n.Ticket)
                                                                        .ThenInclude(t => t.Project)
                                                                   .Where(n => n.SenderId == userId).ToListAsync();

                return notifications;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> SendEmailNotificationAsync(Notification notification, string emailSubject)
        {
            AppUser AppUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == notification.RecipientId);
           
            if (AppUser != null)
            {
                string AppUserEmail = AppUser.Email;
                string message = notification.Message;

                // Send Email
                try
                {
                    await _emailSender.SendEmailAsync(AppUserEmail, emailSubject, message);
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            
            }
            else
            {
                return false;
            }
            
        }

        public async Task SendEmailNotificationsByRoleAsync(Notification notification, int TeamId, string role)
        {
            try
            {
                List<AppUser> members = await _rolesService.GetUsersInRolesAsync(role, TeamId);

                foreach (AppUser AppUser in members)
                {
                    notification.RecipientId = AppUser.Id;
                    await SendEmailNotificationAsync(notification, notification.Title);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SendMembersEmailNotificationAsync(Notification notification, List<AppUser> members)
        {
            try
            {
                foreach (AppUser AppUser in members)
                {
                    notification.RecipientId = AppUser.Id;
                    await SendEmailNotificationAsync(notification, notification.Title);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
