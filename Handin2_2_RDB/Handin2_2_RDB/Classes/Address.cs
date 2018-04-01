using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Handin2_2_RDB.Classes
{
    public class Address
    {
        [Key]
        //private string _city;
        //private List<Contacts> _contactlListist;
        public int AddressId { get; set; }

        //public string City { get; set; }

        //Lav en en til en key
        public virtual City Placement { get; set; }
        //public List<Contacts> ContactList { get; set; }
        //Der kan komme mange til addressen, men personen kan kun have 1 adresse
        //public List<Persons> PersonList { get; set; }
    }
}