using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin8AvionskiSaobracajVezba.Model;

namespace Termin8AvionskiSaobracajVezba.DAO
{
    class AirportDAO
    {

        public static Airport GetAerodromByName(string name)
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            Airport airport = null;
            try
            {
                conn.Open();
                string query = "select id, name, city, country from Airports where name='" + name + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    int id = (int)rdr["id"];
                    string city = (string)rdr["city"];
                    string country = (string)rdr["country"];


                    airport = new Airport(id, name, city, country);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return airport;
        }
        public static Airport GetAerodromById(int id)
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            Airport airport = null;
            try
            {

                conn.Open();
                string query = "select id, name, city, country from Airports where id=" + id;

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    int idA = (int)rdr["id"];
                    string name = (string)rdr["name"];
                    string city = (string)rdr["city"];
                    string country = (string)rdr["country"];

                    airport = new Airport(idA, name, city, country);
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return airport;
        }

        public static List<Airport> GetAll()
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            List<Airport> airports = new List<Airport>();
            try
            {

                conn.Open();
                string query = "select id, name, city, country from Airports";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    int id = (int)rdr[0];
                    string name = (string)rdr[1];
                    string city = (string)rdr[2];
                    string country = (string)rdr[3];

                    Airport airport = new Airport(id, name, city, country);
                    airports.Add(airport);
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return airports;
        }
        public static bool Add(Airport airport)
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            bool retVal = false;
            try
            {
                conn.Open();
                string query = "insert into Airports (name,city,country) " +
                    "values (@name,@city,@country)";
                SqlCommand cmd = new SqlCommand(query, conn);


                cmd.Parameters.AddWithValue("@name", airport.Name);
                cmd.Parameters.AddWithValue("@city", airport.City);
                cmd.Parameters.AddWithValue("@country", airport.Country);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    retVal = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return retVal;
        }
        public static bool Delete( int id)
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            bool retVal = false;
            try
            {
                conn.Open();
                string query = "delete from Airports where id=" + id;
                SqlCommand cmd = new SqlCommand(query, conn);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    retVal = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return retVal;
        }
    }
}
