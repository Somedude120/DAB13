using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Handin2_2_RDB.Classes;

namespace Handin2_2_RDB.Context
{
    public class PersonIndexContext : DbContext
    {
        
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<AltAddress> AltAdresses { get; set; }

    }
}