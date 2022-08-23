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
    public class Project
    {
        //Primary Key
        public int Id { get; set; }


        [DisplayName("Company")]
        public int? CompanyId { get; set; } //Foreign Key

        [Required, DisplayName("Project Name"), StringLength(30, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Name { get; set; }
        
        [DisplayName("Project Description"), StringLength(500, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTimeOffset StartDate { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayName("End Date")]
        public DateTimeOffset? EndDate { get; set; }

        [DisplayName("Priority")]
        public int? ProjectPriorityId { get; set; }


        // Image properties
        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile ImageFormFile { get; set; }
        
        [DisplayName("File Name"), StringLength(30, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string ImageFileName { get; set; }
        
        public byte[] ImageFileData { get; set; }

        [DisplayName("File Extension")]
        public string ImageContentType { get; set; }

        [DisplayName("Archived")]
        public bool Archived { get; set; }

        
        // Navigation properties
        public virtual Company Company { get; set; }
        public virtual ProjectPriority Priority { get; set; }
        
        // Collection properties
        public virtual ICollection<AppUser> Members { get; set; } = new HashSet<AppUser>();
        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

    }
}
