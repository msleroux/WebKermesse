namespace KermesseDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Picture_In_Events : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Theme_ID", "dbo.Themes");
            DropIndex("dbo.Events", new[] { "Theme_ID" });
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Path = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Events", "Picture_ID", c => c.Guid());
            AlterColumn("dbo.Events", "Theme_ID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Events", "Picture_ID");
            CreateIndex("dbo.Events", "Theme_ID");
            AddForeignKey("dbo.Events", "Picture_ID", "dbo.Pictures", "ID");
            AddForeignKey("dbo.Events", "Theme_ID", "dbo.Themes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Theme_ID", "dbo.Themes");
            DropForeignKey("dbo.Events", "Picture_ID", "dbo.Pictures");
            DropIndex("dbo.Events", new[] { "Theme_ID" });
            DropIndex("dbo.Events", new[] { "Picture_ID" });
            AlterColumn("dbo.Events", "Theme_ID", c => c.Guid());
            DropColumn("dbo.Events", "Picture_ID");
            DropTable("dbo.Pictures");
            CreateIndex("dbo.Events", "Theme_ID");
            AddForeignKey("dbo.Events", "Theme_ID", "dbo.Themes", "ID");
        }
    }
}
