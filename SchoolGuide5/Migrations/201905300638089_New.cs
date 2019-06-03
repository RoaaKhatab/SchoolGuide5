namespace SchoolGuide5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "School_id", "dbo.Schools");
            DropIndex("dbo.Comments", new[] { "School_id" });
            AlterColumn("dbo.Comments", "School_id", c => c.Int());
            CreateIndex("dbo.Comments", "School_id");
            AddForeignKey("dbo.Comments", "School_id", "dbo.Schools", "Sc_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "School_id", "dbo.Schools");
            DropIndex("dbo.Comments", new[] { "School_id" });
            AlterColumn("dbo.Comments", "School_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "School_id");
            AddForeignKey("dbo.Comments", "School_id", "dbo.Schools", "Sc_id", cascadeDelete: true);
        }
    }
}
