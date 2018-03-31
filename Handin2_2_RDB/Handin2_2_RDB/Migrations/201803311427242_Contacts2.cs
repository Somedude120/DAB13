namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contacts2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "Address_City", "dbo.Addresses");
            DropIndex("dbo.Contacts", new[] { "Address_City" });
            DropPrimaryKey("dbo.Contacts");
            CreateTable(
                "dbo.ContactsAddresses",
                c => new
                    {
                        Contacts_Type = c.String(nullable: false, maxLength: 128),
                        Address_City = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Contacts_Type, t.Address_City })
                .ForeignKey("dbo.Contacts", t => t.Contacts_Type, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_City, cascadeDelete: true)
                .Index(t => t.Contacts_Type)
                .Index(t => t.Address_City);
            
            AddColumn("dbo.Contacts", "Type", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Persons", "Contacts_Type", c => c.String(maxLength: 128));
            AddColumn("dbo.Phones", "Contacts_Type", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Contacts", "Type");
            CreateIndex("dbo.Persons", "Contacts_Type");
            CreateIndex("dbo.Phones", "Contacts_Type");
            AddForeignKey("dbo.Persons", "Contacts_Type", "dbo.Contacts", "Type");
            AddForeignKey("dbo.Phones", "Contacts_Type", "dbo.Contacts", "Type");
            DropColumn("dbo.Contacts", "Name");
            DropColumn("dbo.Contacts", "MiddleName");
            DropColumn("dbo.Contacts", "SurName");
            DropColumn("dbo.Contacts", "Email");
            DropColumn("dbo.Contacts", "Address_City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Address_City", c => c.String(maxLength: 128));
            AddColumn("dbo.Contacts", "Email", c => c.String());
            AddColumn("dbo.Contacts", "SurName", c => c.String());
            AddColumn("dbo.Contacts", "MiddleName", c => c.String());
            AddColumn("dbo.Contacts", "Name", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Phones", "Contacts_Type", "dbo.Contacts");
            DropForeignKey("dbo.Persons", "Contacts_Type", "dbo.Contacts");
            DropForeignKey("dbo.ContactsAddresses", "Address_City", "dbo.Addresses");
            DropForeignKey("dbo.ContactsAddresses", "Contacts_Type", "dbo.Contacts");
            DropIndex("dbo.ContactsAddresses", new[] { "Address_City" });
            DropIndex("dbo.ContactsAddresses", new[] { "Contacts_Type" });
            DropIndex("dbo.Phones", new[] { "Contacts_Type" });
            DropIndex("dbo.Persons", new[] { "Contacts_Type" });
            DropPrimaryKey("dbo.Contacts");
            DropColumn("dbo.Phones", "Contacts_Type");
            DropColumn("dbo.Persons", "Contacts_Type");
            DropColumn("dbo.Contacts", "Type");
            DropTable("dbo.ContactsAddresses");
            AddPrimaryKey("dbo.Contacts", "Name");
            CreateIndex("dbo.Contacts", "Address_City");
            AddForeignKey("dbo.Contacts", "Address_City", "dbo.Addresses", "City");
        }
    }
}
