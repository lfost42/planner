using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwarePlannerUI.Models
{
    public class TicketModel
    {
        public int Id { get; set; }

        [Display(Name = "Ticket")]
        [Required, StringLength(20, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string TicketName { get; set; }

        [Display(Name = "Description")]
        [Required, StringLength(500, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string TicketDescription { get; set; }

        [Required, Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Required, Display(Name = "Due Date")]
        public DateTimeOffset DueDate { get; set; }

        [Display(Name = "Closed Date")]
        public DateTimeOffset? ClosedDate { get; set; }

        [Display(Name = "Creator")]
        public int CreatorModelId { get; set; }

        [Required, Display(Name = "Project")]
        public int ProjectModelId { get; set; }
        
        [Display(Name = "Task")]
        public int TaskModelId { get; set; }

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
        public int TeamModelId { get; set; }


        //Navigation Properties
        public virtual CreatorModel CreatorModel { get; set; }
        public virtual ProjectModel ProjectModel { get; set; }
        public virtual TaskModel TaskModel { get; set; }
        public virtual TypeModel TypeModel { get; set; }
        public virtual PriorityModel PriorityModel { get; set; }
        public virtual StatusModel StatusModel { get; set; }
        public virtual UserModel AssignedUser { get; set; }
        public virtual TeamModel TeamModel { get; set; }
        public virtual ICollection<NoteModel> Notes { get; set; } = new HashSet<NoteModel>();
        public virtual ICollection<FileModel> Attachments { get; set; } = new HashSet<FileModel>();



    }
}
