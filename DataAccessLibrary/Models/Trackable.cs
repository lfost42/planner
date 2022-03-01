using System;
using System.Collections.Generic;
using static DataAccessLibrary.Models.Enum;

namespace DataAccessLibrary.Models
{
    public abstract class Trackable : ITrackable
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
