using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public abstract class Tracked
    {
        public int Id { get; set; }
        public PriorityLevel Priority { get; set; } = PriorityLevel.None;
        public Status Status { get; set; } = Status.Created;


        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public DateTimeOffset DateClosed { get; set; }



        [Display(Name = "Changes")]
        public virtual ICollection<HistoryModel> HistoryModels { get; set; } = new HashSet<HistoryModel>();
  
        //[Display(Name = "Attachments")]
        //public virtual ICollection<FileModel> FileModels { get; set; } = new HashSet<FileModel>();
        
        [Display(Name = "Users Assigned")]
        public virtual ICollection<UserModel> UserModels { get; set; } = new HashSet<UserModel>();


        //public int ProjectModelId { get; set; }
        //public virtual ProjectModel ProjectModel { get; set; }
        //public int RequirementModelId { get; set; }
        //public virtual RequirementModel RequirementModel { get; set; }
        //public int TaskModelId { get; set; }
        //public virtual TaskModel TaskModel { get; set; }
        //public int TicketModelId { get; set; }
        //public virtual TicketModel TicketModel { get; set; }
        //public int NoteModelId { get; set; }
        //public virtual NoteModel NoteModel { get; set; }

        public int HistoryModelId { get; set; }
        public virtual HistoryModel HistoryModel { get; set; }

        //public int FileModelId { get; set; }
        //public virtual FileModel FileModel { get; set; }

        [Display(Name = "User Created")]
        public string UserModelId { get; set; }
        public virtual UserModel UserModel { get; set; }




    }
}
