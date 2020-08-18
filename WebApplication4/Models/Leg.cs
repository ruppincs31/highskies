using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.DAL;


namespace WebApplication4.Models
{
    public class Leg
    {
        string legId, legFlightId, legDepartureAirport, legArivalAirport, legAirlineId, legFlightLength;
        int legNum, legFlightNo;
        DateTime legDepartureTime, legArivalTime;

        public Leg(string legId, string legFlightId, string legDepartureAirport, string legArivalAirport, string legAirlineId, string legFlightLength, int legNum, int legFlightNo, DateTime legDepartureTime, DateTime legArivalTime)
        {
            this.LegId = legId;
            this.LegFlightId = legFlightId;
            this.LegDepartureAirport = legDepartureAirport;
            this.LegArivalAirport = legArivalAirport;
            this.LegAirlineId = legAirlineId;
            this.LegFlightLength = legFlightLength;
            this.LegNum = legNum;
            this.LegFlightNo = legFlightNo;
            this.LegDepartureTime = legDepartureTime;
            this.LegArivalTime = legArivalTime;
        }

        public string LegId { get => legId; set => legId = value; }
        public string LegFlightId { get => legFlightId; set => legFlightId = value; }
        public string LegDepartureAirport { get => legDepartureAirport; set => legDepartureAirport = value; }
        public string LegArivalAirport { get => legArivalAirport; set => legArivalAirport = value; }
        public string LegAirlineId { get => legAirlineId; set => legAirlineId = value; }
        public string LegFlightLength { get => legFlightLength; set => legFlightLength = value; }
        public int LegNum { get => legNum; set => legNum = value; }
        public int LegFlightNo { get => legFlightNo; set => legFlightNo = value; }
        public DateTime LegDepartureTime { get => legDepartureTime; set => legDepartureTime = value; }
        public DateTime LegArivalTime { get => legArivalTime; set => legArivalTime = value; }

        public int insert()
        {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insert(this);
            return numAffected;
        }
    }
}