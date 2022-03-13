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
            New,
            Pending,
            Stale,
            Closed
        }

        public enum TicketType
        {
            Inquiry,
            Issue,
            Request,
            Update,
            Note
        }
    }
}
