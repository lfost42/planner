using System;
using System.Collections.Generic;
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


        public virtual ICollection<HistoryModel> ItemHistory { get; set; } = new HashSet<HistoryModel>();
        public virtual ICollection<FileModel> Attachments { get; set; } = new HashSet<FileModel>();
        public virtual ICollection<UserModel> UsersAssigned { get; set; } = new HashSet<UserModel>();

        public string UserCreatedId { get; set; }
        public UserModel UserCreated { get; }

        public int ProjectId { get; set; }
        public virtual ProjectModel Project { get; set; }
    }
}
