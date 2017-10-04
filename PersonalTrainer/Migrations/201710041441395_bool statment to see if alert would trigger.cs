namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boolstatmenttoseeifalertwouldtrigger : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AlertChecker", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AlertChecker");
        }
    }
}
