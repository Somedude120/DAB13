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
        //Der kan være mange der har en telefon og man kan dele dem hvis der er en arbejdstelefon
        public List<Phone> PhoneList { get; set; }
        //Der kan komme mange til addressen, men personen kan kun have 1 adresse
        public virtual Address Address { get; set; }
        //Der kan komme mange til mange alternativ addresse
        public virtual List<AltAddress> AltAddress { get; set; }
        
    }
}