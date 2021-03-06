﻿using System.Collections.Generic;

namespace Handin3_2.Models
{
    public class PhoneDTO
    {
        public int PhoneId { get; set; }
        public string Number { get; set; }
        public string Info { get; set; }
        public int? ContactsId { get; set; }

        public IEnumerable<SimplePersonIdDTO> Persons { get; set; }
    }
}