using System;
using System.Collections.Generic;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public abstract class Tracked
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public PriorityLevel Priority { get; set; } = PriorityLevel.None;

        public Status Status { get; set; } = Status.Created;


        public UserModel UserCreated { get; }

        public UserModel UserAssigned { get; set; }


        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateClosed { get; set; }
    }
}
