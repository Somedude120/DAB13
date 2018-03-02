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
        public List<City> Cities { get; set; }
        public virtual int adressId { get; set; }
        public virtual string contact { get; set; }

        public virtual Personindex index { get; set; }
    }
}
