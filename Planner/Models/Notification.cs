using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Models
{
    public class Notification
    {
        //Primary Key
        public int Id { get; set; }
        [DisplayName("Ticket")]
        public int TicketId { get; set; }

        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Message")]
        public string Message { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTimeOffset Created { get; set; }

        [Required]
        [DisplayName("Recipient")]
        public string RecipientId { get; set; }
        [Required]
        [DisplayName("Sender")]
        public string SenderId { get; set; }
        
        [DisplayName("Has been viewed")]
        public bool Viewed { get; set; }

        //Navigation Properties
        public virtual Ticket Ticket { get; set; }
        public virtual AppUser Recipient { get; set; }
        public virtual AppUser Sender { get; set; }
    }
}
