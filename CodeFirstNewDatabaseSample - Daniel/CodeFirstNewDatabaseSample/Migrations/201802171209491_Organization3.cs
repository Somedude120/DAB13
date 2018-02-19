namespace CodeFirstNewDatabaseSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Organization3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "Organization_OrganizationID" });
            CreateIndex("dbo.Users", "Organization_OrganizationId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Organization_OrganizationId" });
            CreateIndex("dbo.Users", "Organization_OrganizationID");
        }
    }
}
