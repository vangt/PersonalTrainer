namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedbmiandindicators : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BMI", c => c.String());
            AddColumn("dbo.AspNetUsers", "BmiIndicator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BmiIndicator");
            DropColumn("dbo.AspNetUsers", "BMI");
        }
    }
}
