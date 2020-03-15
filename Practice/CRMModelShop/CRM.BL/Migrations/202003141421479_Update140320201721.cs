namespace CRM.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update140320201721 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Checks", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Checks", "Created");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Checks", "Created", c => c.DateTime(nullable: false));
            DropColumn("dbo.Checks", "Price");
        }
    }
}
