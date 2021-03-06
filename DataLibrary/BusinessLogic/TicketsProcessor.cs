﻿using System;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.BusinessLogic
{
    public static class
        TicketsProcessor
    {
        public static int CreateTicket(int userId, string createdBy, DateTime dateCreated, string title, string description,
            string url, string type, string os, string browser, string stepsToReproduce,
            string expectedResult, string actualResult, string priority, string assignedTo, int? ticketStatus)
        {
            TicketsModel data = new TicketsModel()
            {
                UserId = userId,
                CreatedBy = createdBy,
                DateCreated = dateCreated,
                Title = title,
                Description = description,
                Url = url,
                Type = type,
                Os = os,
                Browser = browser,
                StepsToReproduce = stepsToReproduce,
                ExpectedResult = expectedResult,
                ActualResult = actualResult,
                Priority = priority,
                AssignedTo = assignedTo,
                TicketStatus = ticketStatus
            };

            Console.WriteLine(DateTime.Now);
            string sql = @"insert into dbo.Tickets (UserId, CreatedBy, DateCreated, Title, Description, Url, Type, Os, Browser, StepsToReproduce, ExpectedResult, ActualResult, Priority, AssignedTo, TicketStatus)
                           values (@UserId, @CreatedBy, @DateCreated, @Title, @Description, @Url, @Type, @Os, @Browser, @StepsToReproduce, @ExpectedResult, @ActualResult, @Priority, @AssignedTo, @TicketStatus);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<TicketsModel> LoadTickets()
        {
            string sql = @"select Id, UserId, CreatedBy, DateCreated, Title, Description, Url, Type, Os, Browser, StepsToReproduce, ExpectedResult, ActualResult, Priority, AssignedTo, TicketStatus
                           from dbo.Tickets;";

            return SqlDataAccess.LoadData<TicketsModel>(sql);
        }
    }
}
