using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class OrderController : ApiController
    {
        public IEnumerable<Order> Get()
        {
            return Order.getOrder();
        }

        public IEnumerable<Order> Post([FromBody]Order order)
        {
            order.insertOrder();
            return Order.getOrder();
        }

    }
}