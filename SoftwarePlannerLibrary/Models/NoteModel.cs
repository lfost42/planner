using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SoftwarePlannerLibrary.Models;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public class NoteModel
    {
        [Required, StringLength(500, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }

        //public int CreatorModelId { get; set; }
        //[Display(Name = "Creator")]
        //public virtual CreatorModel CreatorModel { get; set; }

        [DisplayName("Date Created")]
        public DateTimeOffset DateCreated { get; set; }

        //Navigation
        //public virtual int TicketId { get; set; }
        //public virtual TicketModel TicketModel { get; set; }

        //Project
        //public virtual int ProjectModelId { get; set; }
        //public virtual ProjectModel ProjectModel { get; set; }

        //Task
        //public virtual int TaskModelId { get; set; }
        //public virtual TaskModel TaskModel { get; set; }

    }
}
