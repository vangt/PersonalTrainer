namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableIDadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExerciseModels", "TableID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExerciseModels", "TableID");
        }
    }
}
