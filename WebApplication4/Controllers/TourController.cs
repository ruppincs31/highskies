using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;


namespace WebApplication4.Controllers
{
    public class TourController : ApiController
    {
        [HttpGet]
        [Route("api/tour/gettours")]
        public IEnumerable<Tour> Get()
        {
            return Tour.getTour();
        }

        //public string Get(int id)
        //{
        //    return "value";
        //}
        [HttpPost]
        [Route("api/tour/insert")]
        public IEnumerable<Tour> Post([FromBody]Tour tour)
        {
            tour.insertTour();
            return Tour.getTour();
        }
        [HttpPut]
        [Route("api/tour/edit")]
        public IEnumerable<Tour> Put([FromBody]Tour tour)
        {
            tour.editTour();
            return Tour.getTour();
        }

        [HttpDelete]
        [Route("api/tour/delete")]
        public IEnumerable<Tour> Delete([FromBody]int tourId)
        {
            Tour.deleteTour(tourId);
            return Tour.getTour();
        }
    }
}