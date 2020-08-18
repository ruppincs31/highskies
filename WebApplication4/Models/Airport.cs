using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.DAL;


namespace WebApplication4.Models
{
    public class Airport
    {
        string airportId, airportName, airportCity, airportState;
        double airportLong, airportLat;

        public Airport(string airportId, string airportName, string airportCity, string airportState, double airportLong, double airportLat)
        {
            this.AirportId = airportId;
            this.AirportName = airportName;
            this.AirportCity = airportCity;
            this.AirportState = airportState;
            this.AirportLong = airportLong;
            this.AirportLat = airportLat;
        }

        public string AirportId { get => airportId; set => airportId = value; }
        public string AirportName { get => airportName; set => airportName = value; }
        public string AirportCity { get => airportCity; set => airportCity = value; }
        public string AirportState { get => airportState; set => airportState = value; }
        public double AirportLong { get => airportLong; set => airportLong = value; }
        public double AirportLat { get => airportLat; set => airportLat = value; }

        public int insert()
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insert(this);
            return numAffected;
        }
    }
}