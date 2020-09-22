using Bug_Bag_Manager.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.UsersProcessor;
using static DataLibrary.BusinessLogic.TicketsProcessor;

namespace Bug_Bag_Manager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
                    Platform = row.Platform,
                    Os = row.Os,
                    Browser = row.Browser,
                    StepsToReproduce = row.StepsToReproduce,
                    ExpectedResult = row.ExpectedResult,
                    ActualResult = row.ActualResult,
                    Priority = row.Priority,
                    AssignedTo = row.AssignedTo
                });
            }

            return View(tickets);
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
            return View();
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

        public ActionResult SignUp()
        {
            ViewBag.Message = "User Sign Up";
            return View();
        }

        [HttpPost] //When SignUp function asks for a GET request from SignUp form, a POST request is called
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UsersModel model)
        {
            //If Valid, goes to home page.
            if (ModelState.IsValid) //Double checks if data was valid or not.
            {
                int recordsCreated = CreateUser(model.UserId,
                    model.FirstName,
                    model.LastName,
                    model.EmailAddress);
                return RedirectToAction("Index");
            }

            //Send data to a Data Library

            return View();
        }
    }
}