using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SoftwarePlannerLibrary.Models;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public class TaskModel
    {
        [Required]
        [Display(Name = "Task")]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Title { get; set; }

        [Required, StringLength(500, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }

        //public int CreatorModelId { get; set; }
        //public CreatorModel Creator { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset TargetDate { get; set; }

        public Status Status { get; set; } = Status.New;

        //[Display(Name = "Project")]
        //public virtual int ProjectModelId { get; set; }
        //public virtual ProjectModel ProjectModel { get; set; }

        //[Display(Name = "Attachments")]
        //public virtual ICollection<FileModel> FileModels { get; set; } = new HashSet<FileModel>();

        //[Display(Name = "Tickets")]
        //public virtual ICollection<TicketModel> TicketModels { get; set; } = new HashSet<TicketModel>();

        //[Display(Name = "Changes")]
        //public virtual ICollection<ChangeModel> ChangeModels { get; set; } = new HashSet<ChangeModel>();

    }
}
