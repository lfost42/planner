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

        public ICollection<TicketModel> Tickets { get; set; } = new HashSet<TicketModel>();
        
        public int RequirementId { get; set; }
        public RequirementModel Requirement { get; set; }

    }
}
