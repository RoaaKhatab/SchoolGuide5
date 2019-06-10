namespace SchoolGuide5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Whishlist3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Whishlists", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Whishlists", new[] { "SchoolId" });
            RenameColumn(table: "dbo.Whishlists", name: "SchoolId", newName: "SC_ID");
            AlterColumn("dbo.Whishlists", "User_id", c => c.String());
            AlterColumn("dbo.Whishlists", "SC_ID", c => c.Int());
            CreateIndex("dbo.Whishlists", "SC_ID");
            AddForeignKey("dbo.Whishlists", "SC_ID", "dbo.Schools", "Sc_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Whishlists", "SC_ID", "dbo.Schools");
            DropIndex("dbo.Whishlists", new[] { "SC_ID" });
            AlterColumn("dbo.Whishlists", "SC_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Whishlists", "User_id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Whishlists", name: "SC_ID", newName: "SchoolId");
            CreateIndex("dbo.Whishlists", "SchoolId");
            AddForeignKey("dbo.Whishlists", "SchoolId", "dbo.Schools", "Sc_id", cascadeDelete: true);
        }
    }
}
