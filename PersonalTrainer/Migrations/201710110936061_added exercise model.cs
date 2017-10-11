namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedexercisemodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExerciseModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ExerciseName = c.String(),
                        ExerciseId = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExerciseModels");
        }
    }
}
