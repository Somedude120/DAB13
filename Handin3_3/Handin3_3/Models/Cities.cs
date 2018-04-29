using System;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace Handin3_3.Models
{
    public class Cities
    {
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string Zipcode { get; set; }
        public string CityName { get; set; }
        //public Contacts[] Contact { get; set; }
    }
}