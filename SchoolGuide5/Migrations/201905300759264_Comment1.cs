namespace SchoolGuide5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comment1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "School_id", "dbo.Schools");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "School_id" });
            AlterColumn("dbo.Comments", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "School_id");
            CreateIndex("dbo.Comments", "UserId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Comments", "School_id", "dbo.Schools", "Sc_id");
        }
    }
}
