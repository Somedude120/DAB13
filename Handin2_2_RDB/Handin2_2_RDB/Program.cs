﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handin2_2_RDB.Classes;
using Handin2_2_RDB.Context;

/*
 * Welcome to the PersonIndex of Group 13
 * By Daniel and Lisbeth
 */



namespace Handin2_2_RDB.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("HANS mit em flammenwerfer"); //CRUCIAL DO NOT DELETE, IT WILL FUCK UP THE PROGRAM IF REMOVED
            try
            {


                using (var db = new PersonIndexContext())
                {
                    Operations OPS = new Operations();
                    int choice;

                    do
                    {
                        
                        //Tilføjet CRUD
                        Console.WriteLine("\nCRUD OPERATIONS\n--------------");
                        Console.WriteLine("1.Add new Contact");
                        Console.WriteLine("2.View Contacts");
                        Console.WriteLine("3.Update Contact Detail");
                        Console.WriteLine("4.Delete Contact");
                        Console.WriteLine("5.Exit \n");

                        choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                OPS.AddContact(db);
                                break;
                            case 2:
                                OPS.ViewContact(db);
                                break;
                            case 3:
                                OPS.UpdateContact(db);
                                break;
                            case 4:
                                OPS.DeleteContact(db);
                                break;
                        }
                    } while (choice != 5);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"enter valid choice: {e.Message}");
                Console.ReadKey();
            }

            /*
            //var o_query = from o in db.Organizations
            //              orderby o.OrganizationId
            //              select o;
            //foreach (var o_item in o_query)
            //{
            //    Console.WriteLine("Org: " + o_item.OrganizationName + " Homeland 1: " + o_item.Homelands[0].CountryName + " Homeland 2: " + o_item.Homelands[1].CountryName + " Homeland 3: " + o_item.Homelands[2].CountryName);
            //}


            Console.WriteLine("Welcome to Person Index Relational Database");

            // Create og save en ny Contact 
            Console.Write("Enter a name, middlename, surname and email for a new Person: ");
            var name = Console.ReadLine();
            var middlename = Console.ReadLine();
            if (middlename == "")
            {
                middlename = "N/A";
            }
            var surname = Console.ReadLine();
            if (surname == "")
            {
                surname = "N/A";
            }

            var email = Console.ReadLine();
            if (email == "")
            {
                email = "N/A";
            }
            Console.WriteLine("Please wait while adding to database.");
            //Add et nyt navn til bloggen DB
            var person = new Persons { Name = name, MiddleName = middlename, SurName = surname};
            db.People.Add(person);
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
            //Console.WriteLine("Enter your username, it will be added to the org");
            //var username = Console.ReadLine();

            ////Add nyt navn til brugertabellen
            //var user = new User { Username = username, Organizations = org }; //Tilføjer med reference organizations = org
            //db.Users.Add(user);
            //db.SaveChanges();

            // Display alle Blogs fra database 
            var query = from b in db.People
                        orderby b.Name
                        select b;

            Console.WriteLine("All People in the database:");
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }
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
            */
        
        }
    }
}

