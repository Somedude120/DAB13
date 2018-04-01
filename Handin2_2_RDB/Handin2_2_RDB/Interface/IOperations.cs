using Handin2_2_RDB.Classes;
using Handin2_2_RDB.Context;

namespace Handin2_2_RDB.Main.Interface
{
    public interface IOperations
    {
        void AddContact(PersonIndexContext db);
        void ViewContact(PersonIndexContext db);
        void UpdateContact(PersonIndexContext db);
        void DeleteContact(PersonIndexContext db);
    }
}