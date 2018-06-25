namespace PersonalTrainerPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPTIDToWorkoutModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "PersonalTrainerID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "PersonalTrainerID");
        }
    }
}
