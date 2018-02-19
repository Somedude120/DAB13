namespace CodeFirstNewDatabaseSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Country : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        CountryCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            AddColumn("dbo.Organizations", "Homeland_CountryId", c => c.Int());
            CreateIndex("dbo.Organizations", "Homeland_CountryId");
            AddForeignKey("dbo.Organizations", "Homeland_CountryId", "dbo.Countries", "CountryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizations", "Homeland_CountryId", "dbo.Countries");
            DropIndex("dbo.Organizations", new[] { "Homeland_CountryId" });
            DropColumn("dbo.Organizations", "Homeland_CountryId");
            DropTable("dbo.Countries");
        }
    }
}
