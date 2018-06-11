namespace PersonalTrainerPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductDescriptionToPTModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonalTrainers", "ProductsDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonalTrainers", "ProductsDescription");
        }
    }
}
