using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.DAL;

namespace WebApplication4.Models
{
    public class Order
    {
        int orderId;
        string passengersNames, passengerEmail;
        DateTime orderDate;

        public Order()
        {

        }
        public Order(int orderId, string passengersNames, string passengerEmail, DateTime orderDate)
        {
            this.orderId = orderId;
            this.passengersNames = passengersNames;
            this.passengerEmail = passengerEmail;
            this.orderDate = orderDate;
        }

        public int OrderId { get => orderId; set => orderId = value; }
        public string PassengersNames { get => passengersNames; set => passengersNames = value; }
        public string PassengerEmail { get => passengerEmail; set => passengerEmail = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }

        public static List<Order> getOrder()
        {
            DBservices db = new DBservices();
            return db.getOrder();
        }

        public int insertOrder()
        {
            DBservices db = new DBservices();
            return db.insert(this);
        }
    }
}