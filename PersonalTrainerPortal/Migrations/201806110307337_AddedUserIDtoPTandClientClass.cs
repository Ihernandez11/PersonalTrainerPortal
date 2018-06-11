namespace PersonalTrainerPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIDtoPTandClientClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "UserID", c => c.String());
            AddColumn("dbo.PersonalTrainers", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonalTrainers", "UserID");
            DropColumn("dbo.Clients", "UserID");
        }
    }
}
