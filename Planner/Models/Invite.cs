using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Models
{
    public class Invite
    {
        public int Id { get; set; }

        [DisplayName("Date Sent")]
        public DateTimeOffset InviteDate { get; set; }
        [DisplayName("Join Date")]
        public DateTimeOffset JoinDate { get; set; }

        [DisplayName("Code"), StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public Guid CompanyToken { get; set; }

        
        
        [DisplayName("Company")]
        public int CompanyId { get; set; }
        
        [DisplayName("Project")]
        public int ProjectId { get; set; }
        
        [DisplayName("Invitor")]
        public string InvitorId { get; set; }
        
        [DisplayName("Invitee")]
        public string InviteeId { get; set; }

        [StringLength(30, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string InviteeEmail { get; set; }
        [StringLength(30, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string InviteeFirstName { get; set; }
        [StringLength(30, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string InviteeLastName { get; set; }


        // Determines if an invite is still valid
        public bool IsValid { get; set; }

        
        // Navigation properties
        public virtual Company Company { get; set; }
        public virtual AppUser Invitor { get; set; }
        public virtual AppUser Invitee { get; set; }
        public virtual Project Project { get; set; }
    }
}
