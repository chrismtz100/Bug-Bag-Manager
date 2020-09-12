using System;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.BusinessLogic
{
    public static class 
        TicketsProcessor
    {
        public static int CreateTicket(int userId, string createdBy, string title, string description,
            string url, string platform, string os, string browser, string stepsToReproduce, 
            string expectedResult, string actualResult, string priority, string assignedTo)
        {
            TicketsModel data = new TicketsModel()
            {
                UserId = userId,
                CreatedBy = createdBy,
                DateCreated = DateTime.Now,
                Title = title,
                Description = description,
                Url = url,
                Platform = platform,
                Os = os,
                Browser = browser,
                StepsToReproduce = stepsToReproduce,
                ExpectedResult = expectedResult,
                ActualResult = actualResult,
                Priority = priority,
                AssignedTo = assignedTo
            };

            Console.WriteLine(DateTime.Now);

            string sql = @"insert into dbo.Tickets (UserId, CreatedBy, DateCreated, Title, Description, Url, Platform, Os, Browser, StepsToReproduce, ExpectedResult, ActualResult, Priority, AssignedTo, Severity)
                           values (@UserId, @CreatedBy, @DateCreated, @Title, @Description, @Url, @Platform, @Os, @Browser, @StepsToReproduce, @ExpectedResult, @ActualResult, @Priority, @AssignedTo);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<TicketsModel> LoadTickets()
        {
            string sql = @"select Id, UserId, CreatedBy, DateCreated, Title, Description, Url, Platform, Os, Browser, StepsToReproduce, ExpectedResult, ActualResult, Priority, AssignedTo
                           from dbo.Tickets;";

            return SqlDataAccess.LoadData<TicketsModel>(sql);
        }
    }
}
