using Bug_Bag_Manager.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.TicketsProcessor;
using static DataLibrary.BusinessLogic.UsersProcessor;

namespace Bug_Bag_Manager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult TicketDetails()
        {
            //ViewBag.Message = "Tickets List";

            var data = LoadTickets();
            int thirdRow = data.Count - 1;
            List<TicketsModel> tickets = new List<TicketsModel>
            {
                new TicketsModel()
                {
                    Id = data[thirdRow].Id,
                    UserId = data[thirdRow].UserId,
                    CreatedBy = data[thirdRow].CreatedBy,
                    DateCreated = data[thirdRow].DateCreated,
                    Title = data[thirdRow].Title,
                    Description = data[thirdRow].Description,
                    Url = data[thirdRow].Url,
                    Type = data[thirdRow].Type,
                    Os = data[thirdRow].Os,
                    Browser = data[thirdRow].Browser,
                    StepsToReproduce = data[thirdRow].StepsToReproduce,
                    ExpectedResult = data[thirdRow].ExpectedResult,
                    ActualResult = data[thirdRow].ActualResult,
                    Priority = data[thirdRow].Priority,
                    AssignedTo = data[thirdRow].AssignedTo,
                    TicketStatus = data[thirdRow].TicketStatus
                }
            };

            return View(tickets);
        }

        public ActionResult ViewTickets()
        {

            var data = LoadTickets();
            List<TicketsModel> tickets = new List<TicketsModel>();
            int totalTickets = data.Count;
            ViewBag.NumOfTickets = totalTickets;
            foreach (var row in data)
            {
                tickets.Add(new TicketsModel()
                {
                    Id = row.Id,
                    UserId = row.UserId,
                    CreatedBy = row.CreatedBy,
                    DateCreated = row.DateCreated,
                    Title = row.Title,
                    Description = row.Description,
                    Url = row.Url,
                    Type = row.Type,
                    Os = row.Os,
                    Browser = row.Browser,
                    StepsToReproduce = row.StepsToReproduce,
                    ExpectedResult = row.ExpectedResult,
                    ActualResult = row.ActualResult,
                    Priority = row.Priority,
                    AssignedTo = row.AssignedTo,
                    TicketStatus = row.TicketStatus
                });
            }

            return View(tickets);
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Dashboard";
            var data = LoadTickets();
            int numberOfTickets = data.Count;
            int numberOfResolvedTickets = 0;
            int numberOfUnresolvedTickets = 0;

            int priorityLow = 0;
            int priorityMedium = 0;
            int priorityHigh = 0;
            int priorityNone = 0;

            int count = 0;
            while (count < numberOfTickets)
            {
                //Count Resolved Tickets
                if (data[count].TicketStatus == 1)
                {
                    numberOfResolvedTickets++;
                }
                else if (data[count].TicketStatus == 0 || data[count].TicketStatus == null)
                {
                    numberOfUnresolvedTickets++;
                }

                //Count Different Priority Values
                if ((String)data[count].Priority == "HIGH" || (String)data[count].Priority == "High" || (String)data[count].Priority == "high")
                {
                    priorityHigh++;
                }
                else if ((String)data[count].Priority == "MEDIUM" || (String)data[count].Priority == "Medium" || (String)data[count].Priority == "medium")
                {
                    priorityMedium++;
                }
                else if ((String)data[count].Priority == "LOW" || (String)data[count].Priority == "Low" || (String)data[count].Priority == "low")
                {
                    priorityLow++;
                }
                else if ((String)data[count].Priority == "None" || (String)data[count].Priority == "none" || (String)data[count].Priority == null)
                {
                    priorityNone++;
                }
                count++;
            }

            //Ticket Nums
            ViewBag.NumOfTickets = numberOfTickets;
            //Tickets Resolved/Unresolved
            ViewBag.NumOfResolvedTickets = numberOfResolvedTickets;
            ViewBag.NumOfUnresolvedTickets = numberOfUnresolvedTickets;
            //Ticket Priority Data
            ViewBag.NumOfPriorityLow = priorityLow;
            ViewBag.NumOfPriorityMedium = priorityMedium;
            ViewBag.NumOfPriorityHigh = priorityHigh;
            ViewBag.NumOfPriorityNone = priorityNone;

            return View();
        }

        // GET: CreateTicket/Index
        public ActionResult CreateTicket()
        {
            return RedirectToAction("FoundBug", "Form");
        }

        public ActionResult FAQs()
        {
            return View();
        }

        public ActionResult ResolvedBugs()
        {
            ViewBag.Message = "Tickets List";

            var data = LoadTickets();
            List<TicketsModel> tickets = new List<TicketsModel>();

            foreach (var row in data)
            {
                tickets.Add(new TicketsModel()
                {
                    Id = row.Id,
                    UserId = row.UserId,
                    CreatedBy = row.CreatedBy,
                    DateCreated = row.DateCreated,
                    Title = row.Title,
                    Description = row.Description,
                    Url = row.Url,
                    Type = row.Type,
                    Os = row.Os,
                    Browser = row.Browser,
                    StepsToReproduce = row.StepsToReproduce,
                    ExpectedResult = row.ExpectedResult,
                    ActualResult = row.ActualResult,
                    Priority = row.Priority,
                    AssignedTo = row.AssignedTo,
                    TicketStatus = row.TicketStatus
                });
            }

            return View(tickets);
        }

        public ActionResult UnresolvedBugs()
        {
            ViewBag.Message = "Tickets List";

            var data = LoadTickets();
            List<TicketsModel> tickets = new List<TicketsModel>();

            foreach (var row in data)
            {
                tickets.Add(new TicketsModel()
                {
                    Id = row.Id,
                    UserId = row.UserId,
                    CreatedBy = row.CreatedBy,
                    DateCreated = row.DateCreated,
                    Title = row.Title,
                    Description = row.Description,
                    Url = row.Url,
                    Type = row.Type,
                    Os = row.Os,
                    Browser = row.Browser,
                    StepsToReproduce = row.StepsToReproduce,
                    ExpectedResult = row.ExpectedResult,
                    ActualResult = row.ActualResult,
                    Priority = row.Priority,
                    AssignedTo = row.AssignedTo,
                    TicketStatus = row.TicketStatus
                });
            }

            return View(tickets);
        }

        public ActionResult MyBugs()
        {
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult ViewUsers()
        {
            ViewBag.Message = "Users List";

            var data = LoadUsers();
            List<UsersModel> users = new List<UsersModel>();

            foreach (var row in data)
            {
                users.Add(new UsersModel()
                {
                    UserId = row.UserId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress,
                    ConfirmEmail = row.EmailAddress
                });
            }

            return View(users);
        }


    }
}