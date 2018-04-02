using System;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace DocumentDBGettingStarted.Tasks
{
    public interface IOperations
    {
        void AddContact();
        void ViewContact();
        void UpdateContact();
        void DeleteContact();
    }
}