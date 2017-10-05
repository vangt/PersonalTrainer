namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeddateuploadimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserImgPathModels", "DateUploaded", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserImgPathModels", "DateUploaded");
        }
    }
}
