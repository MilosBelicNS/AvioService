using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin8AvionskiSaobracajVezba.Model;

namespace Termin8AvionskiSaobracajVezba.DAO
{
    class AirlineDAO
    {

        public static Airline GetLetById(int id)
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            Airline airline = null;
            try
            {
                conn.Open();
                string query = "select name, airplane, departureAirport, destinationAirport from Airlines where id=" + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    string name = (string)rdr["name"];
                    Airplane airplane = AirplaneDAO.GetAvionById(id);
                    Airport departureAirport = AirportDAO.GetAerodromById(id);
                    Airport destinationAirport = AirportDAO.GetAerodromById(id);
                    airline = new Airline(id, name, airplane, departureAirport, destinationAirport);
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
            return airline;
        }
        public static List<Airline> GetAll()
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            List<Airline> airlines = new List<Airline>();
            try
            {
                conn.Open();
                string query = "select id, name, airplane, departureAirport, destinationAirport from Airlines";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["id"];
                    string imeLeta = (string)rdr["name"];
                    int avion = (int)rdr["airplane"];
                    Airplane airplane = AirplaneDAO.GetAvionById(avion);
                    int id_aerodrom_poletanje = (int)rdr["departureAirport"];
                    int id_aerodrom_sletanje = (int)rdr["destinationAirport"];

                        Airport aerodrom_poletanje = AirportDAO.GetAerodromById(id_aerodrom_poletanje);
                        Airport aerodrom_sletanje = AirportDAO.GetAerodromById(id_aerodrom_sletanje);
                    
                    Airline airline = new Airline(id, imeLeta, airplane, aerodrom_poletanje, aerodrom_sletanje);
                    airlines.Add(airline);
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
            return airlines;
        }
        public static bool Add(Airline airline)
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            bool retVal = false;
            try
            {

                conn.Open();
                string query = "insert into Airlines (name,airplane,departureAirport, destinationAirport)" +
                    "values (@name,@airplane,@departureAirport,@destinationAirport)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@name", airline.Name);
                cmd.Parameters.AddWithValue("@airplane", airline.Airplane.Id);
                cmd.Parameters.AddWithValue("@departureAirport", airline.AirportDeparture.Id);
                cmd.Parameters.AddWithValue("@destinationAirport", airline.AirportDestination.Id);

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
        public static bool Delete(int id)
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            bool retVal = false;
            try
            {

                conn.Open();
                string query = "delete from Airlines where id=" + id;
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
