using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Handin2_2_RDB.Classes
{
    public class Contacts
    {

        //private string _name;
        //private string _middlename;
        //private string _surname;
        [Key]
        public int ContactsId { get; set; }
        public string Type { get; set; }
        public List<Persons> PersonList { get; set; }
        public List<Phone> PhoneList { get; set; }
        public List<Address> AddressList { get; set; }
        
    }
}