namespace Handin3_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Persons", name: "AddressList_AddressId", newName: "Addressid");
            RenameIndex(table: "dbo.Persons", name: "IX_AddressList_AddressId", newName: "IX_Addressid");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Persons", name: "IX_Addressid", newName: "IX_AddressList_AddressId");
            RenameColumn(table: "dbo.Persons", name: "Addressid", newName: "AddressList_AddressId");
        }
    }
}
