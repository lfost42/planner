using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Models
{
    public class Company
    {
        //Primary Key
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Company Name")]
        public string Name { get; set; }

        [DisplayName("Company Description")]
        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<AppUser> Members { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        //create relationship to Invites
        public virtual ICollection<Invite> Invites { get; set; }
    }
}
