using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Handin2_2_RDB.Classes
{
    public class AltAddress
    {
        [Key]
        
        public string City { get; set; }
        public string Type { get; set; }
        public List<Contacts> Contacts { get; set; }
    }
}