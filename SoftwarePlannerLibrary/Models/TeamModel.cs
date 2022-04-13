using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwarePlannerLibrary.Models
{
    public class TeamModel
    {
        public int Id { get; set; } 

        [Display(Name = "Team")]
        public string TeamName { get; set; }

        [Display(Name = "Creator")]
        public int CreatorModelId { get; set; }

        [Display(Name = "Photo")]
        public int PhotoId { get; set; }



        //Navigation
        public virtual CreatorModel CreatorModel { get; set; }
        public virtual FileModel Photo { get; set; }


        public virtual ICollection<TicketModel> Tickets { get; set; } = new HashSet<TicketModel>();
        public virtual ICollection<NoteModel> Notes { get; set; } = new HashSet<NoteModel>();

        public virtual ICollection<TaskModel> Tasks { get; set; } = new HashSet<TaskModel>();
        public virtual ICollection<RequirementModel> Requirements { get; set; } = new HashSet<RequirementModel>();
        public virtual ICollection<ProjectModel> Projects { get; set; } = new HashSet<ProjectModel>();

        public virtual ICollection<FileModel> Attachments { get; set; } = new HashSet<FileModel>();
        public virtual ICollection<ChangeModel> Changes { get; set; } = new HashSet<ChangeModel>();


    }
}
