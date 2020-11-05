using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin8AvionskiSaobracajVezba.DAO;
using Termin8AvionskiSaobracajVezba.UI;

namespace Termin8AvionskiSaobracajVezba
{
    class Program
    {

        //public static SqlConnection conn;

        public static string connectionString = @"Data Source=DESKTOP-GC0HF6E\SQLEXPRESS;Initial Catalog=DotNetMilos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //static void LoadConnection()
        //{
        //    string connectionString = @"Data Source=DESKTOP-GC0HF6E\SQLEXPRESS;Initial Catalog=DotNetMilos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    try
        //    {

        //        conn = new SqlConnection(connectionString);
        //        conn.Open();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }

        //}

        static void Main(string[] args)
        {
            //LoadConnection();
            AplikacijaUI.Meni();

            Console.ReadKey();
        }
    }
}
