namespace SchoolGuide5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.gmails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        To = c.String(),
                        From = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AlterColumn("dbo.Schools", "Sc_Fees_From", c => c.Int(nullable: false));
            AlterColumn("dbo.Schools", "Sc_Fees_To", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schools", "Sc_Fees_To", c => c.String());
            AlterColumn("dbo.Schools", "Sc_Fees_From", c => c.String());
            DropTable("dbo.gmails");
        }
    }
}
