namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doublecheckedheight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "HeightFeet", c => c.String());
            AddColumn("dbo.AspNetUsers", "HeightInches", c => c.String());
            DropColumn("dbo.AspNetUsers", "Height");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Height", c => c.String());
            DropColumn("dbo.AspNetUsers", "HeightInches");
            DropColumn("dbo.AspNetUsers", "HeightFeet");
        }
    }
}
