﻿using System;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
namespace DocumentDBGettingStarted.Classes
{
    public class Contacts
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Type { get; set; }
        public Persons[] Person { get; set; }
        public Cities[] City { get; set; }
        public Addresses[] Address { get; set; }
        public AltAddresses[] AltAddress { get; set; }
        public bool IsRegistered { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}