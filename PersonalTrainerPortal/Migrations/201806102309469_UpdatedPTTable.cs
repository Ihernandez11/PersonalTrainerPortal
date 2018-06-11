namespace PersonalTrainerPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPTTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        School = c.String(),
                        GraduationYear = c.String(),
                        PersonalTrainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PersonalTrainers", t => t.PersonalTrainerID, cascadeDelete: true)
                .Index(t => t.PersonalTrainerID);
            
            CreateTable(
                "dbo.Offerings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        PersonalTrainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PersonalTrainers", t => t.PersonalTrainerID, cascadeDelete: true)
                .Index(t => t.PersonalTrainerID);
            
            AddColumn("dbo.PersonalTrainers", "Slogan", c => c.String());
            AddColumn("dbo.PersonalTrainers", "ProfileDescription", c => c.String());
            AddColumn("dbo.PersonalTrainers", "CredentialsDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offerings", "PersonalTrainerID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.Credentials", "PersonalTrainerID", "dbo.PersonalTrainers");
            DropIndex("dbo.Offerings", new[] { "PersonalTrainerID" });
            DropIndex("dbo.Credentials", new[] { "PersonalTrainerID" });
            DropColumn("dbo.PersonalTrainers", "CredentialsDescription");
            DropColumn("dbo.PersonalTrainers", "ProfileDescription");
            DropColumn("dbo.PersonalTrainers", "Slogan");
            DropTable("dbo.Offerings");
            DropTable("dbo.Credentials");
        }
    }
}
