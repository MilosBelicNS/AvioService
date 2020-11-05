using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin8AvionskiSaobracajVezba.Model
{
    class Airplane
    {

        public int Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }

        public Airplane()
        {

        }

        public Airplane(int id, string model, int capacity, string name)
        {
            Id = id;
            Model = model;
            Capacity = capacity;
            Name = name;
        }


        public override string ToString()
        {
            string returnValue = "Airplane [" + Id + "]" + " "+ "[" + Model + "]" + " "+ "[" + Capacity + "]" + " "+ "[" + Name + "]";
            return returnValue;
        }
    }
}
