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

        public int FileId { get; set; }
        public FileModel ProjectPhoto { get; set; }

        public string Summary { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateCompleted { get; set; }


        public string UserCreatedId { get; set; }
        public UserModel UserCreated { get; set; }


        public virtual ICollection<TeamModel> TeamsAssigned { get; set; } = new HashSet<TeamModel>();

        public virtual ICollection<UserModel> UsersAssigned { get; set; } = new HashSet<UserModel>();

        public virtual ICollection<RequirementModel> Requirements { get; set; } = new HashSet<RequirementModel>();
        
        public virtual ICollection<HistoryModel> ProjectHistory { get; set; } = new HashSet<HistoryModel>();

        public virtual ICollection<FileModel> FileAttachments { get; set; } = new HashSet<FileModel>();

    }
}
