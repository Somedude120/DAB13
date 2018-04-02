using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Handin2_2_RDB.Classes;

namespace Handin2_2_RDB.Context
{
    public class PersonIndexContext : DbContext
    {
        //Denne her linje viser output i vores consol
        public PersonIndexContext()
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public  DbSet<Contacts> Contacts { get; set; }
        public DbSet<Persons> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<AltAddress> AltAdresses { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}