using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwarePlannerLibrary.Models
{
    public class UserModel : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string FullName => $"{FirstName} {LastName}";

        //Navigation
        //[Display(Name = "Projects")]
        //public virtual ICollection<ProjectModel> ProjectModels { get; set; } = new HashSet<ProjectModel>();

        //[Display(Name = "Tasks")]
        //public virtual ICollection<TaskModel> TaskModels { get; set; } = new HashSet<TaskModel>();

        //[Display(Name = "Teams")]
        //public virtual ICollection<TeamModel> TeamModels { get; set; } = new HashSet<TeamModel>();

        //[Display(Name = "Attachments")]
        //public virtual ICollection<FileModel> FileModels { get; set; } = new HashSet<FileModel>();
        //[Display(Name = "Tickets")]
        //public virtual ICollection<TicketModel> TicketModels { get; set; } = new HashSet<TicketModel>();
        //[Display(Name = "Changes")]
        //public virtual ICollection<ChangeModel> ChangeModels { get; set; } = new HashSet<ChangeModel>();

    }
}
