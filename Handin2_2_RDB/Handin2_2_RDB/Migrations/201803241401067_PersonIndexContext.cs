namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonIndexContext : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Phones");
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        StreetName = c.String(nullable: false, maxLength: 128),
                        HouseNumber = c.Int(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.StreetName);
            
            AlterColumn("dbo.Phones", "Number", c => c.Int(nullable: false, identity: false));
            AddPrimaryKey("dbo.Phones", "Number");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Phones");
            AlterColumn("dbo.Phones", "Number", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Cities");
            AddPrimaryKey("dbo.Phones", "Number");
        }
    }
}
