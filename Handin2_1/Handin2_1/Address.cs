using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class Address
    {
        private List<string> City { get; set; }
        public virtual int adressId { get; set; }
        public virtual string contact { get; set; }

        //Tilføj by i listen byer
        public virtual string cityAdd(City name)
        {
            string cityname = name.cityname;
            City.Add(cityname);

            return cityname;
        }
    }
}
