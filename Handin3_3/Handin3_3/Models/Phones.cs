using System;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace Handin3_3.Models
{
    public class Phones
    {
        public string PhoneNumber { get; set; }
        public string PhoneInfo { get; set; }
    }
}