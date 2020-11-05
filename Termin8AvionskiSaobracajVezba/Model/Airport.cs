using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin8AvionskiSaobracajVezba.Model
{
    class Airport
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


        public Airport()
        {


        }


        public Airport(int id, string name, string city, string country)
        {
            Id = id;
            Name = name;
            City = city;
            Country = country;
        }

        public override string ToString()
        {
            string returnValue = "Airport [" + Id + "]" + " " + "[" + Name + "]" + " " + "[" + City + "]" + " " + "[" + Country + "]";
            return returnValue;
        }

    }
}
