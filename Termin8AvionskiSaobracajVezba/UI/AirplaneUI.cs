using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin8AvionskiSaobracajVezba.DAO;
using Termin8AvionskiSaobracajVezba.Model;

namespace Termin8AvionskiSaobracajVezba.UI
{
    class AirplaneUI
    {

        public static void IspisiMeni()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Airplanes service - options:");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\tOption 1 - All airplanes");
            Console.WriteLine("\tOption 2 - New airplane");
            Console.WriteLine("\tOption 3 - Delete airplane");
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
                        IspisiSveAvione();
                        break;
                    case 2:
                        UnosNovogAviona();
                        break;
                    case 3:
                        BrisanjeAviona();
                        break;
                    default:
                        break;
                }

            }
        }
        //METODA ZA ISPIS AVIONA
        public static void IspisiSveAvione()
        {
            List<Airplane> airplanes = AirplaneDAO.GetAll();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\tAll airplanes:");
            Console.WriteLine("-----------------------------------------------------");
            foreach (Airplane avion in airplanes)
            {
                Console.WriteLine(avion);
                Console.WriteLine("-----------------------------------------------------");
            }
        }
        //METODE ZA PRETRAGU AVIONA 
        public static Airplane PronadjiAvionPoId(int id)
        {
            Airplane retVal = AirplaneDAO.GetAvionById(id);
            return retVal;

        }
        public static Airplane PronadjiAvionPoId()
        {
            Airplane retVal = null;
            Console.Write("Enter airplane id :");
            int id = IOPomocnaKlasa.OcitajCeoBroj();
            retVal = PronadjiAvionPoId(id);
            if (retVal == null)
            {
                Console.WriteLine("Airplane with id:" + id + " doesn't exist!");
            }
            return retVal;
        }
        public static Airplane PronajdiAvionPoNazivu(string naziv)
        {
            Airplane airplane = AirplaneDAO.GetAvionByName(naziv);
            return airplane;
        }
        public static Airplane PronajdiAvionPoNazivu()
        {
            Airplane retVal = null;
            Console.WriteLine("Enter airplane name:");
            string name = IOPomocnaKlasa.OcitajTekst();
            retVal = PronajdiAvionPoNazivu(name);
            if (retVal == null)
            {
                Console.WriteLine("Airplane with name:" + name + " doesn't exist!");
            }
            return retVal;
        }
        //METODE ZA UNOS I BIRSANJE AVIONA
        public static void UnosNovogAviona()
        {
            Console.WriteLine("Enter plane name:");
            string stName = IOPomocnaKlasa.OcitajTekst();
            stName = stName.ToUpper();
            while (PronajdiAvionPoNazivu(stName) != null)
            {
                Console.WriteLine("Airplane with name:" + stName + " already exist!");
                stName = IOPomocnaKlasa.OcitajTekst();
            }
            Console.WriteLine("Enter plane capacity:");
            int capacity = IOPomocnaKlasa.OcitajCeoBroj();
            Console.WriteLine("Enter plane model:");
            string stModel = IOPomocnaKlasa.OcitajTekst();
            Airplane airplane = new Airplane(0, stModel, capacity, stName);
            AirplaneDAO.Add(airplane);
        }
        public static void BrisanjeAviona()
        {
            IspisiSveAvione();
            Airplane avion = PronadjiAvionPoId();
            if (avion != null)
            {
                AirplaneDAO.Delete(avion.Id);
            }
        }
    }
}
