using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;


namespace WebApplication4.Controllers
{
    public class DiscountController : ApiController
    {
        public IEnumerable<Discount> Get()
        {
            return Discount.getDiscount();
        }

        public string Get(int id)
        {
            return "value";
        }

        public IEnumerable<Discount> Post([FromBody]Discount discount)
        {
            discount.insertDiscount();
            return Discount.getDiscount();
        }

        public IEnumerable<Discount> Put([FromBody]Discount discount)
        {
            discount.editDiscout();
            return Discount.getDiscount();
        }

        public IEnumerable<Discount> Delete([FromBody]int discountId)
        {
            Discount.deleteDiscount(discountId);
            return Discount.getDiscount();
        }
    }
}