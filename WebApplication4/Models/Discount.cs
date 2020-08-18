using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.DAL;

namespace WebApplication4.Models
{
    public class Discount
    {
        int discountId, discountValue;
        string airlineCode, airportFrom, airportTo;
        DateTime dateFrom, dateTo;


        public Discount(int discountId, string airlineCode, string airportFrom, string airportTo, DateTime dateFrom, DateTime dateTo, int discountValue)
        {
            this.discountId = discountId;
            this.airlineCode = airlineCode;
            this.airportFrom = airportFrom;
            this.airportTo = airportTo;
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
            this.discountValue = discountValue;
        }
        public Discount()
        {

        }
        public int DiscountId { get => discountId; set => discountId = value; }
        public string AirlineCode { get => airlineCode; set => airlineCode = value; }
        public string AirportFrom { get => airportFrom; set => airportFrom = value; }
        public string AirportTo { get => airportTo; set => airportTo = value; }
        public DateTime DateFrom { get => dateFrom; set => dateFrom = value; }
        public DateTime DateTo { get => dateTo; set => dateTo = value; }
        public int DiscountValue { get => discountValue; set => discountValue = value; }

        public static List<Discount> getDiscount()
        {
            DBservices db = new DBservices();
            return db.getDiscount();
        }

        public int insertDiscount()
        {
            DBservices db = new DBservices();
            return db.insert(this);
        }
        public static string deleteDiscount(int id)
        {
            DBservices db = new DBservices();
            return db.deleteDiscount(id);
        }
        public string editDiscout()
        {
            DBservices db = new DBservices();
            return db.editDiscount(this);
        }
    }
}