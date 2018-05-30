namespace KermesseDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostalAddresses",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Libelle = c.String(),
                        Street = c.String(),
                        PostalCode = c.Int(nullable: false),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Libelle = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Address_ID = c.Guid(),
                        Theme_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostalAddresses", t => t.Address_ID)
                .ForeignKey("dbo.Themes", t => t.Theme_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.Theme_ID);
            
            CreateTable(
                "dbo.Themes",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Theme_ID", "dbo.Themes");
            DropForeignKey("dbo.Events", "Address_ID", "dbo.PostalAddresses");
            DropIndex("dbo.Events", new[] { "Theme_ID" });
            DropIndex("dbo.Events", new[] { "Address_ID" });
            DropTable("dbo.Themes");
            DropTable("dbo.Events");
            DropTable("dbo.PostalAddresses");
        }
    }
}
