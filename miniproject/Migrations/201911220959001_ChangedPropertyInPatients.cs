namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPropertyInPatients : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Date", c => c.DateTime(nullable: false));
        }
    }
}
