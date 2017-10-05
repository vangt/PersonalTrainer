namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddatetotheprofilehistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfileUpdatesModels", "DateOfLog", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfileUpdatesModels", "DateOfLog");
        }
    }
}
