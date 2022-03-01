using System;
using System.Collections.Generic;
using static DataAccessLibrary.Models.Enum;

namespace DataAccessLibrary.Models
{
    public class TicketModel : Trackable
    {
        public ICollection<NoteModel> Notes { get; set; }
    }
}
