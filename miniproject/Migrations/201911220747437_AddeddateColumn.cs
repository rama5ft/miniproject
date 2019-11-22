namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddeddateColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Date");
        }
    }
}
