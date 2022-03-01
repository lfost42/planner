using System;
using System.Collections.Generic;
using DataAccessLibrary.Models;
using SoftwarePlannerLibrary.Models;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public class TicketModel : Tracked
    {
        public ICollection<NoteModel> Notes { get; set; }
    }
}
