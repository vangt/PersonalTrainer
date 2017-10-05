namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedgoals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Goal", c => c.String());
            AddColumn("dbo.AspNetUsers", "GoalWeight", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "GoalWeight");
            DropColumn("dbo.AspNetUsers", "Goal");
        }
    }
}
