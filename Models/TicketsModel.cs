using System;
using System.ComponentModel.DataAnnotations;

namespace Bug_Bag_Manager.Models
{
    public class TicketsModel
    {
        //BugId +++++++++++++++++++++++++++++++++++++++++++++
        [Display(Name = "ID")]
        public int Id { get; set; } //

        [Display(Name = "User ID*")]
        [Required(ErrorMessage = "You need to submit your User Id")]
        [Range(100000, 999999, ErrorMessage = "You need to enter a valid UserID: Range from 100000-999999")]
        public int UserId { get; set; } //

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; } //

        [Display(Name = "Created")]
        public DateTime DateCreated { get; set; } //
        [Display(Name = "Ticket Status")]
        public int? TicketStatus { get; set; } //


        //BugOverview ++++++++++++++++++++++++++++++++++++++++

        [Display(Name = "Ticket Title*")]
        [Required(ErrorMessage = "You need to give us a title to this bug")]
        public string Title { get; set; } //

        [Display(Name = "Ticket Description*")]
        [Required(ErrorMessage = "You need to give us a description of the bug.")]
        public string Description { get; set; } //

        [Display(Name = "Url")]
        public string Url { get; set; } //

        [Display(Name = "Type")]
        public string Type { get; set; } //

        [Display(Name = "OS")]
        public string Os { get; set; } //

        [Display(Name = "Browser")]
        public string Browser { get; set; } //

        //BugDetails +++++++++++++++++++++++++++++++++++++++++++++++++
        [Display(Name = "Steps To Reproduce")]
        public string StepsToReproduce { get; set; } //

        [Display(Name = "Expected Result")]
        public string ExpectedResult { get; set; } //

        [Display(Name = "Actual Result")]
        public string ActualResult { get; set; } //

        //BugTracking ++++++++++++++++++++++++++++++++++++++++++++++++++

        [Display(Name = "Priority*")]
        [Required(ErrorMessage = "You need to give us a the priority level of the bug.")]
        public string Priority { get; set; } //

        [Display(Name = "Assigned Developer*")]

        [Required(ErrorMessage = "You need to give us who this bug is for.")]
        public string AssignedTo { get; set; } //
    }
}