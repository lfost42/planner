using System;
using System.Collections.Generic;
using SoftwarePlannerLibrary.Models;
using static SoftwarePlannerLibrary.Models.Enum;

namespace DataAccessLibrary.Models
{
    public class NoteModel : Tracked
    {
        public string NoteDescription { get; set; }
    }
}
