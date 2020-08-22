using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.DAL;

namespace WebApplication4.Models
{
    public class Tour
    {
        int tourId, tourLength, tourPrice;
        string tourSupplier, country, city, tourTitle, tourDescription;


        public Tour(int tourId, string tourSupplier, string country, string city, string tourTitle, string tourDescription, int tourLength, int tourPrice)
        {
            this.tourId = tourId;
            this.tourSupplier = tourSupplier;
            this.country = country;
            this.city = city;
            this.tourTitle = tourTitle;
            this.tourDescription = tourDescription;
            this.tourLength = tourLength;
            this.tourPrice = tourPrice;
        }
        public Tour()
        {

        }
        public int TourId { get => tourId; set => tourId = value; }
        public string TourSupplier { get => tourSupplier; set => tourSupplier = value; }
        public string Country { get => country; set => country = value; }
        public string City { get => city; set => city = value; }
        public string TourTitle { get => tourTitle; set => tourTitle = value; }
        public string TourDescription { get => tourDescription; set => tourDescription = value; }
        public int TourLength { get => tourLength; set => tourLength = value; }
        public int TourPrice { get => tourPrice; set => tourPrice = value; }

<<<<<<< HEAD
        //public static List<Discount> getDiscount()
        //{
        //    DBservices db = new DBservices();
        //    return db.getDiscount();
        //}

        //public int insertDiscount()
        //{
        //    DBservices db = new DBservices();
        //    return db.insert(this);
        //}
        //public static string deleteDiscount(int id)
        //{
        //    DBservices db = new DBservices();
        //    return db.deleteDiscount(id);
        //}
        //public string editDiscout()
        //{
        //    DBservices db = new DBservices();
        //    return db.editDiscount(this);
        //}
=======
        public static List<Tour> getTour()
        {
            DBservices db = new DBservices();
            return db.getTour();
        }

        public int insertTour()
        {
            DBservices db = new DBservices();
            return db.insert(this);
        }
        public static string deleteTour(int id)
        {
            DBservices db = new DBservices();
            return db.deleteTour(id);
        }
        public string editTour()
        {
            DBservices db = new DBservices();
            return db.editTour(this);
        }
>>>>>>> e94674d416c3f1060e61dbba5743d1e9aaf780a7
    }
}