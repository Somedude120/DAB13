namespace CodeFirstNewDatabaseSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Organization7 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "Organization_OrganizationId", newName: "Organizations_OrganizationId");
            RenameIndex(table: "dbo.Users", name: "IX_Organization_OrganizationId", newName: "IX_Organizations_OrganizationId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Users", name: "IX_Organizations_OrganizationId", newName: "IX_Organization_OrganizationId");
            RenameColumn(table: "dbo.Users", name: "Organizations_OrganizationId", newName: "Organization_OrganizationId");
        }
    }
}
