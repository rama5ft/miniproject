namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SlotTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        SlotId = c.Int(nullable: false, identity: true),
                        TimeSlots = c.String(),
                    })
                .PrimaryKey(t => t.SlotId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Slots");
        }
    }
}
