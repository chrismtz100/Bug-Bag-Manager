using System;

namespace DataLibrary.Models
{
    public class TicketsModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Platform { get; set; }
        public string Os { get; set; }
        public string Browser { get; set; }
        public string StepsToReproduce { get; set; }
        public string ExpectedResult { get; set; }
        public string ActualResult { get; set; }
        public string Priority { get; set; }
        public string AssignedTo { get; set; }

    }
}
