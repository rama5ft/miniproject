namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedTAbleSlots : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Slots");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeSlots = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
