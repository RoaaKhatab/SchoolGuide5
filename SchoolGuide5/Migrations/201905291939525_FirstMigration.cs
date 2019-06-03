namespace SchoolGuide5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "School_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "UserId");
            CreateIndex("dbo.Comments", "School_id");
            AddForeignKey("dbo.Comments", "School_id", "dbo.Schools", "Sc_id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Comments", "SchoolId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "SchoolId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "School_id", "dbo.Schools");
            DropIndex("dbo.Comments", new[] { "School_id" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            AlterColumn("dbo.Comments", "UserId", c => c.String());
            DropColumn("dbo.Comments", "School_id");
        }
    }
}
