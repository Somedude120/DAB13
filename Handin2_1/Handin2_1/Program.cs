using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ideen med POCO klasser er at de er simple datastrukturer som ikke har nogen form for tilknytning til hinanden
//Derfor viser jeg her de 3 klasser + main at klasserne er bygget og senere hen skal handin 2 tilknyttes
//Til hinanden så systemet faktisk giver mening.

namespace Handin2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Personindex Hans = new Personindex();
            Contact Contacts = new Contact();
            Address Addresses = new Address();
            City Cities = new City();
            Telephone Phones = new Telephone();
            City Streetname = new City();
            Streetname.cityname = "Dusselstrasse";

            Phones.homenumber = new List<int>();//Opretter ny liste til homenumbers

            string HansName = Contacts.firstname = "Hans"; //Tilføj navn
            string HansCity = Cities.cityname = "Dusseldorf"; //Tilføj by
            string HansStreet = Streetname.cityname; //Tilføj gade
            Phones.homenumber.Add(55); //Tilføj til homenumber listen
            int HansPhone = Phones.homenumber[0];
            string HansMail = Hans.Email = "SSZuge@gmail.com";

            Console.WriteLine($"Name: {HansName}\nStreet: {HansStreet}\nCity: {HansCity}\nPhones: {HansPhone}\nEmail: {HansMail}");
        }
    }

}
