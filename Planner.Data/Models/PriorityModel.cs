using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Data.Models
{
    public class PriorityModel
    {
        public int Id { get; set; }

        //None, Low, Important, Serious, Urgent
        [Display(Name = "Priority")]
        [StringLength(10, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength =3)]
        public string PriorityLevel { get; set; }

        

    }
}
