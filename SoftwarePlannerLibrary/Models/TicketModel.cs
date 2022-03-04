using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Notes")]
        public virtual ICollection<NoteModel> NoteModels { get; set; } = new HashSet<NoteModel>();
        public int TaskModelId { get; set; }
        public virtual TaskModel TaskModel { get; set; }

    }
}
