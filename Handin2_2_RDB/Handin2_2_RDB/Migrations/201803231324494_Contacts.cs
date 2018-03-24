namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contacts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        City = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.City);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        MiddleName = c.String(),
                        SurName = c.String(),
                        Email = c.String(),
                        Address_City = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Addresses", t => t.Address_City)
                .Index(t => t.Address_City);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Number = c.Int(nullable: true, identity: true),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Number);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "Address_City", "dbo.Addresses");
            DropIndex("dbo.Contacts", new[] { "Address_City" });
            DropTable("dbo.Phones");
            DropTable("dbo.Contacts");
            DropTable("dbo.Addresses");
        }
    }
}
