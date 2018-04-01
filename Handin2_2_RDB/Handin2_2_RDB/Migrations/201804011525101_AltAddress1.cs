namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AltAddress1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "AltAddress_AltAddressId", "dbo.AltAddresses");
            DropIndex("dbo.Contacts", new[] { "AltAddress_AltAddressId" });
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
            
            DropColumn("dbo.Contacts", "AltAddress_AltAddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "AltAddress_AltAddressId", c => c.Int());
            DropForeignKey("dbo.AltAddressContacts", "Contacts_ContactsId", "dbo.Contacts");
            DropForeignKey("dbo.AltAddressContacts", "AltAddress_AltAddressId", "dbo.AltAddresses");
            DropIndex("dbo.AltAddressContacts", new[] { "Contacts_ContactsId" });
            DropIndex("dbo.AltAddressContacts", new[] { "AltAddress_AltAddressId" });
            DropTable("dbo.AltAddressContacts");
            CreateIndex("dbo.Contacts", "AltAddress_AltAddressId");
            AddForeignKey("dbo.Contacts", "AltAddress_AltAddressId", "dbo.AltAddresses", "AltAddressId");
        }
    }
}
