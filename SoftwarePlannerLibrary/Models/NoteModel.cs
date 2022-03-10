using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SoftwarePlannerLibrary.Models;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public class NoteModel : Tracked
    {
        [Required]
        [Display(Name = "Note")]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }


        //Navigation
        //public virtual int TicketId { get; set; }
        //public virtual TicketModel Ticket { get; set; }
    }
}
