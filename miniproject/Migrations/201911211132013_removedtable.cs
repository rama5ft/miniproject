namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Slots", "DoctorId", c => c.Int());
            CreateIndex("dbo.Slots", "DoctorId");
            AddForeignKey("dbo.Slots", "DoctorId", "dbo.Doctors", "DoctorId");
            DropTable("dbo.Patients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        EmailId = c.String(),
                        SapId = c.String(),
                        Password = c.String(),
                        Age = c.Int(nullable: false),
                        MobileNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Slots", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Slots", new[] { "DoctorId" });
            DropColumn("dbo.Slots", "DoctorId");
        }
    }
}
