using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Models
{
    public class TicketNote
    {
        public int Id { get; set; }
        
        [DisplayName("Member Note"), StringLength(30, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Note { get; set; }

        [DisplayName("Date")]
        public DateTimeOffset Created { get; set; }
        [DisplayName("Ticket")]
        public int TicketId { get; set; } //Foreign Key
        [DisplayName("Team Member")]
        public string UserId { get; set; } //Foreign Key


        // Navigation Properties
        public virtual Ticket Ticket { get; set; }
        public virtual AppUser User { get; set; }
    }
}
