using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public class ChangeModel
    {
        public int Id { get; set; }

        public ChangeType Type { get; set; }

        //method to set model based on Type
        //nullable properties for Requirement, Task, Ticket, Note (does it conform to tracked?)

        
        public string CreatorModelId { get; set; }
        [Display(Name = "Creator")]
        public virtual CreatorModel CreatorModel { get; set; }


        [DisplayName("Updated")]
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string UpdatedItem { get; set; }
        [StringLength(500, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }


        [DisplayName("Previous Value")]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string PreviousValue { get; set; }

        [DisplayName("Current Value")]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string CurrentValue { get; set; }


        [DisplayName("Date Modified")]
        public DateTimeOffset DateModified { get; set; }

        public virtual int ProjectModelId { get; set; }
        public virtual ProjectModel ProjectModel { get; set; }

    }
}
