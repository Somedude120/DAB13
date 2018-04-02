using System;
using System.Linq;
using System.Threading.Tasks;

// ADD THIS PART TO YOUR CODE
using System.Net;
using DocumentDBGettingStarted.Classes;
using DocumentDBGettingStarted.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace DocumentDBGettingStarted
{
    public class Program
    {
        Contacts testcontact;
        // ADD THIS PART TO YOUR CODE
        private const string EndpointUrl = "https://localhost:8081";

        private const string PrimaryKey =
            "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        private DocumentClient client;
        private Operations OBS;
        static public Program p;

        static void Main(string[] args)
        {
            //// Connect to the Azure Cosmos DB Emulator running locally
            //DocumentClient client = new DocumentClient(
            //    new Uri("https://localhost:8081"),
            //    "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");

            // ADD THIS PART TO YOUR CODE
            try
            {
                p = new Program();
                p.GetStartedDemo().Wait();
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message,
                    baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
            finally
            {
                Console.WriteLine("End of demo, press any key to exit.");
                Console.ReadKey();
            }
        }

        // ADD THIS PART TO YOUR CODE
        private async Task GetStartedDemo()
        {
            this.client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            await this.client.CreateDatabaseIfNotExistsAsync(new Database {Id = "PersonIndexDB"});
            await this.client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("PersonIndexDB"),
                new DocumentCollection {Id = "Handin2_2"});
            //OBS.Create();
            CRUDMenu();

            
            //AddContact(testcontact);
            
            //await this.CreateContactDocumentIfNotExists("PersonIndexDB", "Handin2_2", AddContact(testcontact));

        }

        private void CRUDMenu()
        {
            OBS = new Operations(client, p);
            while (true)
            {
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View Contact");
                Console.WriteLine("3. Update Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
                var selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        OBS.Create();
                        break;
                    case "2":
                        OBS.ViewContact();
                        break;
                    case "3":
                        OBS.UpdateContact();
                        break;
                    case "4":
                        Console.WriteLine("Delete not here");
                        break;
                    case "5":
                        Environment.Exit(0);    //Quit program
                        break;
                    default:
                        Console.WriteLine("Only acceptable inputs are: '1' '2' '3' '4'");
                        break;
                }
            }
        }
    }
}

// ADD THIS PART TO YOUR CODE
            //Family andersenFamily = new Family
            //{
            //    Id = "Andersen.1",
            //    LastName = "Andersen",
            //    Parents = new Parent[]
            //        {
            //    new Parent { FirstName = "Thomas" },
            //    new Parent { FirstName = "Mary Kay" }
            //        },
            //    Children = new Child[]
            //        {
            //    new Persons
            //    {
            //            FirstName = "Henriette Thaulow",
            //            MiddleName = "female",
            //            SurName = 5,
            //            Phones = new Phones[]
            //            {
            //                    new Phones { PhoneInfo = "Fluffy", PhoneNumber = "55-55-55"}
            //            }
            //    }
            //        },
            //    Address = new Address { State = "WA", County = "King", City = "Seattle" },
            //    IsRegistered = true
            //};
            
            //Contacts testcontact = new Contacts()
            //{
            //    Id = "HANS5",
            //    //Person kommer ind her
            //    Person = new Persons[]
            //    {
            //        new Persons(){FirstName = "HANS", MiddleName = "HANS", SurName = "HANS", Email = "HANS",
            //            //Telefon er en del af personen
            //            Phone = new Phones[]
            //            {
            //                new Phones { PhoneNumber = "555", PhoneInfo = "HANS"},
            //            }
            //        },
            //    },
            //    //Kontakt adressen ligger under Kontakt
            //    Address = new Addresses[]
            //    {
            //        new Addresses {CityName = "HANS", StreetName = "HANS", HouseNumber = "HANS",Zipcode = "HANS"}
            //    },
            //    AltAddress = new AltAddresses[]
            //    {
            //        new AltAddresses{CityName = "HANS",Zipcode = "HANS", StreetName = "HANS"}
            //    },
            //    IsRegistered = true,

            //};
            //OBS.AddContact();

            //await this.CreateFamilyDocumentIfNotExists("PersonIndexDB", "Handin2_2", testcontact);
            
            //Family wakefieldFamily = new Family
            //{
            //    Id = "Wakefield.7",
            //    LastName = "Wakefield",
            //    Parents = new Parent[]
            //        {
            //    new Parent { FamilyName = "Wakefield", FirstName = "Robin" },
            //    new Parent { FamilyName = "Miller", FirstName = "Ben" }
            //        },
            //    Children = new Child[]
            //        {
            //    new Child
            //    {
            //            FamilyName = "Merriam",
            //            FirstName = "Jesse",
            //            Gender = "female",
            //            Grade = 8,
            //            Phones = new Phones[]
            //            {
            //                    new Phones { PhoneInfo = "Goofy" },
            //                    new Phones { PhoneInfo = "Shadow" }
            //            }
            //    },
            //    new Child
            //    {
            //            FamilyName = "Miller",
            //            FirstName = "Lisa",
            //            Gender = "female",
            //            Grade = 1
            //    }
            //        },
            //    Address = new Address { State = "NY", County = "Manhattan", City = "NY" },
            //    IsRegistered = false
            //};
            

            //await this.CreateFamilyDocumentIfNotExists("PersonIndexDB", "Handin2_2", wakefieldFamily);

            // ADD THIS PART TO YOUR CODE
            //this.ExecuteSimpleQuery("PersonIndexDB", "Handin2_2");

            // ADD THIS PART TO YOUR CODE
            // Update the Grade of the Andersen Family child
            //andersenFamily.Children[0].Grade = 6;

            //await this.ReplaceFamilyDocument("PersonIndexDB", "Handin2_2", "Andersen.1", andersenFamily);

            //this.ExecuteSimpleQuery("PersonIndexDB", "Handin2_2");

            // Slet dokumentet
            //await this.DeleteFamilyDocument("PersonIndexDB", "Handin2_2", "Andersen.1");

            // ADD THIS PART TO CODE
            // Clean up/delete the database
            //await this.client.DeleteDatabaseAsync(UriFactory.CreateDatabaseUri("PersonIndexDB"));

        
        // ADD THIS PART TO YOUR CODE
        //private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
        //{
        //    Console.WriteLine(format, args);
        //    Console.WriteLine("Press any key to continue ...");
        //    Console.ReadKey();
        //}
        // 
        //public class Family
        //{
        //    [JsonProperty(PropertyName = "id")]
        //    public string Id { get; set; }
        //    public string LastName { get; set; }
        //    public Parent[] Parents { get; set; }
        //    public Child[] Children { get; set; }
        //    public Address Address { get; set; }
        //    public bool IsRegistered { get; set; }
        //    public override string ToString()
        //    {
        //        return JsonConvert.SerializeObject(this);
        //    }
        //}

        //public class Parent
        //{
        //    public string FamilyName { get; set; }
        //    public string FirstName { get; set; }
        //}

        ////public class Child
        ////{
        ////    public string FamilyName { get; set; }
        ////    public string FirstName { get; set; }
        ////    public string Gender { get; set; }
        ////    public int Grade { get; set; }
        ////    public Phones[] Phones { get; set; }
        ////}

        ////public class Phone
        ////{
        ////    public string GivenName { get; set; }
        ////}

        //public class Address
        //{
        //    public string State { get; set; }
        //    public string County { get; set; }
        //    public string City { get; set; }
        //}
        //// ADD THIS PART TO YOUR CODE
        //private async Task CreateFamilyDocumentIfNotExists(string databaseName, string collectionName, Contacts contact)
        //{
        //    try
        //    {
        //        await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, contact.Id));
        //        this.WriteToConsoleAndPromptToContinue("Found {0}", contact.Id);
        //    }
        //    catch (DocumentClientException de)
        //    {
        //        if (de.StatusCode == HttpStatusCode.NotFound)
        //        {
        //            await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), contact);
        //            this.WriteToConsoleAndPromptToContinue("Created Contact {0}", contact.Id);
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //}
        // ADD THIS PART TO YOUR CODE
        //private void ExecuteSimpleQuery(string databaseName, string collectionName)
        //{
        //    // Set some common query options
        //    FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

        //    // Here we find the Andersen family via its LastName
        //    IQueryable<Contacts> familyQuery = this.client.CreateDocumentQuery<Contacts>(
        //            UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), queryOptions)
        //        .Where(f => f.Person[0].FirstName == "Andersen");

        //    // The query is executed synchronously here, but can also be executed asynchronously via the IDocumentQuery<T> interface
        //    Console.WriteLine("Running LINQ query...");
        //    foreach (Contacts contact in familyQuery)
        //    {
        //        Console.WriteLine("\tRead {0}", contact);
        //    }

        //    // Now execute the same query via direct SQL
        //    IQueryable<Contacts> familyQueryInSql = this.client.CreateDocumentQuery<Contacts>(
        //        UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
        //        "SELECT * FROM Family WHERE Family.LastName = 'Hansi'",
        //        queryOptions);

        //    Console.WriteLine("Running direct SQL query...");
        //    foreach (Contacts contact in familyQueryInSql)
        //    {
        //        Console.WriteLine("\tRead {0}", contact);
        //    }

        //    Console.WriteLine("Press any key to continue ...");
        //    Console.ReadKey();
        //}
        //// ADD THIS PART TO YOUR CODE
        //private async Task ReplaceFamilyDocument(string databaseName, string collectionName, string personName, Contacts updatedcontact)
        //{
        //    await this.client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, personName), updatedcontact);
        //    this.WriteToConsoleAndPromptToContinue("Replaced Contact {0}", personName);
        //}
        ////// ADD THIS PART TO YOUR CODE
        ////private async Task DeleteFamilyDocument(string databaseName, string collectionName, string documentName)
        ////{
        ////    await this.client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, documentName));
        ////    Console.WriteLine("Deleted Family {0}", documentName);
        ////}

