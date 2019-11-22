namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorViewModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        EmailId = c.String(),
                        SapId = c.String(),
                        Age = c.Int(nullable: false),
                        MobileNumber = c.String(),
                        Date = c.DateTime(nullable: false),
                        TimeSlots = c.String(),
                        DoctorId = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Doctors", "DoctorViewModel_id", c => c.Int());
            CreateIndex("dbo.Doctors", "DoctorViewModel_id");
            AddForeignKey("dbo.Doctors", "DoctorViewModel_id", "dbo.DoctorViewModels", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "DoctorViewModel_id", "dbo.DoctorViewModels");
            DropIndex("dbo.Doctors", new[] { "DoctorViewModel_id" });
            DropColumn("dbo.Doctors", "DoctorViewModel_id");
            DropTable("dbo.DoctorViewModels");
        }
    }
}
