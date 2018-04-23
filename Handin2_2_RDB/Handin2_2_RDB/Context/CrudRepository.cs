using System.Collections.Generic;
using System.Data.Entity;
using Handin2_2_RDB.Classes;
using Handin2_2_RDB.Main.Interface;

namespace Handin2_2_RDB.Context
{
    public class CrudRepository : Repository<PersonIndexContext>, IOperationsRepository
    {
        public CrudRepository(PersonIndexContext context)
            : base(context)
        {
        }
    }
}