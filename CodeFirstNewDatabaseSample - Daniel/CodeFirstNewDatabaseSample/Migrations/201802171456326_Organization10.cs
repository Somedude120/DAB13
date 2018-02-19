namespace CodeFirstNewDatabaseSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Organization10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrganizationCountries", "Organization_OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.OrganizationCountries", "Country_CountryId", "dbo.Countries");
            DropIndex("dbo.OrganizationCountries", new[] { "Organization_OrganizationId" });
            DropIndex("dbo.OrganizationCountries", new[] { "Country_CountryId" });
            AddColumn("dbo.Organizations", "Homeland_CountryId", c => c.Int());
            CreateIndex("dbo.Organizations", "Homeland_CountryId");
            AddForeignKey("dbo.Organizations", "Homeland_CountryId", "dbo.Countries", "CountryId");
            DropTable("dbo.OrganizationCountries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrganizationCountries",
                c => new
                    {
                        Organization_OrganizationId = c.Int(nullable: false),
                        Country_CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Organization_OrganizationId, t.Country_CountryId });
            
            DropForeignKey("dbo.Organizations", "Homeland_CountryId", "dbo.Countries");
            DropIndex("dbo.Organizations", new[] { "Homeland_CountryId" });
            DropColumn("dbo.Organizations", "Homeland_CountryId");
            CreateIndex("dbo.OrganizationCountries", "Country_CountryId");
            CreateIndex("dbo.OrganizationCountries", "Organization_OrganizationId");
            AddForeignKey("dbo.OrganizationCountries", "Country_CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
            AddForeignKey("dbo.OrganizationCountries", "Organization_OrganizationId", "dbo.Organizations", "OrganizationId", cascadeDelete: true);
        }
    }
}
