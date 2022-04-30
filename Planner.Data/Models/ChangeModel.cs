using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Data.Models
{
    public class ChangeModel
    {
        public int Id { get; set; }

        [DisplayName("Ticket")]
        public int TicketModelId { get; set; }

        [Required, DisplayName("Updated")]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 5)]
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

        [Display(Name = "Creator")]
        public int CreatorModelId { get; set; }


        //Navigation Properties

        public virtual TicketModel TicketModel { get; set; }
        public virtual CreatorModel CreatorModel { get; set; }

    }
}
