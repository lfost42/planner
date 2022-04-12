using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SoftwarePlannerLibrary.Models;

namespace SoftwarePlannerUI.Models
{
    public class AlertModel
    {
        public int Id { get; set; }

        [Required, Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Recipient")]
        public string RecipientId { get; set; }

        [Display(Name = "Sender")]
        public int CreatorModelId { get; set; }

        [Display(Name = "Read")]
        public bool Read { get; set; }

        [Display(Name = "Note")]
        public int NoteId { get; set; }
        public string Subject { get; set; }

        [Required, StringLength(500, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Message { get; set; }



        //Navigation Properties
        public virtual CreatorModel CreatorModel { get; set; }
        public virtual UserModel Recipient { get; set; }
        public virtual NoteModel Note { get; set; }


    }
}
