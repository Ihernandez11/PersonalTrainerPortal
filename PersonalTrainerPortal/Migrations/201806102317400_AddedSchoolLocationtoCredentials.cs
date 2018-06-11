namespace PersonalTrainerPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSchoolLocationtoCredentials : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Credentials", "SchoolLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Credentials", "SchoolLocation");
        }
    }
}
