namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedSpecializationAndRemovedSpecializationColumn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        SpecializationId = c.Int(nullable: false, identity: true),
                        SpecializationName = c.String(),
                    })
                .PrimaryKey(t => t.SpecializationId);
            
            DropColumn("dbo.Doctors", "Specialization");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Specialization", c => c.String());
            DropTable("dbo.Specializations");
        }
    }
}
