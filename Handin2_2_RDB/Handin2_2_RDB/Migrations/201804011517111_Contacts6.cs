namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contacts6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactsAddresses", "Contacts_ContactsId", "dbo.Contacts");
            DropForeignKey("dbo.ContactsAddresses", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.ContactsAddresses", new[] { "Contacts_ContactsId" });
            DropIndex("dbo.ContactsAddresses", new[] { "Address_AddressId" });
            AddColumn("dbo.Contacts", "Address_AddressId", c => c.Int());
            CreateIndex("dbo.Contacts", "Address_AddressId");
            AddForeignKey("dbo.Contacts", "Address_AddressId", "dbo.Addresses", "AddressId");
            DropTable("dbo.ContactsAddresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ContactsAddresses",
                c => new
                    {
                        Contacts_ContactsId = c.Int(nullable: false),
                        Address_AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Contacts_ContactsId, t.Address_AddressId });
            
            DropForeignKey("dbo.Contacts", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.Contacts", new[] { "Address_AddressId" });
            DropColumn("dbo.Contacts", "Address_AddressId");
            CreateIndex("dbo.ContactsAddresses", "Address_AddressId");
            CreateIndex("dbo.ContactsAddresses", "Contacts_ContactsId");
            AddForeignKey("dbo.ContactsAddresses", "Address_AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
            AddForeignKey("dbo.ContactsAddresses", "Contacts_ContactsId", "dbo.Contacts", "ContactsId", cascadeDelete: true);
        }
    }
}
