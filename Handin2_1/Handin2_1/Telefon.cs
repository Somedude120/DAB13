using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class Telephone
    {
        public virtual int TelephoneId { get; set; }

        public virtual int number { get; set; }

        public virtual List<int> homenumber { get; set; }
        public virtual List<int> worknumber { get; set; }
        public virtual List<int> mobilenumber { get; set; }

       
    }
}
