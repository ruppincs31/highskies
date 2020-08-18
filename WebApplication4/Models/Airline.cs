using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.DAL;

namespace WebApplication4.Models
{
    public class Airline
    {
        string airlineId, airlineName;

        public Airline(string airlineId, string airlineName)
        {
            this.AirlineId = airlineId;
            this.AirlineName = airlineName;
        }

        public string AirlineId { get => airlineId; set => airlineId = value; }
        public string AirlineName { get => airlineName; set => airlineName = value; }

        public int insert()
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insert(this);
            return numAffected;
        }
    }

}