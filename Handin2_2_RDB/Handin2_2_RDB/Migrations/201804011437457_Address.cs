namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Address : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactsAddresses", "Address_City", "dbo.Addresses");
            RenameColumn(table: "dbo.ContactsAddresses", name: "Address_City", newName: "Address_Street");
            RenameIndex(table: "dbo.ContactsAddresses", name: "IX_Address_City", newName: "IX_Address_Street");
            DropPrimaryKey("dbo.Addresses");
            AddColumn("dbo.Addresses", "Street", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Addresses", "Number", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String());
            AddPrimaryKey("dbo.Addresses", "Street");
            AddForeignKey("dbo.ContactsAddresses", "Address_Street", "dbo.Addresses", "Street", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactsAddresses", "Address_Street", "dbo.Addresses");
            DropPrimaryKey("dbo.Addresses");
            AlterColumn("dbo.Addresses", "City", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Addresses", "Number");
            DropColumn("dbo.Addresses", "Street");
            AddPrimaryKey("dbo.Addresses", "City");
            RenameIndex(table: "dbo.ContactsAddresses", name: "IX_Address_Street", newName: "IX_Address_City");
            RenameColumn(table: "dbo.ContactsAddresses", name: "Address_Street", newName: "Address_City");
            AddForeignKey("dbo.ContactsAddresses", "Address_City", "dbo.Addresses", "City", cascadeDelete: true);
        }
    }
}
