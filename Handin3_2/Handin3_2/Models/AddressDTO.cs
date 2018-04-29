using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Handin3_2.Models
{
    public class AddressDTO
    {
        //En person skal tilsættes en addresse? Men det gør han allerede i Person? Så den skal vel vise hvem bor på addressen
        //public virtual IEnumerable<ContactDTO> Contacts { get; set; }
        public int AddressId { get; set; }
        public virtual int CityID { get; set; }
        public virtual string CityName { get; set; }
        public virtual string CityStreet { get; set; }
        public virtual int CityZip { get; set; }
        public virtual int CityHouseNr { get; set; }
        public virtual IEnumerable<SimplePersonDTO> Persons { get; set; }


    }
}