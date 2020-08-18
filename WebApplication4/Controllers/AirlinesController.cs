using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class AirlinesController : ApiController
    {
        // POST api/<controller>
        public void Post([FromBody]Airline[] airlines)
        {
            foreach (var airline in airlines)
            {
                airline.insert();
            }
        }

    }
}