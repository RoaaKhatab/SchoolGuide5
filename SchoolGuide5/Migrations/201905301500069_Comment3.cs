namespace SchoolGuide5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comment3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Schools_Sc_id", c => c.Int());
            CreateIndex("dbo.Comments", "Schools_Sc_id");
            AddForeignKey("dbo.Comments", "Schools_Sc_id", "dbo.Schools", "Sc_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Schools_Sc_id", "dbo.Schools");
            DropIndex("dbo.Comments", new[] { "Schools_Sc_id" });
            DropColumn("dbo.Comments", "Schools_Sc_id");
        }
    }
}
