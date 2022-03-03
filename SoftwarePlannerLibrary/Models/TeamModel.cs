using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwarePlannerLibrary.Models
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string Team { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserModel> Members  { get; set; }
        public virtual ICollection<ProjectModel> Projects { get; set; }
        public virtual ICollection<NotificationModel> Notification { get; set; }

    }
}
