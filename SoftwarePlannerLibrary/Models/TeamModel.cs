using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwarePlannerLibrary.Models
{
    public class TeamModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Team { get; set; }
        [StringLength(500, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }

        public int CreatorModelId { get; set; }
        [Display(Name = "Creator")]
        public virtual CreatorModel CreatorModel { get; set; }
        
        [Display(Name = "Members")]
        public virtual ICollection<UserModel> UserModels { get; set; }
        [Display(Name = "Projects")]
        public virtual ICollection<ProjectModel> ProjectModels { get; set; }
        [Display(Name = "Notifications")]
        public virtual ICollection<NotificationModel> NotificationModels { get; set; }
    }
}
