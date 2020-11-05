using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin8AvionskiSaobracajVezba.Model
{
    class Airline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Airplane Airplane { get; set; }
        public Airport AirportDeparture { get; set; }
        public Airport AirportDestination { get; set; }

        public Airline()
        {

        }

        public Airline(int id, string name, Airplane airplane, Airport airportDeparture, Airport airportDestination)
        {
            Id = id;
            Name = name;
            Airplane = airplane;
            AirportDeparture = airportDeparture;
            AirportDestination = airportDestination;
        }

        //public override string ToString()
        //{
        //    string returnValue = "Flight [" + "\nID: " + Id + " " + "\nRoute: " + Name + " " + "\nAirplane: " + Airplane.Model + " " 
        //        + "\nDeporture: " + AirportDeparture.Name + " " + "\nTo: " + AirportDestination.Name;

        //    return returnValue;
        //}

        public override string ToString()
        {
            string ispis = string.Format("\t\tLet [id:{0}]\n\tIme leta:{1}", Id, Name);
            string ispis2 = string.Format("Aerodrom [POLETANJE]:\n\t[Id:{0}]\n\tIme:{1}\n\tGrad:{2}\n\tDrzava:{3}", AirportDeparture.Id, AirportDeparture.Name, AirportDeparture.City, AirportDeparture.Country);
            string ispis3 = string.Format("Aerodrom [SLETANJE]:\n\t[Id:{0}]\n\tIme:{1}\n\tGrad:{2}\n\tDrzava:{3}", AirportDestination.Id, AirportDestination.Name, AirportDestination.City, AirportDestination.Country);
            string ispis1 = string.Format("Avion:\n\t[Id:{0}]\n\tModel aviona:{1}\n\tKapacitet:{2}\n\tIme:{3}", Airplane.Id, Airplane.Model, Airplane.Capacity, Airplane.Name);


            string konacanispis = ispis + "\n" + ispis1 + "\n" + ispis2 + "\n" + ispis3;

            return konacanispis;
        }

    }
}
