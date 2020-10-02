using Bug_Bag_Manager.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataLibrary.Models;
using static DataLibrary.BusinessLogic.UsersProcessor;
using static DataLibrary.BusinessLogic.TicketsProcessor; //Change to TicketsProcessor

namespace Bug_Bag_Manager.Controllers
{
    public class FormController : Controller
    {
        // GET: 
        //BugReport/Form/FoundBug
        public ActionResult FoundBug()
        {
            ViewBag.Message = "User Sign Up";
            return View();
        }

        //POST: 
        //When SignUp function asks for a GET request from SignUp form, a POST request is called
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FoundBug(Models.TicketsModel model)
        {
            //If Valid, goes to home page.
            if (ModelState.IsValid) //Double checks if data was valid or not.
            {
                CreateTicket(
                    model.UserId,
                    model.CreatedBy,
                    model.DateCreated = DateTime.Now,
                    model.Title,
                    model.Description,
                    model.Url,
                    model.Type,
                    model.Os,
                    model.Browser,
                    model.StepsToReproduce,
                    model.ExpectedResult,
                    model.ActualResult,
                    model.Priority,
                    model.AssignedTo,
                    model.TicketStatus);
                return RedirectToAction("ViewTickets", "Home");
            }

            //Send data to a Data Library

            return View();
        }

    }
}