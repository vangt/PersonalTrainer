namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedviewmodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodInputModels", "Weight", c => c.String());
            AddColumn("dbo.FoodInputModels", "Measure", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FoodInputModels", "Measure");
            DropColumn("dbo.FoodInputModels", "Weight");
        }
    }
}
