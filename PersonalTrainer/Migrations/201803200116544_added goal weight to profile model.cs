namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedgoalweighttoprofilemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfileUpdatesModels", "GoalWeight", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfileUpdatesModels", "GoalWeight");
        }
    }
}
