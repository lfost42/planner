using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SoftwarePlannerLibrary.Models;

namespace SoftwarePlannerUI.Models
{
    public class RequirementModel
    {
        public int Id { get; set; }

        [Required, Display(Name = "Requirement")]
        public string RequirementName { get; set; }

        [Required, StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }

        [Required, Display(Name = "Creator")]
        public int CreatorId { get; set; }

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
        public bool Archived { get; set; } = false;

        [Required, Display(Name = "Assigned User")]
        public string AssignedUserlId { get; set; }

        [Required, Display(Name = "Assigned Team")]
        public string TeamModelId { get; set; }

        [Display(Name = "Photo")]
        public int PhotoId { get; set; }



        //Navigation Properties
        public virtual CreatorModel Creator { get; set; }
        public virtual TypeModel TypeModel { get; set; }
        public virtual PriorityModel PriorityModel { get; set; }
        public virtual StatusModel StatusModel { get; set; }
        public virtual UserModel AssignedUser { get; set; }
        public virtual TeamModel TeamModel { get; set; }
        public virtual FileModel Photo { get; set; }

        public virtual ICollection<TaskModel> Tasks { get; set; } = new HashSet<TaskModel>();

        public virtual ICollection<TicketModel> Tickets { get; set; } = new HashSet<TicketModel>();
        public virtual ICollection<NoteModel> Notes { get; set; } = new HashSet<NoteModel>();
        public virtual ICollection<FileModel> Attachments { get; set; } = new HashSet<FileModel>();
        public virtual ICollection<ChangeModel> Changes { get; set; } = new HashSet<ChangeModel>();



    }
}
