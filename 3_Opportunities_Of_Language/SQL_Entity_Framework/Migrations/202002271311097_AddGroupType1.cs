namespace SQL_Entity_Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupType1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "Type");
        }
    }
}
