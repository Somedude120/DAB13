namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contacts5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactsAddresses", "Contacts_Type", "dbo.Contacts");
            DropForeignKey("dbo.Persons", "Contacts_Type", "dbo.Contacts");
            DropForeignKey("dbo.Phones", "Contacts_Type", "dbo.Contacts");
            DropIndex("dbo.Persons", new[] { "Contacts_Type" });
            DropIndex("dbo.Phones", new[] { "Contacts_Type" });
            DropIndex("dbo.ContactsAddresses", new[] { "Contacts_Type" });
            RenameColumn(table: "dbo.ContactsAddresses", name: "Contacts_Type", newName: "Contacts_ContactsId");
            RenameColumn(table: "dbo.Persons", name: "Contacts_Type", newName: "Contacts_ContactsId");
            RenameColumn(table: "dbo.Phones", name: "Contacts_Type", newName: "Contacts_ContactsId");
            DropPrimaryKey("dbo.Contacts");
            DropPrimaryKey("dbo.ContactsAddresses");
            AddColumn("dbo.Contacts", "ContactsId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Contacts", "Type", c => c.String());
            AlterColumn("dbo.Persons", "Contacts_ContactsId", c => c.Int());
            AlterColumn("dbo.Phones", "Contacts_ContactsId", c => c.Int());
            AlterColumn("dbo.ContactsAddresses", "Contacts_ContactsId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Contacts", "ContactsId");
            AddPrimaryKey("dbo.ContactsAddresses", new[] { "Contacts_ContactsId", "Address_City" });
            CreateIndex("dbo.Persons", "Contacts_ContactsId");
            CreateIndex("dbo.Phones", "Contacts_ContactsId");
            CreateIndex("dbo.ContactsAddresses", "Contacts_ContactsId");
            AddForeignKey("dbo.ContactsAddresses", "Contacts_ContactsId", "dbo.Contacts", "ContactsId", cascadeDelete: true);
            AddForeignKey("dbo.Persons", "Contacts_ContactsId", "dbo.Contacts", "ContactsId");
            AddForeignKey("dbo.Phones", "Contacts_ContactsId", "dbo.Contacts", "ContactsId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "Contacts_ContactsId", "dbo.Contacts");
            DropForeignKey("dbo.Persons", "Contacts_ContactsId", "dbo.Contacts");
            DropForeignKey("dbo.ContactsAddresses", "Contacts_ContactsId", "dbo.Contacts");
            DropIndex("dbo.ContactsAddresses", new[] { "Contacts_ContactsId" });
            DropIndex("dbo.Phones", new[] { "Contacts_ContactsId" });
            DropIndex("dbo.Persons", new[] { "Contacts_ContactsId" });
            DropPrimaryKey("dbo.ContactsAddresses");
            DropPrimaryKey("dbo.Contacts");
            AlterColumn("dbo.ContactsAddresses", "Contacts_ContactsId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Phones", "Contacts_ContactsId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Persons", "Contacts_ContactsId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Contacts", "Type", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Contacts", "ContactsId");
            AddPrimaryKey("dbo.ContactsAddresses", new[] { "Contacts_Type", "Address_City" });
            AddPrimaryKey("dbo.Contacts", "Type");
            RenameColumn(table: "dbo.Phones", name: "Contacts_ContactsId", newName: "Contacts_Type");
            RenameColumn(table: "dbo.Persons", name: "Contacts_ContactsId", newName: "Contacts_Type");
            RenameColumn(table: "dbo.ContactsAddresses", name: "Contacts_ContactsId", newName: "Contacts_Type");
            CreateIndex("dbo.ContactsAddresses", "Contacts_Type");
            CreateIndex("dbo.Phones", "Contacts_Type");
            CreateIndex("dbo.Persons", "Contacts_Type");
            AddForeignKey("dbo.Phones", "Contacts_Type", "dbo.Contacts", "Type");
            AddForeignKey("dbo.Persons", "Contacts_Type", "dbo.Contacts", "Type");
            AddForeignKey("dbo.ContactsAddresses", "Contacts_Type", "dbo.Contacts", "Type", cascadeDelete: true);
        }
    }
}
