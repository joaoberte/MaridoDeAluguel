namespace MaridoDeAluguel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnIntoAdITems : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AdItems", name: "Owner_Id", newName: "OwnerId");
            RenameIndex(table: "dbo.AdItems", name: "IX_Owner_Id", newName: "IX_OwnerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AdItems", name: "IX_OwnerId", newName: "IX_Owner_Id");
            RenameColumn(table: "dbo.AdItems", name: "OwnerId", newName: "Owner_Id");
        }
    }
}
