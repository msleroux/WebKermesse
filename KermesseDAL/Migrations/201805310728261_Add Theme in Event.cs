namespace KermesseDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThemeinEvent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PostalAddresses", "Libelle", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.PostalAddresses", "Street", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.PostalAddresses", "PostalCode", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.PostalAddresses", "City", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Events", "Libelle", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Themes", "Libelle", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Themes", "Libelle", c => c.String());
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Libelle", c => c.String(nullable: false));
            AlterColumn("dbo.PostalAddresses", "City", c => c.String());
            AlterColumn("dbo.PostalAddresses", "PostalCode", c => c.String());
            AlterColumn("dbo.PostalAddresses", "Street", c => c.String());
            AlterColumn("dbo.PostalAddresses", "Libelle", c => c.String());
        }
    }
}
