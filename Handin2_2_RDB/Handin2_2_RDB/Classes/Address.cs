using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Handin2_2_RDB.Classes
{
    public class Address
    {
        [ForeignKey("Placement")]
        public int AddressId { get; set; }
        //[Key]
        //private string _city;
        //private List<Contacts> _contactlListist;
        //Der kan komme mange til addressen, men personen kan kun have 1 adresse
        public virtual List<Persons> PersonList { get; set; }

        //public string City { get; set; }

        //Lav en en til en key, City skal laves før addressen kan findes
        public virtual City Placement { get; set; }
        //public List<Contacts> ContactList { get; set; }
        
    }
}