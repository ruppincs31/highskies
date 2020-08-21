using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class TourCompany
    {
        string companyUserName;
        string companyPassword;
        string companyName;
        string companyEmail;

        public TourCompany(string companyUserName, string companyPassword, string companyName, string companyEmail)
        {
            this.companyUserName = companyUserName;
            this.companyPassword = companyPassword;
            this.companyName = companyName;
            this.companyEmail = companyEmail;
        }

        public string CompanyUserName { get => companyUserName; set => companyUserName = value; }
        public string CompanyPassword { get => companyPassword; set => companyPassword = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string CompanyEmail { get => companyEmail; set => companyEmail = value; }



    }
}