using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwarePlannerUI.Models
{
    public class UserModel: IdentityUser
    {
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Photo")]
        public int PhotoId { get; set; }

        //Navigation
        public FileModel Photo { get; set; }

        public virtual ICollection<TicketModel> Tickets { get; set; } = new HashSet<TicketModel>();
        public virtual ICollection<NoteModel> Notes { get; set; } = new HashSet<NoteModel>();
        public virtual ICollection<TaskModel> Tasks { get; set; } = new HashSet<TaskModel>();
        public virtual ICollection<RequirementModel> Requirements { get; set; } = new HashSet<RequirementModel>();
        public virtual ICollection<ProjectModel> Projects { get; set; } = new HashSet<ProjectModel>();
        public virtual ICollection<AlertModel> Alerts { get; set; } = new HashSet<AlertModel>();



    }
}
