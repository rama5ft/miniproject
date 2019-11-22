namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedReferncekeyInslots : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Slots", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Slots", new[] { "DoctorId" });
            DropColumn("dbo.Slots", "DoctorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Slots", "DoctorId", c => c.Int());
            CreateIndex("dbo.Slots", "DoctorId");
            AddForeignKey("dbo.Slots", "DoctorId", "dbo.Doctors", "DoctorId");
        }
    }
}
