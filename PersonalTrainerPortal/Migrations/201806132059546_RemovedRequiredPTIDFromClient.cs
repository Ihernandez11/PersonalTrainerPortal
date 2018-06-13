namespace PersonalTrainerPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRequiredPTIDFromClient : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "PersonalTrainerID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "PersonalTrainerID", c => c.String(nullable: false));
        }
    }
}
