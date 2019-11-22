namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumnsinDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Availability", c => c.Boolean(nullable: false));
            AddColumn("dbo.Doctors", "HospitalAddress", c => c.String());
            AddColumn("dbo.Doctors", "HospitalName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "HospitalName");
            DropColumn("dbo.Doctors", "HospitalAddress");
            DropColumn("dbo.Doctors", "Availability");
        }
    }
}
