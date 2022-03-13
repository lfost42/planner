using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SoftwarePlannerLibrary.Models;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public class TicketModel
    {
        [Required]
        [Display(Name = "Ticket")]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Title { get; set; }

        [Required, StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }

        public string CreatorModelId { get; set; }
        [Display(Name = "Creator")]
        public virtual CreatorModel CreatorModel { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTimeOffset TargetDate { get; set; }

        public TeamModel AssignedTeam { get; set; }

        public UserModel AssignedUser { get; set; }

        public TicketType TicketType { get; set; } = TicketType.Inquiry;

        public Status Status { get; set; } = Status.New;

        public PriorityLevel PriorityLevel { get; set; } = PriorityLevel.None;

        //[Display(Name = "Attachments")]
        //public virtual ICollection<FileModel> FileModels { get; set; } = new HashSet<FileModel>();

        //[Display(Name = "Notes")]
        //public virtual ICollection<NoteModel> NoteModels { get; set; } = new HashSet<NoteModel>();

    }
}
