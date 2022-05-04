using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.Data.Models
{
    public class UserModel : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string FullName => $"{FirstName} {LastName}";

        //Navigation
        [Display(Name = "Projects")]
        public virtual ICollection<ProjectModel> ProjectModels { get; set; } = new HashSet<ProjectModel>();
        [Display(Name = "Requirements")]
        public virtual ICollection<RequirementModel> RequirementModels { get; set; } = new HashSet<RequirementModel>();
        [Display(Name = "Tasks")]

        public virtual ICollection<TaskModel> TaskModels { get; set; } = new HashSet<TaskModel>();
        [Display(Name = "Attachments")]
        public virtual ICollection<FileModel> FileModels { get; set; } = new HashSet<FileModel>();
        [Display(Name = "Tickets")]
        public virtual ICollection<TicketModel> TicketModels { get; set; } = new HashSet<TicketModel>();
        [Display(Name = "Changes")]
        public virtual ICollection<ChangeModel> ChangeModels { get; set; } = new HashSet<ChangeModel>();
        [Display(Name = "Lists")]
        public virtual ICollection<ListModel> ListModels { get; set; } = new HashSet<ListModel>();

    }
}
