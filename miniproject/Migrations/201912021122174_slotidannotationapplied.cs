namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slotidannotationapplied : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "SlotId", "dbo.Slots");
            DropIndex("dbo.Patients", new[] { "SlotId" });
            AlterColumn("dbo.Patients", "SlotId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "SlotId");
            AddForeignKey("dbo.Patients", "SlotId", "dbo.Slots", "SlotId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "SlotId", "dbo.Slots");
            DropIndex("dbo.Patients", new[] { "SlotId" });
            AlterColumn("dbo.Patients", "SlotId", c => c.Int());
            CreateIndex("dbo.Patients", "SlotId");
            AddForeignKey("dbo.Patients", "SlotId", "dbo.Slots", "SlotId");
        }
    }
}
