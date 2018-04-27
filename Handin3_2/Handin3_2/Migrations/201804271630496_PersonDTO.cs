namespace Handin3_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonDTO : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persons", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Persons", "Name", c => c.String());
        }
    }
}
