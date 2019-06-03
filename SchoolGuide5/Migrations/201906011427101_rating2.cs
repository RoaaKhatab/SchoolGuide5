namespace SchoolGuide5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rating2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Rating", c => c.Int(nullable: false));
        }
    }
}
