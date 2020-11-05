using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin8AvionskiSaobracajVezba.DAO;
using Termin8AvionskiSaobracajVezba.Model;

namespace Termin8AvionskiSaobracajVezba.UI
{
    class AirportUI
    {
        public static void IspisiMeni()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Airports service - options:");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\tOption 1 - All airports");
            Console.WriteLine("\tOption 2 - New airport");
            Console.WriteLine("\tOption 3 - Delete airport");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOption 0 - OUT");
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
                        Console.WriteLine("Out!");
                        break;
                    case 1:
                        IspisiSveAerodrome();
                        break;
                    case 2:
                        UnosNovogAerodroma();
                        break;
                    case 3:
                        BrisanjeAerodroma();
                        break;
                    default:
                        break;
                }

            }
        }
        //METODA ZA ISPIS AVIONA
        public static void IspisiSveAerodrome()
        {
            List<Airport> airports = AirportDAO.GetAll();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\tAll airports:");
            Console.WriteLine("-----------------------------------------------------");
            foreach (Airport airport in airports)
            {
                Console.WriteLine(airport);
                Console.WriteLine("-----------------------------------------------------");
            }
        }
        //METODE ZA PRETRAGU AVIONA 
        public static Airport PronadjiAerodromPoId(int id)
        {
            Airport retVal = AirportDAO.GetAerodromById(id);
            return retVal;

        }
        public static Airport PronadjiAerodromPoId()
        {
            Airport retVal = null;
            Console.Write("Enter airplane id :");
            int id = IOPomocnaKlasa.OcitajCeoBroj();
            retVal = PronadjiAerodromPoId(id);
            if (retVal == null)
            {
                Console.WriteLine("Airport with id:" + id + " doesn't exist!");
            }
            return retVal;
        }
        public static Airport PronajdiAerodromPoNazivu(string naziv)
        {
            Airport airport = AirportDAO.GetAerodromByName(naziv);
            return airport;
        }
        public static Airport PronajdiAerodromPoNazivu()
        {
            Airport retVal = null;
            Console.WriteLine("Enter airport name:");
            string name = IOPomocnaKlasa.OcitajTekst();
            retVal = PronajdiAerodromPoNazivu(name);
            if (retVal == null)
            {
                Console.WriteLine("Airport with name:" + name + " doesn't exist!");
            }
            return retVal;
        }
        //METODE ZA UNOS I BIRSANJE aerodroma
        public static void UnosNovogAerodroma()
        {
            Console.WriteLine("Enter airport name:");
            string stName = IOPomocnaKlasa.OcitajTekst();
            stName = stName.ToUpper();
            while (PronajdiAerodromPoNazivu(stName) != null)
            {
                Console.WriteLine("Airport with name:" + stName + " already exist!");
                stName = IOPomocnaKlasa.OcitajTekst();
            }
            Console.WriteLine("Enter airport city:");
            string city = IOPomocnaKlasa.OcitajTekst();
            Console.WriteLine("Enter airport country:");
            string country = IOPomocnaKlasa.OcitajTekst();
            Airport airport = new Airport(0, stName, city, country);
            AirportDAO.Add(airport);
        }
        public static void BrisanjeAerodroma()
        {
            IspisiSveAerodrome();
            Airport airport = PronadjiAerodromPoId();
            if (airport != null)
            {
                AirportDAO.Delete(airport.Id);
            }
        }

    }
}
