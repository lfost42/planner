using System;
using System.Collections.Generic;
using SoftwarePlannerLibrary.Models;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public class RequirementModel : Tracked
    {
        public ICollection<TaskModel> Tasks { get; set; }
    }
}
