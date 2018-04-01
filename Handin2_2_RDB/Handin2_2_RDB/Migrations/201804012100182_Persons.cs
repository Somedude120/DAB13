namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Persons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactsId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Address_AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.ContactsId)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId)
                .Index(t => t.Address_AddressId);
            
            CreateTable(
                "dbo.AltAddresses",
                c => new
                    {
                        AltAddressId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.AltAddressId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        StreetName = c.String(),
                        HouseNumber = c.Int(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        CityName = c.String(),
                        Address_AddressId = c.Int(),
                        AltAddress_AltAddressId = c.Int(),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId)
                .ForeignKey("dbo.AltAddresses", t => t.AltAddress_AltAddressId)
                .Index(t => t.Address_AddressId)
                .Index(t => t.AltAddress_AltAddressId);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MiddleName = c.String(),
                        SurName = c.String(),
                        Email = c.String(),
                        Contacts_ContactsId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Contacts", t => t.Contacts_ContactsId)
                .Index(t => t.Contacts_ContactsId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneId = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Info = c.String(),
                        Contacts_ContactsId = c.Int(),
                    })
                .PrimaryKey(t => t.PhoneId)
                .ForeignKey("dbo.Contacts", t => t.Contacts_ContactsId)
                .Index(t => t.Contacts_ContactsId);
            
            CreateTable(
                "dbo.AltAddressContacts",
                c => new
                    {
                        AltAddress_AltAddressId = c.Int(nullable: false),
                        Contacts_ContactsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AltAddress_AltAddressId, t.Contacts_ContactsId })
                .ForeignKey("dbo.AltAddresses", t => t.AltAddress_AltAddressId, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.Contacts_ContactsId, cascadeDelete: true)
                .Index(t => t.AltAddress_AltAddressId)
                .Index(t => t.Contacts_ContactsId);
            
            CreateTable(
                "dbo.PersonsAddresses",
                c => new
                    {
                        Persons_PersonId = c.Int(nullable: false),
                        Address_AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Persons_PersonId, t.Address_AddressId })
                .ForeignKey("dbo.Persons", t => t.Persons_PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId, cascadeDelete: true)
                .Index(t => t.Persons_PersonId)
                .Index(t => t.Address_AddressId);
            
            CreateTable(
                "dbo.PhonePersons",
                c => new
                    {
                        Phone_PhoneId = c.Int(nullable: false),
                        Persons_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Phone_PhoneId, t.Persons_PersonId })
                .ForeignKey("dbo.Phones", t => t.Phone_PhoneId, cascadeDelete: true)
                .ForeignKey("dbo.Persons", t => t.Persons_PersonId, cascadeDelete: true)
                .Index(t => t.Phone_PhoneId)
                .Index(t => t.Persons_PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "Contacts_ContactsId", "dbo.Contacts");
            DropForeignKey("dbo.Persons", "Contacts_ContactsId", "dbo.Contacts");
            DropForeignKey("dbo.PhonePersons", "Persons_PersonId", "dbo.Persons");
            DropForeignKey("dbo.PhonePersons", "Phone_PhoneId", "dbo.Phones");
            DropForeignKey("dbo.PersonsAddresses", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.PersonsAddresses", "Persons_PersonId", "dbo.Persons");
            DropForeignKey("dbo.AltAddressContacts", "Contacts_ContactsId", "dbo.Contacts");
            DropForeignKey("dbo.AltAddressContacts", "AltAddress_AltAddressId", "dbo.AltAddresses");
            DropForeignKey("dbo.Cities", "AltAddress_AltAddressId", "dbo.AltAddresses");
            DropForeignKey("dbo.Cities", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Contacts", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.PhonePersons", new[] { "Persons_PersonId" });
            DropIndex("dbo.PhonePersons", new[] { "Phone_PhoneId" });
            DropIndex("dbo.PersonsAddresses", new[] { "Address_AddressId" });
            DropIndex("dbo.PersonsAddresses", new[] { "Persons_PersonId" });
            DropIndex("dbo.AltAddressContacts", new[] { "Contacts_ContactsId" });
            DropIndex("dbo.AltAddressContacts", new[] { "AltAddress_AltAddressId" });
            DropIndex("dbo.Phones", new[] { "Contacts_ContactsId" });
            DropIndex("dbo.Persons", new[] { "Contacts_ContactsId" });
            DropIndex("dbo.Cities", new[] { "AltAddress_AltAddressId" });
            DropIndex("dbo.Cities", new[] { "Address_AddressId" });
            DropIndex("dbo.Contacts", new[] { "Address_AddressId" });
            DropTable("dbo.PhonePersons");
            DropTable("dbo.PersonsAddresses");
            DropTable("dbo.AltAddressContacts");
            DropTable("dbo.Phones");
            DropTable("dbo.Persons");
            DropTable("dbo.Cities");
            DropTable("dbo.AltAddresses");
            DropTable("dbo.Contacts");
            DropTable("dbo.Addresses");
        }
    }
}
