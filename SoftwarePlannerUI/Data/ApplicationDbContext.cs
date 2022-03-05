using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SoftwarePlannerLibrary.Models;

namespace SoftwarePlannerUI.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CreatorModel> Creators { get; set; }

        public DbSet<FileModel> Attachments { get; set; }
        public DbSet<HistoryModel> Changes { get; set; }
        public DbSet<NoteModel> Notes { get; set; }
        public DbSet<NotificationModel> Notifications { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }

        public DbSet<RequirementModel> Requirements { get; set; }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<TeamModel> Teams { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }

    }
}
