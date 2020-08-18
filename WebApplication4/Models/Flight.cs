using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.DAL;
using WebApplication4.Models;

namespace WebApplication4.Models
{
    public class Flight
    {
        String stops, flightId, travelTime, from, to;
        int price;
        DateTime startDate;
        DateTime endDate;
        List<Leg> legs;

        public string FlightId { get => flightId; set => flightId = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public string Stops { get => stops; set => stops = value; }
        public int Price { get => price; set => price = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public string TravelTime { get => travelTime; set => travelTime = value; }
        public List<Leg> Legs { get => legs; set => legs = value; }

        public int insert()
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insert(this);
            this.insertLegs();
            return numAffected;
        }
        public void insertLegs()
        {
            foreach (var leg in Legs)
            {
                leg.insert();
            }
        }

    }

}