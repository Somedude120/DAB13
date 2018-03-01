using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class Adresse
    {
        public virtual int adressId { get; set; }
        public virtual string roadName { get; set; }
        public virtual string type { get; set; }
        public virtual string city { get; set; }
        public virtual int houseNumber { get; set; }

        public virtual List<int> zipCode { get; set; }
    }
}
