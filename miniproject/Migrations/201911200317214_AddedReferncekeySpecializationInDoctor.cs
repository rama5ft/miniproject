namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReferncekeySpecializationInDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "SpecializationId", c => c.Int());
            CreateIndex("dbo.Doctors", "SpecializationId");
            AddForeignKey("dbo.Doctors", "SpecializationId", "dbo.Specializations", "SpecializationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "SpecializationId", "dbo.Specializations");
            DropIndex("dbo.Doctors", new[] { "SpecializationId" });
            DropColumn("dbo.Doctors", "SpecializationId");
        }
    }
}
