using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SoftwarePlannerLibrary.Models;
using static SoftwarePlannerLibrary.Models.Enum;

namespace DataAccessLibrary.Models
{
    public class NoteModel : Tracked
    {
        [Required]
        [Display(Name = "Note")]
        public string Name { get; set; }
        public string Description { get; set; }

        public int TicketId { get; set; }
        public TicketModel Ticket { get; set; }
    }
}
