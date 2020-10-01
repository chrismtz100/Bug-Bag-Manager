using Bug_Bag_Manager.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.UsersProcessor;
using static DataLibrary.BusinessLogic.TicketsProcessor;
using System;

namespace Bug_Bag_Manager.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            return View();
        }

        public ActionResult SignUp()
        {
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
                return RedirectToAction("Index", "Home");
            }

            //Send data to a Data Library

            return View();
        }
    }
}