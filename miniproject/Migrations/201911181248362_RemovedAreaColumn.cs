namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAreaColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Locations", "Area");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Area", c => c.String());
        }
    }
}
