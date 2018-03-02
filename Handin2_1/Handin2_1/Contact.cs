using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_1
{
    public class Contact
    {
        public virtual int PersonId { get; set; }
        public virtual string firstname { get; set; }
        public virtual string middlename { get; set; }
        public virtual string surname { get; set; }
        public virtual string type { get; set; }

        public virtual Personindex index { get; set; }//ref til index
    }
    
}
