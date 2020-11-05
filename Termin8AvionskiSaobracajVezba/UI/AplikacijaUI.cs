using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin8AvionskiSaobracajVezba.UI
{
    class AplikacijaUI
    {

        public static void IspisiMenu()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\tAir-Traffic-Service - options:");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\tOption  1 - AIRPLANES");
            Console.WriteLine("\tOption  2 - AIRPORTS");
            Console.WriteLine("\tOption  3 - AIRLINES");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOption  0 - END");
            Console.WriteLine("-----------------------------------------------------");

        }
        public static void Meni()
        {
            int odluka = -1;
            while (odluka != 0)
            {
                IspisiMenu();
                Console.Write("Opcija:");
                odluka = IOPomocnaKlasa.OcitajCeoBroj();
                Console.Clear();
                switch (odluka)
                {
                    case 0:
                        Console.WriteLine("Izlaz");
                        break;
                    case 1:
                        AirplaneUI.Meni();
                        break;
                    case 2:
                        AirportUI.Meni();
                        break;
                    case 3:
                        AirlineUI.Meni();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
