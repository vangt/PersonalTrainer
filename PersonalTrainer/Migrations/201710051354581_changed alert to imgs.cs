namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedalerttoimgs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "AlertChecker");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AlertChecker", c => c.Boolean(nullable: false));
        }
    }
}
