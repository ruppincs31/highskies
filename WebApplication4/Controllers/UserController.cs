using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class UserController : ApiController
    {
        public bool Post([FromBody]User currUser)
        {
            return currUser.login();
        }
    }
}