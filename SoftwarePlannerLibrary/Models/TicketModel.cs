using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccessLibrary.Models;
using SoftwarePlannerLibrary.Models;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public class TicketModel : Tracked
    {
        [Required]
        [Display(Name = "Ticket")]
        public string Name { get; set; }
        public TicketType TicketType { get; set; } = TicketType.Inquiry;
        
        public virtual ICollection<NoteModel> Notes { get; set; } = new HashSet<NoteModel>();
    }
}
