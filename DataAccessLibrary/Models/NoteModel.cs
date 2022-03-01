using System;
using System.Collections.Generic;
using static DataAccessLibrary.Models.Enum;

namespace DataAccessLibrary.Models
{
    public class NoteModel : Trackable
    {
        public string NoteDescription { get; set; }
    }
}
