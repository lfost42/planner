using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftwarePlannerLibrary.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Project")]
        public string ProjectName { get; set; }

        public string CreatorModelId { get; set; }
        [Display(Name = "User Created")]
        public virtual CreatorModel CreatorModel { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Summary { get; set; }

        [Required]
        public DateTimeOffset TargetDate { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime? DateCompleted { get; set; }


        [Display(Name = "Teams Assigned")]
        public virtual ICollection<TeamModel> TeamModels { get; set; } = new HashSet<TeamModel>();
        
        [Display(Name = "Users Assigned")]
        public virtual ICollection<UserModel> UserModels { get; set; } = new HashSet<UserModel>();
        [Display(Name = "Requirements")]
        public virtual ICollection<RequirementModel> RequirementModels { get; set; } = new HashSet<RequirementModel>();
        [Display(Name = "Changes")]
        public virtual ICollection<ChangeModel> ChangeModels { get; set; } = new HashSet<ChangeModel>();

        [Display(Name = "Attachments")]
        public virtual ICollection<FileModel> FileAttachments { get; set; } = new HashSet<FileModel>();
    }
}
