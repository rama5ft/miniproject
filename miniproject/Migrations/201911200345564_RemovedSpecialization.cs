namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedSpecialization : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Specializations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        SpecializationId = c.Int(nullable: false, identity: true),
                        SpecializationName = c.String(),
                    })
                .PrimaryKey(t => t.SpecializationId);
            
        }
    }
}
