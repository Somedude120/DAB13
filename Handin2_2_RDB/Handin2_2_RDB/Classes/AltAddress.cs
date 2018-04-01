using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Handin2_2_RDB.Classes
{
    public class AltAddress
    {
        [Key]
        public int AltAddressId { get; set; }
        public List<City> City { get; set; }
        public string Type { get; set; }
        public List<Contacts> Contacts { get; set; }
    }
}