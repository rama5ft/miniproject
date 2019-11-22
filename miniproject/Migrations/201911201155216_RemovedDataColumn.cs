namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDataColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DoctorViewModels", "Date");
            DropColumn("dbo.Slots", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Slots", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.DoctorViewModels", "Date", c => c.DateTime(nullable: false));
        }
    }
}
