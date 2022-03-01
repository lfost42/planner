using System;

namespace DataAccessLibrary.Models
{
    public interface ITrackable
    {
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
        DateTime DateClosed { get; set; }
    }
}