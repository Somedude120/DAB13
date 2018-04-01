namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Phone3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactsAddresses", "Address_Street", "dbo.Addresses");
            DropForeignKey("dbo.PersonsAddresses", "Address_Street", "dbo.Addresses");
            DropForeignKey("dbo.PhonePersons", "Phone_Number", "dbo.Phones");
            DropForeignKey("dbo.Contacts", "AltAddress_City", "dbo.AltAddresses");
            DropIndex("dbo.Contacts", new[] { "AltAddress_City" });
            DropIndex("dbo.ContactsAddresses", new[] { "Address_Street" });
            DropIndex("dbo.PersonsAddresses", new[] { "Address_Street" });
            DropIndex("dbo.PhonePersons", new[] { "Phone_Number" });
            RenameColumn(table: "dbo.ContactsAddresses", name: "Address_Street", newName: "Address_AddressId");
            RenameColumn(table: "dbo.PersonsAddresses", name: "Address_Street", newName: "Address_AddressId");
            RenameColumn(table: "dbo.PhonePersons", name: "Phone_Number", newName: "Phone_PhoneId");
            RenameColumn(table: "dbo.Contacts", name: "AltAddress_City", newName: "AltAddress_AltAddressId");
            DropPrimaryKey("dbo.Addresses");
            DropPrimaryKey("dbo.Phones");
            DropPrimaryKey("dbo.AltAddresses");
            DropPrimaryKey("dbo.Cities");
            DropPrimaryKey("dbo.ContactsAddresses");
            DropPrimaryKey("dbo.PersonsAddresses");
            DropPrimaryKey("dbo.PhonePersons");
            AddColumn("dbo.Addresses", "AddressId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Phones", "PhoneId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.AltAddresses", "AltAddressId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Cities", "CityId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Cities", "Address_AddressId", c => c.Int());
            AddColumn("dbo.Cities", "AltAddress_AltAddressId", c => c.Int());
            AlterColumn("dbo.Contacts", "AltAddress_AltAddressId", c => c.Int());
            AlterColumn("dbo.Phones", "Number", c => c.String());
            AlterColumn("dbo.Cities", "StreetName", c => c.String());
            AlterColumn("dbo.ContactsAddresses", "Address_AddressId", c => c.Int(nullable: false));
            AlterColumn("dbo.PersonsAddresses", "Address_AddressId", c => c.Int(nullable: false));
            AlterColumn("dbo.PhonePersons", "Phone_PhoneId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Addresses", "AddressId");
            AddPrimaryKey("dbo.Phones", "PhoneId");
            AddPrimaryKey("dbo.AltAddresses", "AltAddressId");
            AddPrimaryKey("dbo.Cities", "CityId");
            AddPrimaryKey("dbo.ContactsAddresses", new[] { "Contacts_ContactsId", "Address_AddressId" });
            AddPrimaryKey("dbo.PersonsAddresses", new[] { "Persons_PersonId", "Address_AddressId" });
            AddPrimaryKey("dbo.PhonePersons", new[] { "Phone_PhoneId", "Persons_PersonId" });
            CreateIndex("dbo.Contacts", "AltAddress_AltAddressId");
            CreateIndex("dbo.Cities", "Address_AddressId");
            CreateIndex("dbo.Cities", "AltAddress_AltAddressId");
            CreateIndex("dbo.ContactsAddresses", "Address_AddressId");
            CreateIndex("dbo.PersonsAddresses", "Address_AddressId");
            CreateIndex("dbo.PhonePersons", "Phone_PhoneId");
            AddForeignKey("dbo.Cities", "Address_AddressId", "dbo.Addresses", "AddressId");
            AddForeignKey("dbo.Cities", "AltAddress_AltAddressId", "dbo.AltAddresses", "AltAddressId");
            AddForeignKey("dbo.ContactsAddresses", "Address_AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
            AddForeignKey("dbo.PersonsAddresses", "Address_AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
            AddForeignKey("dbo.PhonePersons", "Phone_PhoneId", "dbo.Phones", "PhoneId", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "AltAddress_AltAddressId", "dbo.AltAddresses", "AltAddressId");
            DropColumn("dbo.Addresses", "Street");
            DropColumn("dbo.Addresses", "Number");
            DropColumn("dbo.AltAddresses", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AltAddresses", "City", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Addresses", "Number", c => c.String());
            AddColumn("dbo.Addresses", "Street", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Contacts", "AltAddress_AltAddressId", "dbo.AltAddresses");
            DropForeignKey("dbo.PhonePersons", "Phone_PhoneId", "dbo.Phones");
            DropForeignKey("dbo.PersonsAddresses", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.ContactsAddresses", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Cities", "AltAddress_AltAddressId", "dbo.AltAddresses");
            DropForeignKey("dbo.Cities", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.PhonePersons", new[] { "Phone_PhoneId" });
            DropIndex("dbo.PersonsAddresses", new[] { "Address_AddressId" });
            DropIndex("dbo.ContactsAddresses", new[] { "Address_AddressId" });
            DropIndex("dbo.Cities", new[] { "AltAddress_AltAddressId" });
            DropIndex("dbo.Cities", new[] { "Address_AddressId" });
            DropIndex("dbo.Contacts", new[] { "AltAddress_AltAddressId" });
            DropPrimaryKey("dbo.PhonePersons");
            DropPrimaryKey("dbo.PersonsAddresses");
            DropPrimaryKey("dbo.ContactsAddresses");
            DropPrimaryKey("dbo.Cities");
            DropPrimaryKey("dbo.AltAddresses");
            DropPrimaryKey("dbo.Phones");
            DropPrimaryKey("dbo.Addresses");
            AlterColumn("dbo.PhonePersons", "Phone_PhoneId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PersonsAddresses", "Address_AddressId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ContactsAddresses", "Address_AddressId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Cities", "StreetName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Phones", "Number", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Contacts", "AltAddress_AltAddressId", c => c.String(maxLength: 128));
            DropColumn("dbo.Cities", "AltAddress_AltAddressId");
            DropColumn("dbo.Cities", "Address_AddressId");
            DropColumn("dbo.Cities", "CityId");
            DropColumn("dbo.AltAddresses", "AltAddressId");
            DropColumn("dbo.Phones", "PhoneId");
            DropColumn("dbo.Addresses", "AddressId");
            AddPrimaryKey("dbo.PhonePersons", new[] { "Phone_Number", "Persons_PersonId" });
            AddPrimaryKey("dbo.PersonsAddresses", new[] { "Persons_PersonId", "Address_Street" });
            AddPrimaryKey("dbo.ContactsAddresses", new[] { "Contacts_ContactsId", "Address_Street" });
            AddPrimaryKey("dbo.Cities", "StreetName");
            AddPrimaryKey("dbo.AltAddresses", "City");
            AddPrimaryKey("dbo.Phones", "Number");
            AddPrimaryKey("dbo.Addresses", "Street");
            RenameColumn(table: "dbo.Contacts", name: "AltAddress_AltAddressId", newName: "AltAddress_City");
            RenameColumn(table: "dbo.PhonePersons", name: "Phone_PhoneId", newName: "Phone_Number");
            RenameColumn(table: "dbo.PersonsAddresses", name: "Address_AddressId", newName: "Address_Street");
            RenameColumn(table: "dbo.ContactsAddresses", name: "Address_AddressId", newName: "Address_Street");
            CreateIndex("dbo.PhonePersons", "Phone_Number");
            CreateIndex("dbo.PersonsAddresses", "Address_Street");
            CreateIndex("dbo.ContactsAddresses", "Address_Street");
            CreateIndex("dbo.Contacts", "AltAddress_City");
            AddForeignKey("dbo.Contacts", "AltAddress_City", "dbo.AltAddresses", "City");
            AddForeignKey("dbo.PhonePersons", "Phone_Number", "dbo.Phones", "Number", cascadeDelete: true);
            AddForeignKey("dbo.PersonsAddresses", "Address_Street", "dbo.Addresses", "Street", cascadeDelete: true);
            AddForeignKey("dbo.ContactsAddresses", "Address_Street", "dbo.Addresses", "Street", cascadeDelete: true);
        }
    }
}
