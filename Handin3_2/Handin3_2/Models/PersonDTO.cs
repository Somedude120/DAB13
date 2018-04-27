using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Handin3_2.Models;

public class PersonDTO
{
    public PersonDTO()
    { }

    //public PersonDTO(Person person)
    //{
    //    PersonId = person.PersonId;
    //    FirstName = person.Name;
    //    MiddleName = person.MiddleName;
    //    LastName = person.SurName;
    //    Email = person.Email;
    //    PhoneNumbers = new List<PhoneDTO>();

    //}

    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string Street { get; set; }

    public IEnumerable<PhoneDTO> PhoneNumbers { get; set; }
    

}