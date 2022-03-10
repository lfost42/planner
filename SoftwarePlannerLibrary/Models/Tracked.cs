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



        [Display(Name = "Changes")]
        public virtual ICollection<ChangeModel> ChangesModels { get; set; } = new HashSet<ChangeModel>();

        [Display(Name = "Attachments")]
        public virtual ICollection<FileModel> FileModels { get; set; } = new HashSet<FileModel>();

        [Display(Name = "Users Assigned")]
        public virtual ICollection<UserModel> UserModels { get; set; } = new HashSet<UserModel>();


        public int HistoryModelId { get; set; }
        public virtual ChangeModel HistoryModel { get; set; }

    }
}
