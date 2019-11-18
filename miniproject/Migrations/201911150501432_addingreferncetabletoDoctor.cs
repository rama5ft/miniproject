namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingreferncetabletoDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "LocationId", c => c.Int());
            CreateIndex("dbo.Doctors", "LocationId");
            AddForeignKey("dbo.Doctors", "LocationId", "dbo.Locations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "LocationId", "dbo.Locations");
            DropIndex("dbo.Doctors", new[] { "LocationId" });
            DropColumn("dbo.Doctors", "LocationId");
        }
    }
}
