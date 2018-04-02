using System;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using DocumentDBGettingStarted.Classes;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace DocumentDBGettingStarted.Tasks
{
    public class Operations : IOperations
    {
        public void AddContact()
        {
            Console.WriteLine("Insert Everything in a contact");
            //Kontakt har alt inde i maven
            Contacts Contact = new Contacts()
            { 
                Id = "1",
                //Person kommer ind her
                Person = new Persons[]
                {
                    new Persons(){FirstName = Console.ReadLine(), MiddleName = Console.ReadLine(), SurName = Console.ReadLine(), Email = Console.ReadLine(),
                    //Telefon er en del af personen
                        Phone = new Phones[]
                                    {
                                            new Phones { PhoneInfo = Console.ReadLine() },
                                            new Phones { PhoneInfo = Console.ReadLine() }
                                    }
                        },
                },
                //Kontakt adressen ligger under Kontakt
                Address = new Addresses[]
                {
                    new Addresses {CityName = Console.ReadLine(), StreetName = Console.ReadLine(), HouseNumber = Console.ReadLine(),Zipcode = Console.ReadLine()}
                },
                AltAddress = new AltAddresses[]
                {
                    new AltAddresses{CityName = Console.ReadLine(),Zipcode = Console.ReadLine(), StreetName = Console.ReadLine()}
                },
                IsRegistered = true,

            };
            
        }

        public void ViewContact()
        {

        }

        public void UpdateContact()
        {

        }

        public void DeleteContact()
        {

        }
    }
}