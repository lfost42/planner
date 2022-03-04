using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SoftwarePlannerLibrary.Models;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public class RequirementModel : Tracked
    {
        [Required]
        [Display(Name = "Requirement")]
        public string Name { get; set; }
        public DateTimeOffset TargetDate { get; set; }
        public virtual ICollection<TaskModel> Tasks { get; set; } = new HashSet<TaskModel>();

    }
}
