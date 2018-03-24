﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handin2_2_RDB.Classes;
using Handin2_2_RDB.Context;

namespace Handin2_2_RDB.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new PersonIndexContext())
            {

                //var o_query = from o in db.Organizations
                //              orderby o.OrganizationId
                //              select o;
                //foreach (var o_item in o_query)
                //{
                //    Console.WriteLine("Org: " + o_item.OrganizationName + " Homeland 1: " + o_item.Homelands[0].CountryName + " Homeland 2: " + o_item.Homelands[1].CountryName + " Homeland 3: " + o_item.Homelands[2].CountryName);
                //}




                // Create og save en ny Contact 
                Console.Write("Enter a name for a new Contact: ");
                var name = Console.ReadLine();

                //Add et nyt navn til bloggen DB
                var contact = new Contacts { Name = name };
                db.Contacts.Add(contact);
                db.SaveChanges();

                //Udvidelse af organizationsnavn
                Console.WriteLine("Please enter a phone number.");
                var number = Console.ReadLine();

                //Add nyt navn til organizationstabellen
                var phone = new Phone { Number = number };
                db.Phones.Add(phone);
                db.SaveChanges();

                //Færdig med første udvidelse


                //Anden udvidelse, tilsæt brugernavn til organisationen (tror jeg)
                Console.WriteLine("Enter your username, it will be added to the org");
                var username = Console.ReadLine();

                ////Add nyt navn til brugertabellen
                //var user = new User { Username = username, Organizations = org }; //Tilføjer med reference organizations = org
                //db.Users.Add(user);
                //db.SaveChanges();

                //// Display alle Blogs fra database 
                //var query = from b in db.Blogs
                //            orderby b.Name
                //            select b;

                //Console.WriteLine("All blogs in the database:");
                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.Name);
                //}
                ////Punkt 8, udskriv alle bruger og organizationer

                //var u_query = from u in db.Users
                //              orderby u.Username
                //              select u;

                //Console.WriteLine("Usernames, organizations and orgID");
                //foreach (var u_item in u_query)
                //{
                //    Console.WriteLine("User: " + u_item.Username + " Org: " + u_item.Organizations.OrganizationName + " Org ID: " + u_item.Organizations.OrganizationId);
                //}

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}

