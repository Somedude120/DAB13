namespace Handin3_2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PersonIndexContext : DbContext
    {
        public PersonIndexContext()
            : base("name=PersonIndexContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AltAddress> AltAddresses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasMany(e => e.Contacts)
                .WithOptional(e => e.Address)
                .HasForeignKey(e => e.Address_AddressId);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Persons)
                .WithOptional(e => e.Address)
                .HasForeignKey(e => e.AddressList_AddressId);

            modelBuilder.Entity<AltAddress>()
                .HasMany(e => e.Cities)
                .WithOptional(e => e.AltAddress)
                .HasForeignKey(e => e.AltAddress_AltAddressId);

            modelBuilder.Entity<AltAddress>()
                .HasMany(e => e.Contacts)
                .WithMany(e => e.AltAddresses)
                .Map(m => m.ToTable("AltAddressContacts").MapRightKey("Contacts_ContactsId"));

            modelBuilder.Entity<City>()
                .HasOptional(e => e.Address)
                .WithRequired(e => e.City);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.Phones)
                .WithOptional(e => e.Contact)
                .HasForeignKey(e => e.Contacts_ContactsId);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.Persons)
                .WithMany(e => e.Contacts)
                .Map(m => m.ToTable("ContactsPersons").MapLeftKey("Contacts_ContactsId").MapRightKey("Persons_PersonId"));

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Phones)
                .WithMany(e => e.Persons)
                .Map(m => m.ToTable("PhonePersons").MapLeftKey("Persons_PersonId"));
        }
    }
}
