namespace SchoolGuide5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Username");
        }
    }
}
