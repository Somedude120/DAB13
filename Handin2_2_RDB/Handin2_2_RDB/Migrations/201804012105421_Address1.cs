namespace Handin2_2_RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Address1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.Cities", new[] { "Address_AddressId" });
            AddColumn("dbo.Addresses", "Placement_CityId", c => c.Int());
            CreateIndex("dbo.Addresses", "Placement_CityId");
            AddForeignKey("dbo.Addresses", "Placement_CityId", "dbo.Cities", "CityId");
            DropColumn("dbo.Cities", "Address_AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "Address_AddressId", c => c.Int());
            DropForeignKey("dbo.Addresses", "Placement_CityId", "dbo.Cities");
            DropIndex("dbo.Addresses", new[] { "Placement_CityId" });
            DropColumn("dbo.Addresses", "Placement_CityId");
            CreateIndex("dbo.Cities", "Address_AddressId");
            AddForeignKey("dbo.Cities", "Address_AddressId", "dbo.Addresses", "AddressId");
        }
    }
}
