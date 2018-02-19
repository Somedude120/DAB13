namespace CodeFirstNewDatabaseSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Organization12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrganizationCountries", "Organization_OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.OrganizationCountries", "Country_CountryId", "dbo.Countries");
            DropIndex("dbo.OrganizationCountries", new[] { "Organization_OrganizationId" });
            DropIndex("dbo.OrganizationCountries", new[] { "Country_CountryId" });
            AddColumn("dbo.Countries", "Organization_OrganizationId", c => c.Int());
            AddColumn("dbo.Organizations", "Homeland_CountryId", c => c.Int());
            AddColumn("dbo.Organizations", "Country_CountryId", c => c.Int());
            CreateIndex("dbo.Countries", "Organization_OrganizationId");
            CreateIndex("dbo.Organizations", "Homeland_CountryId");
            CreateIndex("dbo.Organizations", "Country_CountryId");
            AddForeignKey("dbo.Organizations", "Homeland_CountryId", "dbo.Countries", "CountryId");
            AddForeignKey("dbo.Countries", "Organization_OrganizationId", "dbo.Organizations", "OrganizationId");
            AddForeignKey("dbo.Organizations", "Country_CountryId", "dbo.Countries", "CountryId");
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
            
            DropForeignKey("dbo.Organizations", "Country_CountryId", "dbo.Countries");
            DropForeignKey("dbo.Countries", "Organization_OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Organizations", "Homeland_CountryId", "dbo.Countries");
            DropIndex("dbo.Organizations", new[] { "Country_CountryId" });
            DropIndex("dbo.Organizations", new[] { "Homeland_CountryId" });
            DropIndex("dbo.Countries", new[] { "Organization_OrganizationId" });
            DropColumn("dbo.Organizations", "Country_CountryId");
            DropColumn("dbo.Organizations", "Homeland_CountryId");
            DropColumn("dbo.Countries", "Organization_OrganizationId");
            CreateIndex("dbo.OrganizationCountries", "Country_CountryId");
            CreateIndex("dbo.OrganizationCountries", "Organization_OrganizationId");
            AddForeignKey("dbo.OrganizationCountries", "Country_CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
            AddForeignKey("dbo.OrganizationCountries", "Organization_OrganizationId", "dbo.Organizations", "OrganizationId", cascadeDelete: true);
        }
    }
}
