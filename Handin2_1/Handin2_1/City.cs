using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    
    public class City
    {

        private List<int> zipcode { get; set; }


        public virtual string streetname { get; set; }
        public virtual int housenumber { get; set; }

        public virtual string cityname { get; set; }
        //tilføj en zipcode
        public virtual void addzipcode(int citynumber)
        {
            zipcode.Add(citynumber);
        }

        //Fjern en zipcode
        public virtual void removezipcode(int citynumber)
        {
            zipcode.Remove(citynumber);
        }

    }
}
