using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwarePlannerLibrary.Models
{
    public class NotificationModel
    {
        public int Id { get; set; }

        [Required, StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Subject { get; set; }

        [Required]
        public DateTimeOffset DateSent { get; set; }

        [Required, StringLength(500, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Message { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string RecipientEmail { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string SenderEmail { get; set; }

    }
}
