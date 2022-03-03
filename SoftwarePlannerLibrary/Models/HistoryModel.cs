using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SoftwarePlannerLibrary.Models.Enum;

namespace SoftwarePlannerLibrary.Models
{
    public class HistoryModel
    {
        public int Id { get; set; }

        public HistoryType Type { get; set; }

        //method to set model based on Type
        //nullable properties for Project, Requirement, Task, Ticket, Note?

        [DisplayName("User")]
        public string UserId { get; set; }

        public UserModel User { get; set; }


        [DisplayName("Updated")]
        public string UpdatedItem { get; set; }

        public string Description { get; set; }


        [DisplayName("Previous Value")]
        public string PreviousValue { get; set; }

        [DisplayName("Current Value")]
        public string CurrentValue { get; set; }


        [DisplayName("Date Modified")]
        public DateTimeOffset DateModified { get; set; }
        
    }
}
