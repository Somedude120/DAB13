namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Persons3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Persons");
            AddColumn("dbo.Persons", "PersonId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Persons", "Name", c => c.String());
            AddPrimaryKey("dbo.Persons", "PersonId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Persons");
            AlterColumn("dbo.Persons", "Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Persons", "PersonId");
            AddPrimaryKey("dbo.Persons", "Name");
        }
    }
}
