using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwarePlannerUI.Models
{
    public class StatusModel
    {
        public int Id { get; set; }

        //New, Pending, Stale, Closed
        [Display(Name = "Name")]
        [StringLength(10, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 3)]
        public string Status { get; set; }

        
        
    }
}
