namespace SchoolGuide5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Whishlist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsersWhishlist",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Schools_Sc_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Schools_Sc_id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Schools", t => t.Schools_Sc_id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Schools_Sc_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersWhishlist", "Schools_Sc_id", "dbo.Schools");
            DropForeignKey("dbo.UsersWhishlist", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UsersWhishlist", new[] { "Schools_Sc_id" });
            DropIndex("dbo.UsersWhishlist", new[] { "ApplicationUser_Id" });
            DropTable("dbo.UsersWhishlist");
        }
    }
}
