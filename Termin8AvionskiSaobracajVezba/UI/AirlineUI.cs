using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin8AvionskiSaobracajVezba.DAO;
using Termin8AvionskiSaobracajVezba.Model;

namespace Termin8AvionskiSaobracajVezba.UI
{
    class AirlineUI
    {

        public static void IspisiMeni()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Airlines - options:");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\tOptions 1 - All airlines");
            Console.WriteLine("\tOption  2 - New airline");
            Console.WriteLine("\tOption  3 - Delete airline");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOption  0 - OUT");
            Console.WriteLine("-----------------------------------------------------");
        }


        public static void Meni()
        {
            int odluka = -1;
            while (odluka != 0)
            {
                IspisiMeni();
                Console.Write("Opcija:");
                odluka = IOPomocnaKlasa.OcitajCeoBroj();
                Console.Clear();
                switch (odluka)
                {
                    case 0:
                        Console.WriteLine("Izlaz");
                        break;
                    case 1:
                        IspisiSveLetove();
                        break;
                    case 2:
                        UnesiLiniju();
                        break;
                    case 3:
                        BrisanjeLeta();
                        break;
                    default:
                        break;
                }

            }
        }

        public static void IspisiSveLetove()
        {
            List<Airline> airlines = AirlineDAO.GetAll();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\tAll airlines: ");
            Console.WriteLine("-----------------------------------------------------");
            foreach(Airline airline in airlines.OrderBy(x => x.Id))
            {
                Console.WriteLine(airline);
                Console.WriteLine("-------------------------------------------------");
            }
        }

        public static Airline PronadjiLetPoId(int id)
        {
            Airline airline = AirlineDAO.GetLetById(id);
               return airline;
        }

        public static Airline PreuzmiLetPoId()
        {
            Airline airline = null;
            Console.WriteLine("Enter airline id: ");
            int id = IOPomocnaKlasa.OcitajCeoBroj();
            airline = PronadjiLetPoId(id);
            if(airline == null)
            {
                Console.WriteLine("Airline with Id: {0} doesn't exist!", airline.Id);

            }
            return airline;
        }
        //metode za unos i brisanje
        public static void UnesiLiniju()
        {
            IspisiSveLetove();

            Airline airline = new Airline();
            airline.Id = 0;
            Console.WriteLine("Enter the airline name: ");
            string aName = Console.ReadLine();
            airline.Name = aName;
            
            AirplaneUI.IspisiSveAvione();
            Console.WriteLine("Choose airplane id you want to fly:");
            string aId = Console.ReadLine();
            int idAviona;
            bool provera = IOPomocnaKlasa.ProveraDaLiJeBr(aId);
            if (provera == true)
            {
                idAviona = int.Parse(aId);
                airline.Airplane = AirplaneDAO.GetAvionById(idAviona);
            }
            AirportUI.IspisiSveAerodrome();
            Console.WriteLine("Choose id of departure airport:");
            string aId1 = Console.ReadLine();
            int idAerodromaPoletanje;
            bool provera1 = IOPomocnaKlasa.ProveraDaLiJeBr(aId1);
            if (provera1 == true)
            {
                idAerodromaPoletanje = int.Parse(aId1);
                airline.AirportDeparture = AirportDAO.GetAerodromById(idAerodromaPoletanje);
            }
            AirportUI.IspisiSveAerodrome();
            Console.WriteLine("Choose id of destination airport:");
            string aId2 = Console.ReadLine();
            int idAerodromaSletanje;
            bool provera2 = IOPomocnaKlasa.ProveraDaLiJeBr(aId2);
            if (provera2 == true)
            {
                idAerodromaSletanje = int.Parse(aId2);
                airline.AirportDestination = AirportDAO.GetAerodromById(idAerodromaSletanje);
            }
            if (airline.AirportDeparture.Equals(airline.AirportDestination))
            {
                Console.WriteLine("You cannot take off and land at the same airport!");
            }
            else
            {
                AirlineDAO.Add(airline);
            }



        }
        public static void BrisanjeLeta()
        {
            IspisiSveLetove();
            Airline airline = PreuzmiLetPoId();
            if (airline != null)
            {
                AirlineDAO.Delete(airline.Id);
            }
        }

    }
}
