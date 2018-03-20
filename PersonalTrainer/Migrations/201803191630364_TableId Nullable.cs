namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableIdNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FoodInputModels", "TableId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FoodInputModels", "TableId", c => c.Int(nullable: false));
        }
    }
}
