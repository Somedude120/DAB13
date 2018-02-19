namespace CodeFirstNewDatabaseSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Organization2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Organizations", "User_Username", "dbo.Users");
            DropIndex("dbo.Organizations", new[] { "User_Username" });
            AddColumn("dbo.Users", "Organization_OrganizationID", c => c.Int());
            CreateIndex("dbo.Users", "Organization_OrganizationID");
            AddForeignKey("dbo.Users", "Organization_OrganizationID", "dbo.Organizations", "OrganizationID");
            DropColumn("dbo.Organizations", "User_Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organizations", "User_Username", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Users", "Organization_OrganizationID", "dbo.Organizations");
            DropIndex("dbo.Users", new[] { "Organization_OrganizationID" });
            DropColumn("dbo.Users", "Organization_OrganizationID");
            CreateIndex("dbo.Organizations", "User_Username");
            AddForeignKey("dbo.Organizations", "User_Username", "dbo.Users", "Username");
        }
    }
}
