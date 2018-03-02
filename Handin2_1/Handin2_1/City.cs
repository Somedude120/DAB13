using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    
    public class City
    {

        public virtual string streetname { get; set; }
        public virtual int housenumber { get; set; }
        public virtual string cityname { get; set; }
        public virtual int zipcode { get; set; }

        public virtual Personindex index { get; set; }

    }
}
