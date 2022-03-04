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
        public string Name { get; set; }

        //public ICollection<TicketModel> Tickets { get; set; } = new HashSet<TicketModel>();

        public DateTimeOffset TargetDate { get; set; }
        public int RequirementModelId { get; set; }
        public virtual RequirementModel RequirementModel { get; set; }

    }
}
