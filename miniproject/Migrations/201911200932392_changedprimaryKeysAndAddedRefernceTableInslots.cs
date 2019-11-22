namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedprimaryKeysAndAddedRefernceTableInslots : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Slots", "DoctorId", c => c.Int());
            CreateIndex("dbo.Slots", "DoctorId");
            AddForeignKey("dbo.Slots", "DoctorId", "dbo.Doctors", "DoctorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slots", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Slots", new[] { "DoctorId" });
            AlterColumn("dbo.Slots", "DoctorId", c => c.Int(nullable: false));
        }
    }
}
