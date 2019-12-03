namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appliedannotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "FullName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Patients", "EmailId", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "SapId", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "MobileNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Date", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Date", c => c.String());
            AlterColumn("dbo.Patients", "MobileNumber", c => c.String());
            AlterColumn("dbo.Patients", "SapId", c => c.String());
            AlterColumn("dbo.Patients", "EmailId", c => c.String());
            AlterColumn("dbo.Patients", "FullName", c => c.String());
        }
    }
}
