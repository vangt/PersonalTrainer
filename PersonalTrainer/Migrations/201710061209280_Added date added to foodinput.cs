namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeddateaddedtofoodinput : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodInputModels", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FoodInputModels", "DateAdded");
        }
    }
}
