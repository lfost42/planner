using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SoftwarePlannerLibrary.Models;

namespace SoftwarePlannerLibrary.Models
{
    public class NoteModel
    {
        public int Id { get; set; }

        [Required, StringLength(500, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }

        [DisplayName("Created")]
        public DateTimeOffset DateCreated { get; set; }

        [Required, Display(Name = "Creator")]
        public int CreatorModelId { get; set; }

        [Display(Name = "Project")]
        public int ProjectModelId { get; set; }

        [Display(Name = "Requirement")]
        public int RequirementModelId { get; set; }

        [Display(Name = "Task")]
        public int TaskModelId { get; set; }

        [Display(Name = "Ticket")]
        public int TicketModelId { get; set; }


        [Required, Display(Name = "Type")]
        public int TypeModelId { get; set; }

        [Required, Display(Name = "Priority")]
        public int PriorityModelId { get; set; }

        [Required, Display(Name = "Status")]
        public int StatusModelId { get; set; }
        public bool Archived { get; set; }

        [Required, Display(Name = "Assigned User")]
        public string AssignedUserlId { get; set; }

        [Required, Display(Name = "Assigned Team")]
        public string TeamModelId { get; set; }


        //Navigation Properties
        public virtual CreatorModel CreatorModel { get; set; }

        public virtual ProjectModel ProjectModel { get; set; }
        public virtual RequirementModel RequirementModel { get; set; }
        public virtual TaskModel TaskModel { get; set; }
        public virtual TicketModel TicketModel { get; set; }

        public virtual TypeModel TypeModel { get; set; }
        public virtual PriorityModel PriorityModel { get; set; }
        public virtual StatusModel StatusModel { get; set; }

        public virtual UserModel AssignedUser { get; set; }
        public virtual TeamModel TeamModel { get; set; }

        public virtual ICollection<AlertModel> Alerts { get; set; } = new HashSet<AlertModel>();

    }
}
