using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Handin2_2_RDB.Classes
{
    public class Phone
    {
        
        [Key]
        public int PhoneId { get; set; }
        public string Number { get; set; }
        public string Info { get; set; }

        public List<Persons> PersonList { get; set; }
    }
}