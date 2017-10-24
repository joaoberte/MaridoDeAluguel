namespace MaridoDeAluguel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdItems",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false),
                    flagNew = c.Boolean(nullable: false),
                    Description = c.String(nullable: false),
                    Price = c.Double(nullable: false),
                    BuyerId = c.String(maxLength: 128),
                    CategoryId = c.Int(nullable: false),
                    PostedAt = c.DateTime(precision: 7, storeType: "datetime2"),
                    ClosedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Owner_Id = c.String(nullable: false, maxLength: 128),
                    City_Id = c.Int(),
                    State_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.BuyerId)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.States", t => t.State_Id)
                .Index(t => t.BuyerId)
                .Index(t => t.CategoryId)
                .Index(t => t.Owner_Id)
                .Index(t => t.City_Id)
                .Index(t => t.State_Id);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Telephone = c.String(),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    ParentCategory_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentCategory_Id)
                .Index(t => t.ParentCategory_Id);

            CreateTable(
                "dbo.Cities",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    State_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.State_Id)
                .Index(t => t.State_Id);

            CreateTable(
                "dbo.States",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    UF = c.String(maxLength: 3),
                    Country_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);

            CreateTable(
                "dbo.Countries",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AdItems", "State_Id", "dbo.States");
            DropForeignKey("dbo.AdItems", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Cities", "State_Id", "dbo.States");
            DropForeignKey("dbo.States", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Categories", "ParentCategory_Id", "dbo.Categories");
            DropForeignKey("dbo.AdItems", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AdItems", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AdItems", "BuyerId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.States", new[] { "Country_Id" });
            DropIndex("dbo.Cities", new[] { "State_Id" });
            DropIndex("dbo.Categories", new[] { "ParentCategory_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AdItems", new[] { "State_Id" });
            DropIndex("dbo.AdItems", new[] { "City_Id" });
            DropIndex("dbo.AdItems", new[] { "Owner_Id" });
            DropIndex("dbo.AdItems", new[] { "CategoryId" });
            DropIndex("dbo.AdItems", new[] { "BuyerId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
            DropTable("dbo.Categories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AdItems");
        }
    }
}