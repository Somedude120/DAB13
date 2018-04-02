namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addresses4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "Persons_PersonId", "dbo.Persons");
            DropIndex("dbo.Addresses", new[] { "Persons_PersonId" });
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
            
            DropColumn("dbo.Addresses", "Persons_PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "Persons_PersonId", c => c.Int());
            DropForeignKey("dbo.PersonsAddresses", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.PersonsAddresses", "Persons_PersonId", "dbo.Persons");
            DropIndex("dbo.PersonsAddresses", new[] { "Address_AddressId" });
            DropIndex("dbo.PersonsAddresses", new[] { "Persons_PersonId" });
            DropTable("dbo.PersonsAddresses");
            CreateIndex("dbo.Addresses", "Persons_PersonId");
            AddForeignKey("dbo.Addresses", "Persons_PersonId", "dbo.Persons", "PersonId");
        }
    }
}
