using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class FlightController : ApiController
    {
        // POST api/<controller>
        public void Post([FromBody]Flight currFlight)
        {
            currFlight.insert();
        }
    }
}