namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHistoyModeltokeeptrackofupdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastUpdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LastUpdate");
        }
    }
}
