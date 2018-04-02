using System;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace DocumentDBGettingStarted.Classes
{
    public class Phones
    {
        public string PhoneNumber { get; set; }
        public string PhoneInfo { get; set; }
    }
}