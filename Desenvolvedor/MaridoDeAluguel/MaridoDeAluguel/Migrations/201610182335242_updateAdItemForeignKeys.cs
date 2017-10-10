namespace MaridoDeAluguel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAdItemForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdItems", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.AdItems", "State_Id", "dbo.States");
            DropIndex("dbo.AdItems", new[] { "City_Id" });
            DropIndex("dbo.AdItems", new[] { "State_Id" });
            RenameColumn(table: "dbo.AdItems", name: "City_Id", newName: "CityId");
            RenameColumn(table: "dbo.AdItems", name: "State_Id", newName: "StateId");
            AlterColumn("dbo.AdItems", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AdItems", "Description", c => c.String());
            AlterColumn("dbo.AdItems", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.AdItems", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.AdItems", "CityId");
            CreateIndex("dbo.AdItems", "StateId");
            AddForeignKey("dbo.AdItems", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AdItems", "StateId", "dbo.States", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdItems", "StateId", "dbo.States");
            DropForeignKey("dbo.AdItems", "CityId", "dbo.Cities");
            DropIndex("dbo.AdItems", new[] { "StateId" });
            DropIndex("dbo.AdItems", new[] { "CityId" });
            AlterColumn("dbo.AdItems", "StateId", c => c.Int());
            AlterColumn("dbo.AdItems", "CityId", c => c.Int());
            AlterColumn("dbo.AdItems", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.AdItems", "Title", c => c.String(nullable: false));
            RenameColumn(table: "dbo.AdItems", name: "StateId", newName: "State_Id");
            RenameColumn(table: "dbo.AdItems", name: "CityId", newName: "City_Id");
            CreateIndex("dbo.AdItems", "State_Id");
            CreateIndex("dbo.AdItems", "City_Id");
            AddForeignKey("dbo.AdItems", "State_Id", "dbo.States", "Id");
            AddForeignKey("dbo.AdItems", "City_Id", "dbo.Cities", "Id");
        }
    }
}
