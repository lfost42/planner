using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Models
{
    public class ProjectPriority
    {
        //Primary Key
        public int Id { get; set; }

        [DisplayName("Priority Name"), StringLength(20, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Name { get; set; }
    }
}
