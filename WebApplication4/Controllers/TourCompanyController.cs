using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.DAL;
using WebApplication4.Models;
using System.Web;

namespace WebApplication4.Controllers

{
    public class TourCompanyController : ApiController
    {

        // POST api/<controller>
        public IEnumerable<TourCompany> Post([FromBody]TourCompany tourCompany)
        {
            tourCompany.insertTourCompanies();
            return TourCompany.getTourCompanies();
        }
        [HttpPost]
        [Route("api/tourcompany/login")]
        public TourCompany Post([FromBody]siginRequest requestData)
        {
            TourCompany currCompany = requestData.signin();
            HttpContext.Current.Session["companyName"] = currCompany.CompanyName;
            return currCompany;
        }

        public IEnumerable<TourCompany> getTourCompany()
        {
            return TourCompany.getTourCompanies();
        }

    }
}
