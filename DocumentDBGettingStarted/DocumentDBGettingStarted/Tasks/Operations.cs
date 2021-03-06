﻿//Bliver ikke brugt
using System;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using DocumentDBGettingStarted.Classes;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DocumentDBGettingStarted.Tasks
{
    public class Operations
    {
        public Program Program;
        private readonly DocumentClient _client;

        public Operations(DocumentClient client, Program program)
        {
            Program = program;
            _client = client;
        }

        private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        public async Task Create()
        {
            AddToDatabase(AddContact());
        }

        public Contacts AddContact()
        {
            Console.WriteLine("Be adviced, if ID is the same as another ID, it will not be created");

            Console.WriteLine("Input ID: HANS will be added");
            string id = Console.ReadLine();
            Console.WriteLine("Input Firstname: HANS will be added");
            string fname = Console.ReadLine();
            Console.WriteLine("Input Middlename: HANS will be added");
            string mname = Console.ReadLine();
            Console.WriteLine("Input Surname: HANS will be added");
            string sname = Console.ReadLine();
            Console.WriteLine("Input Email: HANS will be added");
            string email = Console.ReadLine();
            Console.WriteLine("Input PhoneNumber: HANS will be added");
            string pnumber = Console.ReadLine();
            Console.WriteLine("Input PhoneInfo: HANS will be added");
            string pinfo = Console.ReadLine();
            Console.WriteLine("Input City: HANS will be added");
            string city = Console.ReadLine();
            Console.WriteLine("Input Street: HANS will be added");
            string street = Console.ReadLine();
            Console.WriteLine("Input Housenumber: HANS will be added");
            string hnumber = Console.ReadLine();
            Console.WriteLine("Input Zip: HANS will be added");
            string zipcode = Console.ReadLine();

            Contacts testcontact = new Contacts()
            {
                Id = id ,
                //Person kommer ind her
                Person = new Persons[]
                {
                    new Persons(){FirstName = fname+"HANS", MiddleName = mname+"HANS", SurName = sname+"HANS", Email = email+"HANS",
                        //Telefon er en del af personen
                        Phone = new Phones[]
                        {
                            new Phones { PhoneNumber = pnumber+"HANS", PhoneInfo = pinfo+"HANS"},
                        }
                    },
                },
                //Kontakt adressen ligger under Kontakt
                Address = new Addresses[]
                {
                    new Addresses {CityName = city+"HANS", StreetName = street+"HANS", HouseNumber = hnumber+"HANS",Zipcode = zipcode+"HANS"}
                },
                AltAddress = new AltAddresses[]
                {
                    new AltAddresses{CityName = "HANS",Zipcode = "HANS", StreetName = "HANS"}
                },
                IsRegistered = true,

            };

            return testcontact;
        }

        public async Task ViewContact()
        {
            Console.WriteLine("Enter person ID: ");
            string personID = Console.ReadLine();

            // Wub wub wub
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            // Finder en kontakt
            IQueryable<Contacts> contactQuery = _client.CreateDocumentQuery<Contacts>(
                    UriFactory.CreateDocumentCollectionUri("PersonIndexDB", "Handin2_2"), queryOptions)
                .Where(p => p.Id == personID);

            // Wanted person is now in PersonQuery
            foreach (Contacts contact in contactQuery)
            {
                Console.WriteLine("\tRead {0}", contact);
            }
        }

        public async Task UpdateContact()
        {
            var newContact = AddContact();   //Create a new Person
            try
            {
                await ReplaceContactDocument("PersonIndexDB", "Handin2_2", newContact.Id, newContact);   //Replace old person with new one
            }
            catch (Exception e)
            {
                Console.WriteLine("Contact did not exist. Nothing has been updated.");   //When trying to update a person that does not exist
            }
        }

        public async Task DeleteContact()
        {
            Console.WriteLine("Enter Contact ID for removal: ");
            string personId = Console.ReadLine();

            try
            {
                await DeleteContactDocument("PersonIndexDB", "Handin2_2", personId);    //Deletes Person (document) with the wanted ID
            }
            catch (Exception e)
            {
                Console.WriteLine("Person does not exist. Nothing has been deleted");   //When Person doesn't exist
            }
        }

        //Opgaver som skal håndtere dokument databasen, hardcoded til collection
        private async Task AddToDatabase(Contacts contact)
        {
            await this.CreateContactDocumentIfNotExists("PersonIndexDB", "Handin2_2", contact);
        }

        private async Task CreateContactDocumentIfNotExists(string databaseName, string collectionName, Contacts contact)
        {
            try
            {
                await this._client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, contact.Id));
                this.WriteToConsoleAndPromptToContinue("Found {0}", contact.Id);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this._client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), contact);
                    this.WriteToConsoleAndPromptToContinue("Created Contact {0}", contact.Id);
                }
                else
                {
                    throw;
                }
            }

        }
        private async Task ReplaceContactDocument(string databaseName, string collectionName, string personName, Contacts updatedcontact)
        {
            await this._client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, personName), updatedcontact);
            this.WriteToConsoleAndPromptToContinue("Replaced Contact {0}", personName);
        }
        private async Task DeleteContactDocument(string databaseName, string collectionName, string documentName)
        {
            await this._client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, documentName));
            Console.WriteLine("Deleted Contact {0}", documentName);
        }
    }
}