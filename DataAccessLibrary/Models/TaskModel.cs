using System;
using System.Collections.Generic;
using static DataAccessLibrary.Models.Enum;

namespace DataAccessLibrary.Models
{
    public class TaskModel : Trackable
    {
        public ICollection<TicketModel> Tickets { get; set; }
    }
}
