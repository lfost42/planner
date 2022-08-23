using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Models
{
    public class TicketComment
    {
        public int Id { get; set; }
        
        [DisplayName("Member Comment")]
        public string Comment { get; set; }
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
