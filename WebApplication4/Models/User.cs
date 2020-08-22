using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.DAL;

namespace WebApplication4.Models
{
    public class User
    {
        string userType, userName, userPassword;

        public User()
        {
        }

        public User(string userType, string userName, string userPassword)
        {
            this.userType = userType;
            this.userName = userName;
            this.userPassword = userPassword;
        }

        public string UserType { get => userType; set => userType = value; }
        public string UserName { get => userName; set => userName = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }

        public bool login()
        {
            DBservices dbs = new DBservices();
            List<User> usersList = new List<User>();
            usersList = dbs.getUsers();
            foreach (User currUser in usersList)
            {
                if (currUser.UserName == this.UserName && currUser.UserPassword == this.UserPassword)
                {
                    HttpContext.Current.Session["companyName"] = "All";
                    return true;
                }
            }
            return false;
        }
    }
}