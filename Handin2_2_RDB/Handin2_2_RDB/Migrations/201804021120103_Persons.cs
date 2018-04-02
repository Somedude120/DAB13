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
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Cities", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MiddleName = c.String(),
                        SurName = c.String(),
                        Email = c.String(),
                        AddressList_AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Addresses", t => t.AddressList_AddressId)
                .Index(t => t.AddressList_AddressId);
            
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
                        AltAddress_AltAddressId = c.Int(),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.AltAddresses", t => t.AltAddress_AltAddressId)
                .Index(t => t.AltAddress_AltAddressId);
            
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
                "dbo.ContactsPersons",
                c => new
                    {
                        Contacts_ContactsId = c.Int(nullable: false),
                        Persons_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Contacts_ContactsId, t.Persons_PersonId })
                .ForeignKey("dbo.Contacts", t => t.Contacts_ContactsId, cascadeDelete: true)
                .ForeignKey("dbo.Persons", t => t.Persons_PersonId, cascadeDelete: true)
                .Index(t => t.Contacts_ContactsId)
                .Index(t => t.Persons_PersonId);
            
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
            DropForeignKey("dbo.Addresses", "AddressId", "dbo.Cities");
            DropForeignKey("dbo.Phones", "Contacts_ContactsId", "dbo.Contacts");
            DropForeignKey("dbo.PhonePersons", "Persons_PersonId", "dbo.Persons");
            DropForeignKey("dbo.PhonePersons", "Phone_PhoneId", "dbo.Phones");
            DropForeignKey("dbo.ContactsPersons", "Persons_PersonId", "dbo.Persons");
            DropForeignKey("dbo.ContactsPersons", "Contacts_ContactsId", "dbo.Contacts");
            DropForeignKey("dbo.AltAddressContacts", "Contacts_ContactsId", "dbo.Contacts");
            DropForeignKey("dbo.AltAddressContacts", "AltAddress_AltAddressId", "dbo.AltAddresses");
            DropForeignKey("dbo.Cities", "AltAddress_AltAddressId", "dbo.AltAddresses");
            DropForeignKey("dbo.Contacts", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Persons", "AddressList_AddressId", "dbo.Addresses");
            DropIndex("dbo.PhonePersons", new[] { "Persons_PersonId" });
            DropIndex("dbo.PhonePersons", new[] { "Phone_PhoneId" });
            DropIndex("dbo.ContactsPersons", new[] { "Persons_PersonId" });
            DropIndex("dbo.ContactsPersons", new[] { "Contacts_ContactsId" });
            DropIndex("dbo.AltAddressContacts", new[] { "Contacts_ContactsId" });
            DropIndex("dbo.AltAddressContacts", new[] { "AltAddress_AltAddressId" });
            DropIndex("dbo.Phones", new[] { "Contacts_ContactsId" });
            DropIndex("dbo.Cities", new[] { "AltAddress_AltAddressId" });
            DropIndex("dbo.Contacts", new[] { "Address_AddressId" });
            DropIndex("dbo.Persons", new[] { "AddressList_AddressId" });
            DropIndex("dbo.Addresses", new[] { "AddressId" });
            DropTable("dbo.PhonePersons");
            DropTable("dbo.ContactsPersons");
            DropTable("dbo.AltAddressContacts");
            DropTable("dbo.Phones");
            DropTable("dbo.Cities");
            DropTable("dbo.AltAddresses");
            DropTable("dbo.Contacts");
            DropTable("dbo.Persons");
            DropTable("dbo.Addresses");
        }
    }
}
