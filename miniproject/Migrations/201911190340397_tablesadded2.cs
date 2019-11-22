namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablesadded2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(),
                        DocEmailId = c.String(),
                        DocPassword = c.String(),
                        Specialization = c.String(),
                        Experience = c.Int(nullable: false),
                        LocationId = c.Int(),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "LocationId", "dbo.Locations");
            DropIndex("dbo.Doctors", new[] { "LocationId" });
            DropTable("dbo.Locations");
            DropTable("dbo.Doctors");
        }
    }
}
