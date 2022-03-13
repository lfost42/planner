using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        [Required, Display(Name = "Project")]
        public string ProjectName { get; set; }

        [Required, StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }

        //public string CreatorModelId { get; set; }
        //[Display(Name = "Creator")]
        //public virtual CreatorModel CreatorModel { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTimeOffset TargetDate { get; set; }

        public Status Status { get; set; } = Status.New;

        public PriorityLevel PriorityLevel { get; set; } = PriorityLevel.None;

        //Navigation
        //[Display(Name = "Tasks")]
        //public virtual ICollection<TaskModel> TaskModels { get; set; } = new HashSet<TaskModel>();

        //[Display(Name = "Notes")]
        //public virtual ICollection<NoteModel> NoteModels { get; set; } = new HashSet<NoteModel>();

        //[Display(Name = "Attachments")]
        //public virtual ICollection<FileModel> FileModels { get; set; } = new HashSet<FileModel>();

        //[Display(Name = "Tickets")]
        //public virtual ICollection<TicketModel> TicketModels { get; set; } = new HashSet<TicketModel>();

        //[Display(Name = "Changes")]
        //public virtual ICollection<ChangeModel> ChangeModels { get; set; } = new HashSet<ChangeModel>();

    }
}
