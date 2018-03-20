namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addtableid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodInputModels", "TableId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FoodInputModels", "TableId");
        }
    }
}
