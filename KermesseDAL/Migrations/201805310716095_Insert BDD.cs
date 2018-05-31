namespace KermesseDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertBDD : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PostalAddresses", "PostalCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PostalAddresses", "PostalCode", c => c.Int(nullable: false));
        }
    }
}
