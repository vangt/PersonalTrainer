namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedactivityleveltouser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ActivityLevel", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ActivityLevel");
        }
    }
}
