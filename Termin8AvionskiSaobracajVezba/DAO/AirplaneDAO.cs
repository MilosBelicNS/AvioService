using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin8AvionskiSaobracajVezba.Model;

namespace Termin8AvionskiSaobracajVezba.DAO
{
    class AirplaneDAO
    {



        public static Airplane GetAvionByName(string name)
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);

            Airplane airplane = null;
            try
            {
                conn.Open();

                string query = "select id, model, capacity, name from Airplanes where name='" + name + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    int id = (int)rdr[0];
                    string model = (string)rdr[1];
                    int kapacitet = (int)rdr[2];
                    

                    airplane = new Airplane(id, model, kapacitet, name);
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
            return airplane;
        }
        public static Airplane GetAvionById(int id)
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            Airplane airplane = null;
            try
            {
                conn.Open();
                string query = "select id, model, capacity, name from Airplanes where id=" + id;

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    int idA = (int)rdr[0];
                    string model = (string)rdr[1];
                    int kapacitet = (int)rdr[2];
                    string ime = (string)rdr[3];

                    airplane = new Airplane(idA, model, kapacitet, ime);
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
            return airplane;
        }

        public static List<Airplane> GetAll()
        {
            SqlConnection conn = new SqlConnection(Program.connectionString);
            List<Airplane> airplanes = new List<Airplane>();
            try
            {
                conn.Open();
                string query = "select id, model, capacity, name from Airplanes";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr[0];
                    string model = (string)rdr[1];
                    int kapacitet = (int)rdr[2];
                    string ime = (string)rdr[3];

                    Airplane airplane = new Airplane(id, model, kapacitet, ime);
                    airplanes.Add(airplane);
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
            return airplanes;
        }
        public static bool Add(Airplane airplane)
        {
            bool retVal = false;
            SqlConnection conn = new SqlConnection(Program.connectionString);

            try
            {
                

                conn.Open();

                string query = "insert into Airplanes (model,capacity,name) " +
                    "values (@model,@capacity,@name)";
                SqlCommand cmd = new SqlCommand(query, conn);


                cmd.Parameters.AddWithValue("@model", airplane.Model);
                cmd.Parameters.AddWithValue("@capacity", airplane.Capacity);
                cmd.Parameters.AddWithValue("@name", airplane.Name);

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
                string query = "delete from Airplanes where id=" + id;
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
