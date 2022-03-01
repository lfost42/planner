using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Summary { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateClosed { get; set; }

        public ICollection<UserModel> UsersAssigned { get; set; }

        public ICollection<RequirementModel> Requirements { get; set; }

    }
}
