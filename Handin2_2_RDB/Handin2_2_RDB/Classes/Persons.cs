using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Handin2_2_RDB.Classes
{
    public class Persons
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public List<Phone> PhoneList { get; set; }
        //En til mange relation mellem addresserne
        public Address AddressList { get; set; }
        //Kontakterne skal have en til mange da kun en kontakt kan kun have en person
        public virtual List<Contacts> ContactList { get; set; }
    }
}