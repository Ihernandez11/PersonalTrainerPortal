namespace PersonalTrainerPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedWorkoutDateToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Workouts", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workouts", "Date", c => c.DateTime(nullable: false));
        }
    }
}
