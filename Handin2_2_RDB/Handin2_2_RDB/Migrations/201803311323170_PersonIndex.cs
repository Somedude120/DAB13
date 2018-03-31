namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonIndex : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Phones");
            AlterColumn("dbo.Phones", "Number", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Phones", "Number");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Phones");
            AlterColumn("dbo.Phones", "Number", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Phones", "Number");
        }
    }
}
