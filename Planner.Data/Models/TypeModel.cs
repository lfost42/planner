using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Data.Models
{
    public class TypeModel
    {
        public int Id { get; set; }

        //Inquiry,Issue,Request,Update,Note
        [Display(Name = "Type")]
        [StringLength(10, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 4)]
        public string TicketType { get; set; }



    }
}
