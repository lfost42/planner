using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public abstract class Tracked
    {
        public int Id { get; set; }

        public int CreatorModelId { get; set; }
        [Display(Name = "Creator")]
        public virtual CreatorModel CreatorModel { get; set; }

        public PriorityLevel Priority { get; set; } = PriorityLevel.None;
        public Status Status { get; set; } = Status.Created;


        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public DateTimeOffset DateClosed { get; set; }


        //Navigation
        //[Display(Name = "Changes")]
        //public virtual ICollection<ChangeModel> ChangesModels { get; set; } = new HashSet<ChangeModel>();

        //[Display(Name = "Attachments")]
        //public virtual ICollection<FileModel> FileModels { get; set; } = new HashSet<FileModel>();

        //[Display(Name = "Tickets")]
        //public virtual ICollection<TicketModel> TicketModels { get; set; } = new HashSet<TicketModel>();

    }
}
