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

        public int FileId { get; set; }
        public FileModel UserPhoto { get; set; }


        public virtual ICollection<ProjectModel> Projects { get; set; } = new HashSet<ProjectModel>();

        public virtual ICollection<TaskModel> Tasks { get; set; } = new HashSet<TaskModel>();

        public virtual ICollection<TicketModel> Tickets { get; set; } = new HashSet<TicketModel>();
        public virtual ICollection<FileModel> Attachments { get; set; } = new HashSet<FileModel>();

    }
}
