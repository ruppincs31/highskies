using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.DAL;

namespace WebApplication4.Models
{
    public class siginRequest
    {
        string userName, userPassword;

        public siginRequest(string userName, string userPassword)
        {
            this.UserName = userName;
            this.UserPassword = userPassword;
        }

        public string UserName { get => userName; set => userName = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }

        public TourCompany signin()
        {
            DBservices dbs = new DBservices();
            List<TourCompany> tourCompanyList = new List<TourCompany>();
            tourCompanyList = dbs.getCompanies();
            foreach (TourCompany currCompany in tourCompanyList)
            {
                if (currCompany.CompanyUserName == this.userName && currCompany.CompanyPassword == this.userPassword)
                {
                    return currCompany;
                }
            }
            return null;
        }
    }
}