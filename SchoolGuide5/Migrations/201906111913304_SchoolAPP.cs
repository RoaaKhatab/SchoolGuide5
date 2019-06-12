namespace SchoolGuide5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchoolAPP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schools", "Sc_App", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schools", "Sc_App");
        }
    }
}
