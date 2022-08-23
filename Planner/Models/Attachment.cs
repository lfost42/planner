using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Models
{
    public class TicketAttachment
    {
        public int Id { get; set; }

        [DisplayName("Ticket")]
        public int TicketId { get; set; } // Foreign Key

        [DisplayName("File Date")]
        public DateTimeOffset Created { get; set; }

        [DisplayName("Team Member")]
        public string UserId { get; set; } // Foreign Key

        [DisplayName("File Description"), StringLength(300, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile FormFile { get; set; }
        [DisplayName("File Name"), StringLength(30, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        
        [DisplayName("File Extension"), StringLength(5, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string FileContentType { get; set; }

        
        // Navigation Properties
        public virtual Ticket Ticket { get; set; }
        public virtual AppUser User { get; set; }
    }
}
