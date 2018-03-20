namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedftandin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfileUpdatesModels", "HeightFeet", c => c.String());
            AddColumn("dbo.ProfileUpdatesModels", "HeightInches", c => c.String());
            DropColumn("dbo.ProfileUpdatesModels", "Height");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProfileUpdatesModels", "Height", c => c.String());
            DropColumn("dbo.ProfileUpdatesModels", "HeightInches");
            DropColumn("dbo.ProfileUpdatesModels", "HeightFeet");
        }
    }
}
