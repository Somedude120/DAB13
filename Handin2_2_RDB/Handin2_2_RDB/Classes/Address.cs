using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Handin2_2_RDB.Classes
{
    public class Address
    {
        [Key]
        //private string _city;
        //private List<Contacts> _contactlListist;

        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public List<Contacts> ContactList { get; set; }
    }
}