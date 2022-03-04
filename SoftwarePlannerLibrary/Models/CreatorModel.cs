using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwarePlannerLibrary.Models
{
    public class CreatorModel
    {
        public int Id { get; set; }
        public string UserModelId { get; set; }
        [Display(Name = "Creator")]
        public UserModel UserModel { get; set; }
    }
}
