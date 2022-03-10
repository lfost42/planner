using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SoftwarePlannerLibrary.Models;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public class RequirementModel : Tracked
    {
        [Required, Display(Name = "Requirement")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public DateTimeOffset TargetDate { get; set; }

        //Navigation
        //[Display(Name = "Tasks")]
        //public virtual ICollection<TaskModel> TaskModels { get; set; } = new HashSet<TaskModel>();

        //public int ProjectModelId { get; set; }
        //public virtual ProjectModel ProjectModel { get; set; }

        //[Display(Name = "Attachments")]
        //public virtual ICollection<FileModel> FileModels { get; set; } = new HashSet<FileModel>();
        //[Display(Name = "Tickets")]
        //public virtual ICollection<TicketModel> TicketModels { get; set; } = new HashSet<TicketModel>();
        //[Display(Name = "Changes")]
        //public virtual ICollection<ChangeModel> ChangeModels { get; set; } = new HashSet<ChangeModel>();



    }
}
