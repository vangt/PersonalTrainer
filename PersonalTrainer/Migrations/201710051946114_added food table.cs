namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfoodtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodInputModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodId = c.String(),
                        UserId = c.String(),
                        FoodName = c.String(),
                        Calories = c.String(),
                        Protien = c.String(),
                        Carb = c.String(),
                        Fat = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FoodInputModels");
        }
    }
}
