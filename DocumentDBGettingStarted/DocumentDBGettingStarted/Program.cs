using System;
using System.Linq;
using System.Threading.Tasks;


using System.Net;
using DocumentDBGettingStarted.Classes;
using DocumentDBGettingStarted.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

//Det er vigtigt at vide at databaserne er hardcoded ind i systemet, så den vil skabe en collection med ID PersonIndexDB og en DB med navn Handin2_2
//Lisbeth og Daniel

namespace DocumentDBGettingStarted
{
    public class Program
    {
        Contacts testcontact;
        
        private const string EndpointUrl = "https://localhost:8081";

        private const string PrimaryKey =
            "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        private DocumentClient client;
        private Operations OBS;
        static public Program p;

        static void Main(string[] args)
        {
            //Console.WriteLine("HANS");//VERY CRUCIAL CODE VERY IMPORTANT FOR THE CODE TO WORK
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

 
        private async Task GetStartedDemo()
        {
            this.client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            await this.client.CreateDatabaseIfNotExistsAsync(new Database {Id = "PersonIndexDB"});
            await this.client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("PersonIndexDB"),
                new DocumentCollection {Id = "Handin2_2"});

            CRUDMenu();

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
                        OBS.DeleteContact();
                        break;
                    case "5":
                        Environment.Exit(0);    
                        break;
                    default:
                        Console.WriteLine("Only acceptable inputs are: '1' '2' '3' '4' '5'");
                        break;
                }
            }
        }
    }
}
