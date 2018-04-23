using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentDBGettingStarted.Classes;

namespace DocumentDBGettingStarted.Interfaces
{
    public interface IRepository<T> where T : EntityBase

    {
        Contacts AddContact();
        Task ViewContact();
        Task UpdateContact();
        Task DeleteContact();
    }
}