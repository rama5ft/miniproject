namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedColumnInSlots : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Slots", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Slots", "Date");
        }
    }
}
