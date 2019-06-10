namespace SchoolGuide5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Whishlist2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersWhishlist", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersWhishlist", "Schools_Sc_id", "dbo.Schools");
            DropIndex("dbo.UsersWhishlist", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UsersWhishlist", new[] { "Schools_Sc_id" });
            CreateTable(
                "dbo.Whishlists",
                c => new
                    {
                        Whish_id = c.Int(nullable: false, identity: true),
                        User_id = c.Int(nullable: false),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Whish_id)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId);
            
            DropTable("dbo.UsersWhishlist");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsersWhishlist",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Schools_Sc_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Schools_Sc_id });
            
            DropForeignKey("dbo.Whishlists", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Whishlists", new[] { "SchoolId" });
            DropTable("dbo.Whishlists");
            CreateIndex("dbo.UsersWhishlist", "Schools_Sc_id");
            CreateIndex("dbo.UsersWhishlist", "ApplicationUser_Id");
            AddForeignKey("dbo.UsersWhishlist", "Schools_Sc_id", "dbo.Schools", "Sc_id", cascadeDelete: true);
            AddForeignKey("dbo.UsersWhishlist", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
