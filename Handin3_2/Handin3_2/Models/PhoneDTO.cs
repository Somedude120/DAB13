using System.Collections.Generic;

namespace Handin3_2.Models
{
    public class PhoneDTO
    {
        public PhoneDTO()
        {

        }
        public PhoneDTO(Phone phone)
        {
            ICollection<Phone> Phones = new List<Phone>();
            Phones.Add(phone);
        }

        public int PhoneId { get; set; }

        public string Number { get; set; }

        public string Info { get; set; }
    }
}