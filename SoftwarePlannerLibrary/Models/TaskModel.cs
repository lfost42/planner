using System;
using System.Collections.Generic;
using SoftwarePlannerLibrary.Models;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public class TaskModel : Tracked
    {
        public ICollection<TicketModel> Tickets { get; set; }
    }
}
