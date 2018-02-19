namespace CodeFirstNewDatabaseSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Organization13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Organizations", "Homeland_CountryId", "dbo.Countries");
            DropForeignKey("dbo.Countries", "Organization_OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Organizations", "Country_CountryId", "dbo.Countries");
            DropIndex("dbo.Countries", new[] { "Organization_OrganizationId" });
            DropIndex("dbo.Organizations", new[] { "Homeland_CountryId" });
            DropIndex("dbo.Organizations", new[] { "Country_CountryId" });
            CreateTable(
                "dbo.OrganizationCountries",
                c => new
                    {
                        Organization_OrganizationId = c.Int(nullable: false),
                        Country_CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Organization_OrganizationId, t.Country_CountryId })
                .ForeignKey("dbo.Organizations", t => t.Organization_OrganizationId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.Country_CountryId, cascadeDelete: true)
                .Index(t => t.Organization_OrganizationId)
                .Index(t => t.Country_CountryId);
            
            DropColumn("dbo.Countries", "Organization_OrganizationId");
            DropColumn("dbo.Organizations", "Homeland_CountryId");
            DropColumn("dbo.Organizations", "Country_CountryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organizations", "Country_CountryId", c => c.Int());
            AddColumn("dbo.Organizations", "Homeland_CountryId", c => c.Int());
            AddColumn("dbo.Countries", "Organization_OrganizationId", c => c.Int());
            DropForeignKey("dbo.OrganizationCountries", "Country_CountryId", "dbo.Countries");
            DropForeignKey("dbo.OrganizationCountries", "Organization_OrganizationId", "dbo.Organizations");
            DropIndex("dbo.OrganizationCountries", new[] { "Country_CountryId" });
            DropIndex("dbo.OrganizationCountries", new[] { "Organization_OrganizationId" });
            DropTable("dbo.OrganizationCountries");
            CreateIndex("dbo.Organizations", "Country_CountryId");
            CreateIndex("dbo.Organizations", "Homeland_CountryId");
            CreateIndex("dbo.Countries", "Organization_OrganizationId");
            AddForeignKey("dbo.Organizations", "Country_CountryId", "dbo.Countries", "CountryId");
            AddForeignKey("dbo.Countries", "Organization_OrganizationId", "dbo.Organizations", "OrganizationId");
            AddForeignKey("dbo.Organizations", "Homeland_CountryId", "dbo.Countries", "CountryId");
        }
    }
}
