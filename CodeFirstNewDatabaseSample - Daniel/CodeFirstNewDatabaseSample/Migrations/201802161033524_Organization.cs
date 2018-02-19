namespace CodeFirstNewDatabaseSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Organization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        OrganizationID = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(),
                        User_Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrganizationID)
                .ForeignKey("dbo.Users", t => t.User_Username)
                .Index(t => t.User_Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizations", "User_Username", "dbo.Users");
            DropIndex("dbo.Organizations", new[] { "User_Username" });
            DropTable("dbo.Organizations");
        }
    }
}
