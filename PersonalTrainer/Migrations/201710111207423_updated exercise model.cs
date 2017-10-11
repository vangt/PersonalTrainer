namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedexercisemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExerciseModels", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExerciseModels", "DateAdded");
        }
    }
}
