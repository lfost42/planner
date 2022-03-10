using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftwarePlannerLibrary.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        [Required, Display(Name = "Project")]
        public string ProjectName { get; set; }

        public string CreatorModelId { get; set; }
        [Display(Name = "User Created")]
        public virtual CreatorModel CreatorModel { get; set; }

        [Required, StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Summary { get; set; }

        [Required]
        public DateTimeOffset TargetDate { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime? DateCompleted { get; set; }


        //Navigation
        //[Display(Name = "Requirements")]
        //public virtual ICollection<RequirementModel> RequirementModels { get; set; } = new HashSet<RequirementModel>();

        //[Display(Name = "Attachments")]
        //public virtual ICollection<FileModel> FileModels { get; set; } = new HashSet<FileModel>();
        //[Display(Name = "Tickets")]
        //public virtual ICollection<TicketModel> TicketModels { get; set; } = new HashSet<TicketModel>();
        //[Display(Name = "Changes")]
        //public virtual ICollection<ChangeModel> ChangeModels { get; set; } = new HashSet<ChangeModel>();

    }
}
