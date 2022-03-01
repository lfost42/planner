using System;
namespace SoftwarePlannerLibrary.Models
{
    public class Enum
    {
        public enum PriorityLevel
        {
            None, 
            Low,
            Important,
            Serious,    
            Urgent
        }

        public enum Status
        {
            Created,
            Assigned,
            Pending,
            Closed
        }
    }
}
