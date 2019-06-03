namespace SchoolGuide5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comments2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schools", "Sc_phone2", c => c.Int());
            AlterColumn("dbo.Schools", "Sc_phone3", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schools", "Sc_phone3", c => c.Int(nullable: false));
            AlterColumn("dbo.Schools", "Sc_phone2", c => c.Int(nullable: false));
        }
    }
}
