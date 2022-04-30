using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Data.Models
{
    public class CreatorModel
    {
        public int Id { get; set; }
        public string UserModelId { get; set; }
        public UserModel UserModel { get; set; }
    }

}
