namespace PersonalTrainerPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        PersonalTrainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PersonalTrainers", t => t.PersonalTrainerID, cascadeDelete: true)
                .Index(t => t.PersonalTrainerID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Value = c.String(nullable: false),
                        BlogPostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPostID, cascadeDelete: true)
                .Index(t => t.BlogPostID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        URL = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        BlogPostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPostID, cascadeDelete: true)
                .Index(t => t.BlogPostID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        PersonalTrainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PersonalTrainers", t => t.PersonalTrainerID, cascadeDelete: true)
                .Index(t => t.PersonalTrainerID);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FoodItemID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Instructions = c.String(),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Type = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        RepCount = c.Int(nullable: false),
                        SetCount = c.Int(nullable: false),
                        TimeInterval = c.Int(nullable: false),
                        Instructions = c.String(),
                        ExerciseID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        PersonalTrainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PersonalTrainers", t => t.PersonalTrainerID, cascadeDelete: true)
                .Index(t => t.PersonalTrainerID);
            
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ProteinGrams = c.Int(nullable: false),
                        CarbGrams = c.Int(nullable: false),
                        FatGrams = c.Int(nullable: false),
                        PersonalTrainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PersonalTrainers", t => t.PersonalTrainerID, cascadeDelete: true)
                .Index(t => t.PersonalTrainerID);
            
            CreateTable(
                "dbo.PersonalTrainers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                "dbo.Videos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        URL = c.String(nullable: false),
                        ExerciseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FoodItems", "PersonalTrainerID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.Exercises", "PersonalTrainerID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.Clients", "PersonalTrainerID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.BlogPosts", "PersonalTrainerID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.Workouts", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Meals", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Images", "BlogPostID", "dbo.BlogPosts");
            DropForeignKey("dbo.Comments", "BlogPostID", "dbo.BlogPosts");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FoodItems", new[] { "PersonalTrainerID" });
            DropIndex("dbo.Exercises", new[] { "PersonalTrainerID" });
            DropIndex("dbo.Workouts", new[] { "ClientID" });
            DropIndex("dbo.Meals", new[] { "ClientID" });
            DropIndex("dbo.Clients", new[] { "PersonalTrainerID" });
            DropIndex("dbo.Images", new[] { "BlogPostID" });
            DropIndex("dbo.Comments", new[] { "BlogPostID" });
            DropIndex("dbo.BlogPosts", new[] { "PersonalTrainerID" });
            DropTable("dbo.Videos");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PersonalTrainers");
            DropTable("dbo.FoodItems");
            DropTable("dbo.Exercises");
            DropTable("dbo.Workouts");
            DropTable("dbo.Meals");
            DropTable("dbo.Clients");
            DropTable("dbo.Images");
            DropTable("dbo.Comments");
            DropTable("dbo.BlogPosts");
        }
    }
}
