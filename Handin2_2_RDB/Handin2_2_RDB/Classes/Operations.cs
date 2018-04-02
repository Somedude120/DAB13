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
            var phoneList = new List<Phone>();
            try
            {
                //----------------------
                //Test rum

                //----------------------
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
                //Lav adressen og tilføj personen til adressen
                var place = new Address { Placement = address };

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

                //Lav telefon
                Console.WriteLine("Enter Phoneinfo");
                var phoneinfo = Console.ReadLine();
                if (phoneinfo == "")
                {
                    phoneinfo = "N/A";
                }

                Console.WriteLine("Enter Phonenumber");
                var phonenumber = Console.ReadLine();
                if (phonenumber == "")
                {
                    phonenumber = "N/A";
                }

                var phone = new Phone{Info = phoneinfo,Number = phonenumber};
                db.Phones.Add(phone);

                Console.WriteLine("Please wait while adding to database.");
                //Lav personen med addressen og telefon
                var person = new Persons { Name = name, MiddleName = middlename, SurName = surname, Email = email, AddressList = place, PhoneList = phoneList};
                db.People.Add(person);
                //Tilføj til listen
                personList.Add(person);
                phoneList.Add(phone);

                db.SaveChanges();

                //Tilføj en kontakt som binder det hele sammen
                var contacts = new Contacts { Address = place, PersonList = personList,PhoneList = phoneList};
                db.Contacts.Add(contacts);
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
                Console.WriteLine("For Prototype Purpose, Only 3 Prompts: 1. Name, 2. City, 3. PhoneInfo.");
                Console.WriteLine("Enter Id to Update Name:");
                var id = Convert.ToInt32(Console.ReadLine());
                foreach (Persons e in db.People)
                {

                    if (e.PersonId == id)

                    {
                        Console.WriteLine("Enter New Name:");
                        var name = Console.ReadLine();
                        e.Name = name;
                        

                        Console.WriteLine("Enter New City:");
                        var location = Console.ReadLine();
                        e.ContactList[0].Address.Placement.CityName = location;

                        Console.WriteLine("Enter New Phoneinfo:");
                        var phoneinfo = Console.ReadLine();
                        e.PhoneList[0].Info = phoneinfo;

                        Console.WriteLine($"Update Successfully on id {e.PersonId}");
                        
                        break;

                    }
                    
                }
                db.SaveChanges();

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

                    Console.WriteLine($"Phone ID: {e.PhoneList[0].PhoneId}");
                    Console.WriteLine($"Phone Number: {e.PhoneList[0].Number}");
                    Console.WriteLine($"Phone Info: {e.PhoneList[0].Info}");

                    Console.WriteLine($"City ID: {e.ContactList[0].Address.Placement.CityId}");
                    Console.WriteLine($"City Name: {e.ContactList[0].Address.Placement.CityName}");
                    Console.WriteLine($"City Streetname: {e.ContactList[0].Address.Placement.StreetName}");
                    Console.WriteLine($"City Housenumber: {e.ContactList[0].Address.Placement.HouseNumber}");
                    Console.WriteLine($"City Zipcode: {e.ContactList[0].Address.Placement.ZipCode}");

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