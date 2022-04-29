using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerLibrary.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        [Display(Name = "Project")]
        public string ProjectName { get; set; }

        [Required, StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }

        [Required, Display(Name = "Creator")]
        public int CreatorModelId { get; set; }

        [Required, Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Required, Display(Name = "Due Date")]
        public DateTimeOffset DueDate { get; set; }

        [Display(Name = "Closed Date")]
        public DateTimeOffset? ClosedDate { get; set; }

        [Required, Display(Name = "Priority")]
        public int PriorityModelId { get; set; }

        [Required, Display(Name = "Status")]
        public int StatusModelId { get; set; }
        public bool Archived { get; set; }

        [Display(Name = "Photo")]
        public int PhotoId { get; set; }



        //Navigation Properties
        public virtual CreatorModel CreatorModel { get; set; }
        public virtual PriorityModel PriorityModel { get; set; }
        public virtual StatusModel StatusModel { get; set; }
        public virtual ChangeModel ChangeModel { get; set; }
        public virtual FileModel Photo { get; set; }

        public virtual ICollection<RequirementModel> Requirements { get; set; } = new HashSet<RequirementModel>();
        public virtual ICollection<TaskModel> Tasks { get; set; } = new HashSet<TaskModel>();
        public virtual ICollection<UserModel> Users { get; set; } = new HashSet<UserModel>();
        public virtual ICollection<TeamModel> Teams { get; set; } = new HashSet<TeamModel>();
        public virtual ICollection<TicketModel> Tickets { get; set; } = new HashSet<TicketModel>();
        public virtual ICollection<NoteModel> Notes { get; set; } = new HashSet<NoteModel>();
        public virtual ICollection<FileModel> Attachments { get; set; } = new HashSet<FileModel>();
        public virtual ICollection<ChangeModel> Changes { get; set; } = new HashSet<ChangeModel>();


    }
}
