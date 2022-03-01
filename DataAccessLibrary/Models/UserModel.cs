using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLibrary.Models
{
    public class UserModel : IdentityUser
    {
        public int UserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string FullName => $"{FirstName} {LastName}";
<<<<<<< HEAD
=======
<<<<<<< HEAD:DataAccessLibrary/Models/User.cs
=======
>>>>>>> models

        public ICollection<ProjectModel> Projects { get; set; }

        public ICollection<TaskModel> Tasks { get; set; }

        public ICollection<TicketModel> Tickets { get; set; }
<<<<<<< HEAD
=======
>>>>>>> 9b964d9 (created models):DataAccessLibrary/Models/UserModel.cs
>>>>>>> models
    }
}
