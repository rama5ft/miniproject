namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedReferncekeySpecializationInDoctor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "SpecializationId", "dbo.Specializations");
            DropIndex("dbo.Doctors", new[] { "SpecializationId" });
            DropColumn("dbo.Doctors", "SpecializationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "SpecializationId", c => c.Int());
            CreateIndex("dbo.Doctors", "SpecializationId");
            AddForeignKey("dbo.Doctors", "SpecializationId", "dbo.Specializations", "SpecializationId");
        }
    }
}
