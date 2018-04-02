using Handin2_2_RDB.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using Handin2_2_RDB.Main.Interface;

namespace Handin2_2_RDB.Classes
{
    public class Operations : IOperations
    {
        public void AddContact(PersonIndexContext db)
        {
            //Liste til personerne
            var personList = new List<Persons>();
            var contactList = new List<Contacts>();
            try
            {
                Console.WriteLine("Enter Address: Streetname, City, number");

                Console.WriteLine("Enter Streetname");
                var street = Console.ReadLine();
                Console.WriteLine("Enter Cityname");
                var city = Console.ReadLine();
                Console.WriteLine("Enter Housenumber");
                var number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Zipcode");
                var zip = Convert.ToInt32(Console.ReadLine());
                //Lav byen
                var address = new City { StreetName = street, CityName = city, HouseNumber = number, ZipCode = zip };
                db.Cities.Add(address);

                db.SaveChanges();

                Console.WriteLine("Testline");
                ////Lav adressen og tilføj personen til adressen
                var place = new Address { Placement = address };

                //Tilføj en kontakt som binder det hele sammen
                var contacts = new Contacts { Address = place, PersonList = personList };
                db.Contacts.Add(contacts);

                db.SaveChanges();


                Console.WriteLine("Enter a name, middlename, surname and email for a new Person: ");
                Console.WriteLine("Enter First Name");
                var name = Console.ReadLine();

                Console.WriteLine("Enter Middlename");
                var middlename = Console.ReadLine();
                if (middlename == "")
                {
                    middlename = "N/A";
                }
                Console.WriteLine("Enter Surname");
                var surname = Console.ReadLine();
                if (surname == "")
                {
                    surname = "N/A";
                }

                Console.WriteLine("Enter Email");
                var email = Console.ReadLine();
                if (email == "")
                {
                    email = "N/A";
                }
                Console.WriteLine("Please wait while adding to database.");
                //Lav personen
                //Add et nyt navn til DB
                var person = new Persons { Name = name, MiddleName = middlename, SurName = surname, Email = email, AddressList = place};
                db.People.Add(person);
                //Tilføj til listen
                personList.Add(person);

                db.SaveChanges();

                


            }

            catch (Exception e)

            {
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateContact(PersonIndexContext db)
        {
            try
            {

                Console.WriteLine("Enter Id to Update Name:");
                var id = Convert.ToInt32(Console.ReadLine());
                foreach (Persons e in db.People)
                {

                    if (e.PersonId == id)

                    {
                        Console.WriteLine("Enter New Name:");
                        var name = Console.ReadLine();
                        var person = db.People.First<Persons>();
                        person.Name = name;
                        Console.WriteLine($"Update Successfully on id {e.PersonId}");
                        db.SaveChanges();
                        break;

                    }

                }

            }

            catch (Exception e)

            {

                Console.WriteLine(e.Message);

            }
        }

        public void ViewContact(PersonIndexContext db)
        {
            try

            {



                foreach (Persons e in db.People)

                {

                    Console.WriteLine($"-----------------------------");
                    Console.WriteLine($"ID: {e.PersonId}");
                    Console.WriteLine($"Firstname: {e.Name}");
                    Console.WriteLine($"Middlename: {e.MiddleName}");
                    Console.WriteLine($"Surname: {e.SurName}");
                    Console.WriteLine($"Email: {e.Email}");
                    Console.WriteLine($"City: {e.ContactList[0].Address.Placement.CityName}");

                }

            }

            catch (Exception e)

            {

                Console.WriteLine(e.Message);

            }
        }

        public void DeleteContact(PersonIndexContext db)
        {
            Console.WriteLine("Enter Id to delete:");
 
            var id = Convert.ToInt32(Console.ReadLine());
            var person = new Persons { PersonId = id};

            db.People.Attach(person);
            db.People.Remove(person);
                    db.SaveChanges();
                    Console.WriteLine($"delete Successfully of {id}");

        }
    }
}