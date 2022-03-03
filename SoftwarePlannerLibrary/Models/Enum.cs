using System;
namespace SoftwarePlannerLibrary.Models
{
    public class Enum
    {
        public enum HistoryType
        {
            Project,
            Requirement,
            Task,
            Ticket,
            Note
        }
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

        public enum TicketType
        {
            Inquiry,
            Bug,
            Request,
            Error
        }
    }
}
