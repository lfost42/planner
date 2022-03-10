using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SoftwarePlannerLibrary.Models;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public class TaskModel : Tracked
    {
        [Required]
        [Display(Name = "Task")]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Name { get; set; }

        public DateTimeOffset TargetDate { get; set; }


        //Navigation
        //public virtual ICollection<TicketModel> Tickets { get; set; } = new HashSet<TicketModel>();

        //public virtual int RequirementModelId { get; set; }
        //public virtual RequirementModel RequirementModel { get; set; }

        //[Display(Name = "Attachments")]
        //public virtual ICollection<FileModel> FileModels { get; set; } = new HashSet<FileModel>();
        //[Display(Name = "Tickets")]
        //public virtual ICollection<TicketModel> TicketModels { get; set; } = new HashSet<TicketModel>();
        //[Display(Name = "Changes")]
        //public virtual ICollection<ChangeModel> ChangeModels { get; set; } = new HashSet<ChangeModel>();

    }
}
