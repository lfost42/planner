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

        public virtual ICollection<TicketModel> Tickets { get; set; } = new HashSet<TicketModel>();

        public DateTimeOffset TargetDate { get; set; }
        public virtual int RequirementModelId { get; set; }
        public virtual RequirementModel RequirementModel { get; set; }
 
    }
}
