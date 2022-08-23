using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Models
{
    public class Ticket
    {
        //Primary Key
        public int Id { get; set; }

        [Required] //Makes the property required
        [StringLength(50)] //Limits the size of the string
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DataType(DataType.Date)] //Specifies the DataType
        [DisplayName("Created")]
        public DateTimeOffset Created { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Updated")]
        public DateTimeOffset? Updated { get; set; } // "?" == Nullable

        [DisplayName("Archived")]
        public bool Archived { get; set; }

        [DisplayName("Project")]
        public int ProjectID { get; set; }


        // Foreign Keys - Lookup Tables
        [DisplayName("Ticket Type")]
        public int TicketTypeId { get; set; } 

        [DisplayName("Ticket Priority")]
        public int TicketPriorityId { get; set; } 

        [DisplayName("Ticket Status")]
        public int TicketStatusId { get; set; }


        // AppUser Foreign Keys
        [DisplayName("Ticket Owner")]
        public string OwnerUserId { get; set; }

        [DisplayName("Ticket Developer")]
        public string DeveloperUserId { get; set; }

        
        // Navigation properties
        public virtual Project Project { get; set; }
        public virtual TicketType TicketType { get; set; }
        public virtual TicketPriority TicketPriority { get; set; }
        public virtual TicketStatus TicketStatus { get; set; }
        public virtual AppUser OwnerUser { get; set; }
        public virtual AppUser DeveloperUser { get; set; }


        // ICollection Navigation properties
        public virtual ICollection<TicketComment> Comments { get; set; } = new HashSet<TicketComment>();
        public virtual ICollection<TicketAttachment> Attachments { get; set; } = new HashSet<TicketAttachment>();
        public virtual ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        public virtual ICollection<TicketHistory> History { get; set; } = new HashSet<TicketHistory>();
    }
}
