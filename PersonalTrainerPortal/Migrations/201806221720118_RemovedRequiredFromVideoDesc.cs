namespace PersonalTrainerPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRequiredFromVideoDesc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Videos", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Videos", "Description", c => c.String(nullable: false));
        }
    }
}
