namespace PersonalTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedhistoryaddingprofileupdatetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileUpdatesModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Age = c.String(),
                        Height = c.String(),
                        Weight = c.String(),
                        ActivityLevel = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProfileUpdatesModels");
        }
    }
}
