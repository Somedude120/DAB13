namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Address1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonsAddresses",
                c => new
                    {
                        Persons_PersonId = c.Int(nullable: false),
                        Address_Street = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Persons_PersonId, t.Address_Street })
                .ForeignKey("dbo.Persons", t => t.Persons_PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_Street, cascadeDelete: true)
                .Index(t => t.Persons_PersonId)
                .Index(t => t.Address_Street);
            
            CreateTable(
                "dbo.PhonePersons",
                c => new
                    {
                        Phone_Number = c.String(nullable: false, maxLength: 128),
                        Persons_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Phone_Number, t.Persons_PersonId })
                .ForeignKey("dbo.Phones", t => t.Phone_Number, cascadeDelete: true)
                .ForeignKey("dbo.Persons", t => t.Persons_PersonId, cascadeDelete: true)
                .Index(t => t.Phone_Number)
                .Index(t => t.Persons_PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhonePersons", "Persons_PersonId", "dbo.Persons");
            DropForeignKey("dbo.PhonePersons", "Phone_Number", "dbo.Phones");
            DropForeignKey("dbo.PersonsAddresses", "Address_Street", "dbo.Addresses");
            DropForeignKey("dbo.PersonsAddresses", "Persons_PersonId", "dbo.Persons");
            DropIndex("dbo.PhonePersons", new[] { "Persons_PersonId" });
            DropIndex("dbo.PhonePersons", new[] { "Phone_Number" });
            DropIndex("dbo.PersonsAddresses", new[] { "Address_Street" });
            DropIndex("dbo.PersonsAddresses", new[] { "Persons_PersonId" });
            DropTable("dbo.PhonePersons");
            DropTable("dbo.PersonsAddresses");
        }
    }
}
