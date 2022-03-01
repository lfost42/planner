using System;
using System.Collections.Generic;
using static DataAccessLibrary.Models.Enum;

namespace DataAccessLibrary.Models
{
    public class RequirementModel : Trackable
    {
        public ICollection<TaskModel> Tasks { get; set; }
    }
}
