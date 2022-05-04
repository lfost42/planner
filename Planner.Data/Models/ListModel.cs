using System;
using System.Collections.Generic;

namespace Planner.Data.Models
{
    public class ListModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isComplete { get; set; }

        //Written by Users
        public string AppUserId { get; set; }
        public virtual UserModel AppUser { get; set; }

        public int? ProjectID { get; set; }
        public virtual ProjectModel Project {get; set;}
        public int? RequirementId { get; set; }
        public virtual RequirementModel Requirement { get; set; }
        public int? TaskId { get; set; }
        public virtual TaskModel Task { get; set; }

        public virtual ICollection<ChangeModel> Changes { get; set; } = new HashSet<ChangeModel>();


    }
}
