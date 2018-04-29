using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Handin3_2.Models
{
    public class ContactDTO
    {

        public int ContactsId { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Zip { get; set; }
        public int Housenumber { get; set; }
        public int? Address_AddressId { get; set; }

        public IEnumerable<SimplePersonDTO> Persons { get; set; }
        
    }
}