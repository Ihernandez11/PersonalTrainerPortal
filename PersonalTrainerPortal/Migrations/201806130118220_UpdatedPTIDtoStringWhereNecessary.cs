namespace PersonalTrainerPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPTIDtoStringWhereNecessary : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meals", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Workouts", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.BlogPosts", "PersonalTrainerID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.Clients", "PersonalTrainerID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.Credentials", "PersonalTrainerID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.Exercises", "PersonalTrainerID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.FoodItems", "PersonalTrainerID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.Offerings", "PersonalTrainerID", "dbo.PersonalTrainers");
            DropIndex("dbo.BlogPosts", new[] { "PersonalTrainerID" });
            DropIndex("dbo.Clients", new[] { "PersonalTrainerID" });
            DropIndex("dbo.Meals", new[] { "ClientID" });
            DropIndex("dbo.Workouts", new[] { "ClientID" });
            DropIndex("dbo.Credentials", new[] { "PersonalTrainerID" });
            DropIndex("dbo.Exercises", new[] { "PersonalTrainerID" });
            DropIndex("dbo.FoodItems", new[] { "PersonalTrainerID" });
            DropIndex("dbo.Offerings", new[] { "PersonalTrainerID" });
            AddColumn("dbo.BlogPosts", "PersonalTrainer_ID", c => c.Int());
            AddColumn("dbo.Clients", "PersonalTrainer_ID", c => c.Int());
            AddColumn("dbo.Meals", "Client_ID", c => c.Int());
            AddColumn("dbo.Workouts", "Client_ID", c => c.Int());
            AddColumn("dbo.Credentials", "PersonalTrainer_ID", c => c.Int());
            AddColumn("dbo.Exercises", "PersonalTrainer_ID", c => c.Int());
            AddColumn("dbo.FoodItems", "PersonalTrainer_ID", c => c.Int());
            AddColumn("dbo.Offerings", "PersonalTrainer_ID", c => c.Int());
            AlterColumn("dbo.BlogPosts", "PersonalTrainerID", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "PersonalTrainerID", c => c.String(nullable: false));
            AlterColumn("dbo.Meals", "ClientID", c => c.String());
            AlterColumn("dbo.Workouts", "ClientID", c => c.String());
            AlterColumn("dbo.Credentials", "PersonalTrainerID", c => c.String());
            AlterColumn("dbo.Exercises", "PersonalTrainerID", c => c.String(nullable: false));
            AlterColumn("dbo.FoodItems", "PersonalTrainerID", c => c.String(nullable: false));
            AlterColumn("dbo.Offerings", "PersonalTrainerID", c => c.String());
            CreateIndex("dbo.BlogPosts", "PersonalTrainer_ID");
            CreateIndex("dbo.Clients", "PersonalTrainer_ID");
            CreateIndex("dbo.Meals", "Client_ID");
            CreateIndex("dbo.Workouts", "Client_ID");
            CreateIndex("dbo.Credentials", "PersonalTrainer_ID");
            CreateIndex("dbo.Exercises", "PersonalTrainer_ID");
            CreateIndex("dbo.FoodItems", "PersonalTrainer_ID");
            CreateIndex("dbo.Offerings", "PersonalTrainer_ID");
            AddForeignKey("dbo.Meals", "Client_ID", "dbo.Clients", "ID");
            AddForeignKey("dbo.Workouts", "Client_ID", "dbo.Clients", "ID");
            AddForeignKey("dbo.BlogPosts", "PersonalTrainer_ID", "dbo.PersonalTrainers", "ID");
            AddForeignKey("dbo.Clients", "PersonalTrainer_ID", "dbo.PersonalTrainers", "ID");
            AddForeignKey("dbo.Credentials", "PersonalTrainer_ID", "dbo.PersonalTrainers", "ID");
            AddForeignKey("dbo.Exercises", "PersonalTrainer_ID", "dbo.PersonalTrainers", "ID");
            AddForeignKey("dbo.FoodItems", "PersonalTrainer_ID", "dbo.PersonalTrainers", "ID");
            AddForeignKey("dbo.Offerings", "PersonalTrainer_ID", "dbo.PersonalTrainers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offerings", "PersonalTrainer_ID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.FoodItems", "PersonalTrainer_ID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.Exercises", "PersonalTrainer_ID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.Credentials", "PersonalTrainer_ID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.Clients", "PersonalTrainer_ID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.BlogPosts", "PersonalTrainer_ID", "dbo.PersonalTrainers");
            DropForeignKey("dbo.Workouts", "Client_ID", "dbo.Clients");
            DropForeignKey("dbo.Meals", "Client_ID", "dbo.Clients");
            DropIndex("dbo.Offerings", new[] { "PersonalTrainer_ID" });
            DropIndex("dbo.FoodItems", new[] { "PersonalTrainer_ID" });
            DropIndex("dbo.Exercises", new[] { "PersonalTrainer_ID" });
            DropIndex("dbo.Credentials", new[] { "PersonalTrainer_ID" });
            DropIndex("dbo.Workouts", new[] { "Client_ID" });
            DropIndex("dbo.Meals", new[] { "Client_ID" });
            DropIndex("dbo.Clients", new[] { "PersonalTrainer_ID" });
            DropIndex("dbo.BlogPosts", new[] { "PersonalTrainer_ID" });
            AlterColumn("dbo.Offerings", "PersonalTrainerID", c => c.Int(nullable: false));
            AlterColumn("dbo.FoodItems", "PersonalTrainerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Exercises", "PersonalTrainerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Credentials", "PersonalTrainerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Workouts", "ClientID", c => c.Int(nullable: false));
            AlterColumn("dbo.Meals", "ClientID", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "PersonalTrainerID", c => c.Int(nullable: false));
            AlterColumn("dbo.BlogPosts", "PersonalTrainerID", c => c.Int(nullable: false));
            DropColumn("dbo.Offerings", "PersonalTrainer_ID");
            DropColumn("dbo.FoodItems", "PersonalTrainer_ID");
            DropColumn("dbo.Exercises", "PersonalTrainer_ID");
            DropColumn("dbo.Credentials", "PersonalTrainer_ID");
            DropColumn("dbo.Workouts", "Client_ID");
            DropColumn("dbo.Meals", "Client_ID");
            DropColumn("dbo.Clients", "PersonalTrainer_ID");
            DropColumn("dbo.BlogPosts", "PersonalTrainer_ID");
            CreateIndex("dbo.Offerings", "PersonalTrainerID");
            CreateIndex("dbo.FoodItems", "PersonalTrainerID");
            CreateIndex("dbo.Exercises", "PersonalTrainerID");
            CreateIndex("dbo.Credentials", "PersonalTrainerID");
            CreateIndex("dbo.Workouts", "ClientID");
            CreateIndex("dbo.Meals", "ClientID");
            CreateIndex("dbo.Clients", "PersonalTrainerID");
            CreateIndex("dbo.BlogPosts", "PersonalTrainerID");
            AddForeignKey("dbo.Offerings", "PersonalTrainerID", "dbo.PersonalTrainers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.FoodItems", "PersonalTrainerID", "dbo.PersonalTrainers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Exercises", "PersonalTrainerID", "dbo.PersonalTrainers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Credentials", "PersonalTrainerID", "dbo.PersonalTrainers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "PersonalTrainerID", "dbo.PersonalTrainers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.BlogPosts", "PersonalTrainerID", "dbo.PersonalTrainers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Workouts", "ClientID", "dbo.Clients", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Meals", "ClientID", "dbo.Clients", "ID", cascadeDelete: true);
        }
    }
}
