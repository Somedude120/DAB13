using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Handin3_2.Models
{
    public class PersonDTO
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }

        public PhoneDTO Phone { get; set; }
    }
}