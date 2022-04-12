using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using SoftwarePlannerUI.Models;

namespace SoftwarePlannerUI.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AlertModel> Alerts { get; set; }
        public DbSet<ChangeModel> Changes { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<NoteModel> Notes { get; set; }
        public DbSet<PriorityModel> Priorities { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<RequirementModel> Requirements { get; set; }
        public DbSet<StatusModel> Status { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<TeamModel> Teams { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }
        public DbSet<TypeModel> Types { get; set; }


    }
}
