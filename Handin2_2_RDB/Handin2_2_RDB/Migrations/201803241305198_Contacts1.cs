namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contacts1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AltAddresses",
                c => new
                    {
                        City = c.String(nullable: false, maxLength: 128),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.City);
            
            AddColumn("dbo.Contacts", "AltAddress_City", c => c.String(maxLength: 128));
            CreateIndex("dbo.Contacts", "AltAddress_City");
            AddForeignKey("dbo.Contacts", "AltAddress_City", "dbo.AltAddresses", "City");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "AltAddress_City", "dbo.AltAddresses");
            DropIndex("dbo.Contacts", new[] { "AltAddress_City" });
            DropColumn("dbo.Contacts", "AltAddress_City");
            DropTable("dbo.AltAddresses");
        }
    }
}
