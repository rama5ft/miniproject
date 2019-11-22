namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablesdropped2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "LocationId", "dbo.Locations");
            DropIndex("dbo.Doctors", new[] { "LocationId" });
            DropTable("dbo.Doctors");
            DropTable("dbo.Locations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(),
                        DocEmailId = c.String(),
                        DocPassword = c.String(),
                        Specialization = c.String(),
                        Experience = c.Int(nullable: false),
                        LocationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Doctors", "LocationId");
            AddForeignKey("dbo.Doctors", "LocationId", "dbo.Locations", "Id");
        }
    }
}
