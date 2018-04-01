namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Address : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AltAddressContacts", newName: "ContactsAltAddresses");
            DropForeignKey("dbo.PersonsAddresses", "Persons_PersonId", "dbo.Persons");
            DropForeignKey("dbo.PersonsAddresses", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.PersonsAddresses", new[] { "Persons_PersonId" });
            DropIndex("dbo.PersonsAddresses", new[] { "Address_AddressId" });
            DropPrimaryKey("dbo.ContactsAltAddresses");
            AddColumn("dbo.Addresses", "Persons_PersonId", c => c.Int());
            AddPrimaryKey("dbo.ContactsAltAddresses", new[] { "Contacts_ContactsId", "AltAddress_AltAddressId" });
            CreateIndex("dbo.Addresses", "Persons_PersonId");
            AddForeignKey("dbo.Addresses", "Persons_PersonId", "dbo.Persons", "PersonId");
            DropColumn("dbo.Addresses", "City");
            DropTable("dbo.PersonsAddresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PersonsAddresses",
                c => new
                    {
                        Persons_PersonId = c.Int(nullable: false),
                        Address_AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Persons_PersonId, t.Address_AddressId });
            
            AddColumn("dbo.Addresses", "City", c => c.String());
            DropForeignKey("dbo.Addresses", "Persons_PersonId", "dbo.Persons");
            DropIndex("dbo.Addresses", new[] { "Persons_PersonId" });
            DropPrimaryKey("dbo.ContactsAltAddresses");
            DropColumn("dbo.Addresses", "Persons_PersonId");
            AddPrimaryKey("dbo.ContactsAltAddresses", new[] { "AltAddress_AltAddressId", "Contacts_ContactsId" });
            CreateIndex("dbo.PersonsAddresses", "Address_AddressId");
            CreateIndex("dbo.PersonsAddresses", "Persons_PersonId");
            AddForeignKey("dbo.PersonsAddresses", "Address_AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
            AddForeignKey("dbo.PersonsAddresses", "Persons_PersonId", "dbo.Persons", "PersonId", cascadeDelete: true);
            RenameTable(name: "dbo.ContactsAltAddresses", newName: "AltAddressContacts");
        }
    }
}
