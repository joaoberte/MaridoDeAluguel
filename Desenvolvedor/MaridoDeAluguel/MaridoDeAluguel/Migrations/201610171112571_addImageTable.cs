namespace MaridoDeAluguel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        AdItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdItems", t => t.AdItemId, cascadeDelete: true)
                .Index(t => t.AdItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "AdItemId", "dbo.AdItems");
            DropIndex("dbo.Images", new[] { "AdItemId" });
            DropTable("dbo.Images");
        }
    }
}
