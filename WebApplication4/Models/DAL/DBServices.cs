using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using WebApplication4.Models;

namespace WebApplication4.DAL
{
    /// <summary>
    /// DBServices is a class created by me to provides some DataBase Services
    /// </summary>
    public class DBservices
    {
        public SqlDataAdapter da;
        public DataTable dt;

        public DBservices()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //--------------------------------------------------------------------------------------------------
        // This method creates a connection to the database according to the connectionString name in the web.config 
        //--------------------------------------------------------------------------------------------------
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }

        //--------------------------------------------------------------------------------------------------
        // This method inserts a car to the cars table 
        //--------------------------------------------------------------------------------------------------
        public int insert(object currobject)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String objectStr = BuildInsertCommand(currobject);      // helper method to build the insert string

            cmd = CreateCommand(objectStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                return 0;
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        public string deleteDiscount(int discountId)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);

            }

            String cStr = "DELETE FROM Discount_CS where DiscountId = " + discountId;      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                string numEffected = (string)cmd.ExecuteScalar(); // execute the command

                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        public string editDiscount(Discount discount)
        {
            deleteDiscount(discount.DiscountId);
            return insert(discount).ToString();
        }

        public string deleteTour(int tourId)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);

            }

            String cStr = "DELETE FROM Tour_CS where tourId = " + tourId;      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                string numEffected = (string)cmd.ExecuteScalar(); // execute the command

                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        public string editTour(Tour tour)
        {
            deleteTour(tour.TourId);
            return insert(tour).ToString();
        }

        //--------------------------------------------------------------------
        // Build the Insert command String
        //--------------------------------------------------------------------
        private String BuildInsertCommand(object currobject)
        {
            String command;
            // use a string builder to create the dynamic string
            StringBuilder sb = new StringBuilder();

            // checks which object
            if (currobject is Airline)
            {
                Airline airlineObj = currobject as Airline;
                sb.AppendFormat("Values('{0}', '{1}')", airlineObj.AirlineId, airlineObj.AirlineName);
                String prefix = "INSERT INTO Airlines_CS " + "(AirlineId, AirlineName) ";
                command = prefix + sb.ToString();
                return command;
            }
            else if (currobject is Airport)
            {
                Airport airpotObj = currobject as Airport;
                sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", airpotObj.AirportId, airpotObj.AirportName, airpotObj.AirportCity, airpotObj.AirportState, airpotObj.AirportLong.ToString(), airpotObj.AirportLat.ToString());
                String prefix = "INSERT INTO Airports_CS " + "(AirportId, AirportName, AirportCity, AirportState, AirportLong, AirportLat) ";
                command = prefix + sb.ToString();

                return command;
            }
            else if (currobject is Flight)
            {
                Flight flightObj = currobject as Flight;
                sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", flightObj.FlightId, flightObj.From, flightObj.To, flightObj.StartDate.ToString("MM/dd/yyyy HH:mm:ss"), flightObj.EndDate.ToString("MM/dd/yyyy HH:mm:ss"), flightObj.Price.ToString(), flightObj.Stops, flightObj.TravelTime);
                String prefix = "INSERT INTO MyFlights_CS " + "(FlightId, DepartureAirportId, ArivalAirportId, DepartureTime, ArivalTime, Price, StopsNo, TravelTime) ";
                command = prefix + sb.ToString();

                return command;
            }
            else if (currobject is Leg)
            {
                Leg legObj = currobject as Leg;
                sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", legObj.LegId, legObj.LegFlightId, legObj.LegNum, legObj.LegFlightNo.ToString(), legObj.LegDepartureAirport, legObj.LegArivalAirport, legObj.LegAirlineId, legObj.LegDepartureTime.ToString("MM/dd/yyyy HH:mm:ss"), legObj.LegArivalTime.ToString("MM/dd/yyyy HH:mm:ss"), legObj.LegFlightLength);
                String prefix = "INSERT INTO Legs_CS " + "(LegId, LegFlightId, LegNo, LegFlightNo, LegDepartureAirportId, LegArivalAirportId, LegAirlineId, LegDepartureTime, LegArivalTime, LegFlightTime) ";
                command = prefix + sb.ToString();

                return command;
            }
            else if (currobject is Discount)
            {
                Discount discountObj = currobject as Discount;
                sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}','{4}','{5}','{6}')", discountObj.DiscountId, discountObj.AirlineCode, discountObj.AirportFrom, discountObj.AirportTo, discountObj.DateFrom.ToString("MM/dd/yyyy HH:mm:ss"), discountObj.DateTo.ToString("MM/dd/yyyy HH:mm:ss"), discountObj.DiscountValue);
                String prefix = "INSERT INTO  Discount_CS " + "(DiscountId, AirlineCode, AirportFrom, AirportTo, DateFrom, DateTo, DiscountValue) ";
                command = prefix + sb.ToString();
                return command;
            }
            else if (currobject is Order)
            {
                Order orderObj = currobject as Order;
                sb.AppendFormat("Values('{0}', '{1}', '{2}')", orderObj.PassengersNames, orderObj.PassengerEmail, orderObj.OrderDate.ToString("MM/dd/yyyy HH:mm:ss"));
                String prefix = "INSERT INTO Orders_CS " + "(PassengersNames, PassengerEmail, OrderDate) ";
                command = prefix + sb.ToString();
                return command;
            }
            else if (currobject is TourCompany)
            {
                TourCompany tourCompanyObj = currobject as TourCompany;
                sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}')", tourCompanyObj.CompanyUserName, tourCompanyObj.CompanyPassword, tourCompanyObj.CompanyName, tourCompanyObj.CompanyEmail);
                String prefix = "INSERT INTO TourCompaniesUsers_CS " + "(CompanyUserName, CompanyPassword , CompanyName, CompanyEmail) ";
                command = prefix + sb.ToString();
                return command;
            }
            else if (currobject is Tour)
            {
                Tour tourObj = currobject as Tour;
                sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3},{4}', '{5}', '{6}', '{7}')", tourObj.TourId,tourObj.TourLength,tourObj.TourPrice,tourObj.Country,tourObj.City,tourObj.TourTitle,tourObj.TourDescription,tourObj.ImgURL);
                String prefix = "INSERT INTO TourCompaniesUsers_CS " + "(TourId , TourLength  , TourPrice  ,Country  , City   , TourTitle , TourDescription ,TourImgURL ) ";
                command = prefix + sb.ToString();
                return command;
            }
            else
            {
                return "0";
            }
            
        }
        //---------------------------------------------------------------------------------
        // Create the SqlCommand
        //---------------------------------------------------------------------------------
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }
        public List<Discount> getDiscount()
        {
            SqlConnection con = null;

            try
            {

                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from Discount_CS";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                List<Discount> list = new List<Discount>();
                while (dr.Read())
                {   // Read till the end of the data into a row
                    Discount discount = new Discount();
                    discount.DiscountId = (int)dr["DiscountId"];
                    discount.AirlineCode = (string)dr["AirlineCode"];
                    discount.AirportFrom = (string)dr["AirportFrom"];
                    discount.AirportTo = (string)dr["AirportTo"];
                    discount.DateFrom = (DateTime)dr["DateFrom"];
                    discount.DateTo = (DateTime)dr["DateTo"]; 
                    discount.DiscountValue = (int)dr["discountValue"];
                    list.Add(discount);
                }
                return list;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }
        public List<Tour> getTours()
        {
            SqlConnection con = null;
            string companyName = (string)(HttpContext.Current.Session["companyName"]);
            try
            {

                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from Tour_CS";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                List<Tour> list = new List<Tour>();
                while (dr.Read())
                {   // Read till the end of the data into a row
                    Tour tour = new Tour();
                    tour.TourId = (int)dr["TourId"];
                    tour.TourLength = (int)dr["TourLength"];
                    tour.TourPrice = (int)dr["TourPrice"];
                    tour.TourSupplier = (string)dr["TourSupplier"];
                    tour.Country = (string)dr["Country"];
                    tour.City = (string)dr["City"];
                    tour.TourDescription = (string)dr["TourDescription"];
                    tour.ImgURL = (string)dr["TourImgURL"];
                    if (tour.TourSupplier == "All") {
                        list.Add(tour);
                    }
                    else if (tour.TourSupplier != companyName)
                    {
                        continue;
                    }
                    else
                    {
                        list.Add(tour);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }


        public List<Order> getOrder()
        {
            SqlConnection con = null;

            try
            {

                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from Orders_CS";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader 
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                List<Order> list = new List<Order>();
                while (dr.Read())
                {   // Read till the end of the data into a row
                    Order order = new Order();
                    order.OrderId = (int)dr["OrderId"];
                    order.PassengersNames = (string)dr["PassengersNames"];
                    order.PassengerEmail = (string)dr["PassengerEmail"];
                    order.OrderDate = (DateTime)dr["OrderDate"];
                    list.Add(order);
                }
                return list;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        public List<User> getUsers()
        {
            List<User> userList = new List<User>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Users_CS";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    User currUser = new User();

                    currUser.UserType = (string)dr["userType"];
                    currUser.UserName = (string)dr["userName"];
                    currUser.UserPassword = (string)dr["userPassword"];
                    userList.Add(currUser);
                }

                return userList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        public List<TourCompany> getCompanies()
        {
            List<TourCompany> tourCompanyList = new List<TourCompany>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM TourCompaniesUsers_CS";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    TourCompany currTourCompany = new TourCompany();

                    currTourCompany.CompanyUserName = (string)dr["CompanyUserName"];
                    currTourCompany.CompanyPassword = (string)dr["CompanyPassword"];
                    currTourCompany.CompanyName = (string)dr["CompanyName"];
                    currTourCompany.CompanyEmail = (string)dr["CompanyEmail"];
                    tourCompanyList.Add(currTourCompany);
                }

                return tourCompanyList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }
    }
}

