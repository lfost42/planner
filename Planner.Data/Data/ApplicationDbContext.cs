using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Planner.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel, IdentityRole, string>
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AlertModel> Alerts { get; set; }
        public DbSet<ChangeModel> Changes { get; set; }
        public DbSet<CreatorModel> Creators { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<ListModel> Lists { get; set; }
        public DbSet<NoteModel> Notes { get; set; }
        public DbSet<PriorityModel> Priorities { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<RequirementModel> Requirements { get; set; }
        public DbSet<StatusModel> Status { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<TeamModel> Teams { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }
        public DbSet<TypeModel> Types { get; set; }
        public DbSet<UserModel> AppUsers { get; set; }
        
    }
}
