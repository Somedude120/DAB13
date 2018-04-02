namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Address3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "CityId", "dbo.Addresses");
            DropIndex("dbo.Cities", new[] { "CityId" });
            DropPrimaryKey("dbo.Cities");
            AddColumn("dbo.Cities", "Address_AddressId", c => c.Int());
            AlterColumn("dbo.Cities", "CityId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Cities", "CityId");
            CreateIndex("dbo.Cities", "Address_AddressId");
            AddForeignKey("dbo.Cities", "Address_AddressId", "dbo.Addresses", "AddressId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.Cities", new[] { "Address_AddressId" });
            DropPrimaryKey("dbo.Cities");
            AlterColumn("dbo.Cities", "CityId", c => c.Int(nullable: false));
            DropColumn("dbo.Cities", "Address_AddressId");
            AddPrimaryKey("dbo.Cities", "CityId");
            CreateIndex("dbo.Cities", "CityId");
            AddForeignKey("dbo.Cities", "CityId", "dbo.Addresses", "AddressId");
        }
    }
}
