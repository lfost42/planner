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
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public DateTimeOffset TargetDate { get; set; }

        [Display(Name = "Tasks")]
        public virtual ICollection<TaskModel> TaskModels { get; set; } = new HashSet<TaskModel>();

        public int ProjectModelId { get; set; }
        public virtual ProjectModel ProjectModel { get; set; }

     }
}
