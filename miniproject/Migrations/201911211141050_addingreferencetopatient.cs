namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingreferencetopatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "DoctorId", c => c.Int());
            AddColumn("dbo.Patients", "EmployeeId", c => c.Int());
            AddColumn("dbo.Patients", "SlotId", c => c.Int());
            CreateIndex("dbo.Patients", "DoctorId");
            CreateIndex("dbo.Patients", "EmployeeId");
            CreateIndex("dbo.Patients", "SlotId");
            AddForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors", "DoctorId");
            AddForeignKey("dbo.Patients", "EmployeeId", "dbo.Employees", "Id");
            AddForeignKey("dbo.Patients", "SlotId", "dbo.Slots", "SlotId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "SlotId", "dbo.Slots");
            DropForeignKey("dbo.Patients", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Patients", new[] { "SlotId" });
            DropIndex("dbo.Patients", new[] { "EmployeeId" });
            DropIndex("dbo.Patients", new[] { "DoctorId" });
            DropColumn("dbo.Patients", "SlotId");
            DropColumn("dbo.Patients", "EmployeeId");
            DropColumn("dbo.Patients", "DoctorId");
        }
    }
}
