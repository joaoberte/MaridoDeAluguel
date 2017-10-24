namespace MaridoDeAluguel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update231017 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdItems", "flagType", c => c.Boolean(nullable: false));
            DropColumn("dbo.AdItems", "flagNew");
            DropColumn("dbo.AdItems", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdItems", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.AdItems", "flagNew", c => c.Boolean(nullable: false));
            DropColumn("dbo.AdItems", "flagType");
        }
    }
}
