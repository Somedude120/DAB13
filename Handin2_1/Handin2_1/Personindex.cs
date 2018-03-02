using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Kartotek har 4 klasser
//Contact, Phone, City, Address, AlternativeAddress(Hjælpeklasse til Address)

namespace Handin2_1
{
    public class Personindex
    {
        //1 contact
        //1 Address
        //1 tlf
        //1 Email

        public virtual List<Contact> Contacts { get; set; } //Ref til Contact (1 contact)
        public virtual List<Address> Addresses { get; set; } //Ref til addressen
        public virtual List<Telephone> Phones { get; set; } //Ref til telefoner
        public virtual List<City> Cities { get; set; }
        public virtual string Email { get; set; } //Tilføj den person en email
    }
}
