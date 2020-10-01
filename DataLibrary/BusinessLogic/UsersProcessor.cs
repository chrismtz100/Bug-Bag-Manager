using DataLibrary.DataAccess;
using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.BusinessLogic
{
    public static class
        UsersProcessor
    {
        public static int CreateUser(int userId, string firstName,
            string lastName, string emailAddress)
        {
            UsersModel data = new UsersModel
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress

            };

            string sql = @"insert into dbo.Users (UserId, FirstName, LastName, EmailAddress)
                           values (@UserId, @FirstName, @LastName, @EmailAddress);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<UsersModel> LoadUsers()
        {
            string sql = @"select Id, UserId, FirstName, LastName, EmailAddress
                           from dbo.Users;";

            return SqlDataAccess.LoadData<UsersModel>(sql);
        }
    }
}
